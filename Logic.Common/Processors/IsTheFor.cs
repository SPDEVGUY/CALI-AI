using System.Text.RegularExpressions;
using CALI.Logic.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CALI.Database.Contracts.Data;
using CALI.Logic.Common.Util;

namespace CALI.Logic.Common.Processors
{
    public class IsTheFor : ICaliQueryProcessor
    {
        public const string RegEx = @"(.+) is the (.+) for (.+)";
        public readonly Regex Tester = new Regex(RegEx);
        public string Example
        {
            get { return "Bob is the IT Admin for PCL"; }
        }

        public int SortOrder
        {
            get { return 10; }
        }

        public bool Test(string query)
        {
            return Tester.IsMatch(query);
        }

        public List<BinaryDataContract> Run(string query)
        {
            var result = new List<BinaryDataContract>();

            query = query.Replace(".", "");
            var items = Tester.Matches(query);
            var groups = items[0].Groups;

            var noun1 = MonikerRetriever.GetMoniker(groups[1].Value,true);
            var noun2 = MonikerRetriever.GetMoniker(groups[2].Value,true);
            var noun3 = MonikerRetriever.GetMoniker(groups[3].Value, true);

            var dataBytes = Encoding.ASCII.GetBytes(query);
            var data = BinaryDataRetriever.StoreData("string", dataBytes);
            MonikerRetriever.AssociateMonikers(data, noun1, noun2,noun3);

            return result;
        }
    }
}
