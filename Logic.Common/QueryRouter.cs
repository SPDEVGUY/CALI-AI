using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CALI.Database.Contracts.Data;
using CALI.Database.Logic.Data;
using CALI.Logic.Common.Interfaces;
using CALI.Logic.Common.Util;

namespace CALI.Logic.Common
{
    public class QueryRouter
    {
        private List<ICaliQueryProvider> _providers = new List<ICaliQueryProvider>();
        private List<ICaliQueryProcessor> _processors = new List<ICaliQueryProcessor>();

        public void RegisterProvider(ICaliQueryProvider provider)
        {
            _providers.Add(provider);
            provider.QueryReceived += provider_QueryReceived;
        }
        public List<BinaryDataContract> Query(string text)
        {
            return provider_QueryReceived(text);
        }
            
        private List<BinaryDataContract> provider_QueryReceived(string queryText)
        {
            var result = new List<BinaryDataContract>();
            var query = QueryRetriever.GetQuery(queryText);
            var processor = FindProcessor(queryText);
            if (processor != null)
            {
                try
                {
                    query.ProcessorUsed = processor.GetType().Name;
                    result = processor.Run(queryText);
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

        public void RegisterProcessor(ICaliQueryProcessor processor)
        {
            _processors.Add(processor);
            _processors.Sort((x,y)=> x.SortOrder.CompareTo(y.SortOrder));
        }

        public ICaliQueryProcessor FindProcessor(string query)
        {
            foreach (var processor in _processors)
            {
                if (processor.Test(query)) return processor;
            }
            return null;
        }
    }
}
