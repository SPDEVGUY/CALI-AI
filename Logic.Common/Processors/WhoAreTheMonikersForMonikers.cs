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
    public class WhoAreTheMonikersForMonikers : ProcessorBase
    {
        public WhoAreTheMonikersForMonikers() :
            base(
            @"(who|what|Who|What) (are|is) (the|an|a) (.+) (for|at|on) (.+)",
            SortOrderEnum.SpecificQuery,
            "Who are the employees for DevFacto?",
            "What are the employees for DevFacto Edmonton?",
            "Who is the MCM for DevFacto?",
            "Who is a senior developer on cali?"
            )
        { }

        public override List<BinaryDataContract> Process(string query, MatchCollection matches)
        {
            using (new LogBlock(query))
            {
                var result = new List<BinaryDataContract>();

                var items = Tester.Matches(query);
                var groups = items[0].Groups;

                var monikers = new List<MonikerContract>();
                var first = MonikerRetriever.FindMonikers(groups[4].Value,true);
                var second = MonikerRetriever.FindMonikers(groups[6].Value, true);
                
                monikers.AddRange(first);
                monikers.AddRange(second);

                result = BinaryDataRetriever.GetData(monikers.ToArray());
                return result;
            }
        }
    }
}
