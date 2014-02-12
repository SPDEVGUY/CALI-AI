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
    public class WhoWhatAreIsTheFor : ICaliQueryProcessor
    {
        public const string RegEx = @"(who|what|Who|What) (are|is) the (.+) for (.+)";
        public readonly Regex Tester = new Regex(RegEx);
        public string Example
        {
            get { return "Who are the contacts for PCL?"; }
        }

        public int SortOrder
        {
            get { return 1; }
        }

        public bool Test(string query)
        {
            return Tester.IsMatch(query);
        }

        public List<BinaryDataContract> Run(string query)
        {
            var result = new List<BinaryDataContract>();

            query = query.Replace("?", "");
            var items = Tester.Matches(query);
            var groups = items[0].Groups;

            var monikers = new List<MonikerContract>();
            monikers.AddRange(MonikerRetriever.FindMonikers(groups[3].Value));
            monikers.AddRange(MonikerRetriever.FindMonikers(groups[4].Value));

            result = BinaryDataRetriever.GetData(monikers.ToArray());
            return result;
        }
    }
}
