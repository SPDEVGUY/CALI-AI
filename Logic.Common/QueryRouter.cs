using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using CALI.Database.Contracts.Data;
using CALI.Database.Logic.Data;
using CALI.Logic.Common.Interfaces;
using CALI.Logic.Common.Util;

namespace CALI.Logic.Common
{
    public class QueryRouter
    {
        private static QueryRouter _instance;
        private readonly List<ICaliQueryProvider> _providers = new List<ICaliQueryProvider>();
        private readonly List<ICaliQueryProcessor> _processors = new List<ICaliQueryProcessor>();
        
        public bool DebugMode = true;
        public string DataType = "";
        public byte[] Data = new byte[0];
        public static QueryRouter Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new QueryRouter();
                    _instance.RegisterAllProcessors();
                    _instance.RegisterAllProviders();
                }
                return _instance;
            }
        }
        
        public void RegisterAllProcessors()
        {
            var processors = ReflectoMatic.CreateObjects<ICaliQueryProcessor>(GetType().Assembly);
            _processors.AddRange(processors);
            foreach (var processor in processors)
            {
                processor.Router = this;
            }
            _processors.Sort((x, y) => x.SortOrder.CompareTo(y.SortOrder));
        }
        public void RegisterAllProviders()
        {
            var providers = ReflectoMatic.CreateObjects<ICaliQueryProvider>(GetType().Assembly);
            _providers.AddRange(providers);
            foreach (var provider in providers)
            {
                provider.QueryReceived += Query;
                provider.SetDataContext += SetDataContext;
            }
        }

        public void SetDataContext(ICaliQueryProvider source, string dataType, byte[] data)
        {
            Data = data;
            DataType = dataType;
        }

        public void RegisterProvider(ICaliQueryProvider provider)
        {
            _providers.Add(provider);
            provider.QueryReceived += Query;
            provider.SetDataContext += SetDataContext;
        }
        public void RegisterProcessor(ICaliQueryProcessor processor)
        {
            _processors.Add(processor);
            processor.Router = this;
            _processors.Sort((x,y)=> x.SortOrder.CompareTo(y.SortOrder));
        }

        public void RunAllExampleTests()
        {
            DebugMode = true;
            foreach (var processor in _processors) RunExampleTestsForProcessor(processor);
        }


        protected List<BinaryDataContract> Query(ICaliQueryProvider source, string text)
        {
            var result = new List<BinaryDataContract>();
            var query = QueryRetriever.GetQuery(text);
            var queryText = text.Replace("?", "");

            query.PoviderSource = source==null ? "Unknown" : source.GetType().Name;

            var processor = FindProcessor(queryText);
            if (processor != null)
            {
                try
                {
                    var tester = processor.Tester;
                    var matches = tester.Matches(queryText);
                    query.ProcessorUsed = processor.GetType().Name;
                    if (DebugMode) PrintQueryDebug(queryText, matches, processor);
                    result = processor.Process(queryText, matches);
                }
                catch (Exception ex)
                {
                    query.Exceptions = ex.ToString();
                    query.IsSuccess = false;
                }
                query.IsSuccess = true;
            }
            else
            {
                query.IsSuccess = false;
            }

            QueryLogic.SaveNow(query);
            return result; 
        }

        protected ICaliQueryProcessor FindProcessor(string query)
        {
            foreach (var processor in _processors)
            {
                var tester = processor.Tester;
                if (tester.IsMatch(query)) return processor;
            }
            return null;
        }

        protected class ExampleTestsForProcessor : ICaliQueryProvider {
            public event ICaliQueryProviderDelegates.QueryReceivedDelegate QueryReceived;
            public event ICaliQueryProviderDelegates.SetDataContextDelegate SetDataContext;
        }

        protected void RunExampleTestsForProcessor(ICaliQueryProcessor processor)
        {
            var provider = new ExampleTestsForProcessor();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Testing Processor: {0}", processor.GetType().Name);
            Console.ForegroundColor = ConsoleColor.Gray;
            var examples = processor.Examples;
            foreach (var example in examples)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\tExample: {0}", example);

                Console.ForegroundColor = ConsoleColor.Gray;
                var processorThatWillBeUsed = FindProcessor(example);
                if (processorThatWillBeUsed != processor)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tWARNING: example text for processor is not currently hitting properly.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                var result = Query(provider, example);
                PrintResults(example, result);

            }
        }

        protected void PrintQueryDebug(string query, MatchCollection matches, ICaliQueryProcessor processor)
        {
            Console.WriteLine("<<DEBUG>>");
            Console.WriteLine("Query: {0}", query);
            Console.WriteLine("Processor: {0}", processor.GetType().Name);
            Console.WriteLine("Matches:");
            foreach (Match match in matches)
            {
                Console.WriteLine("\t{0}", match.Value);
                Console.WriteLine("Groups:");
                var groupIx = 0;
                foreach (Group group in match.Groups)
                {
                    Console.WriteLine("\t\t{2} - {0}:{1}", group.Success, group.Value,groupIx);
                    groupIx++;
                }
            }

            Console.WriteLine("<</DEBUG>>");
        }

        protected void PrintResults(string header, List<BinaryDataContract> results)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(header);
            foreach (var result in results)
            {
                var dataStr = Encoding.ASCII.GetString(result.Data);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\t {0} :", result.DataType);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(dataStr);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
