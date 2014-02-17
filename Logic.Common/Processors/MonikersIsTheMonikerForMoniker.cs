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
    public class MonikersIsTheMonikerForMoniker : ProcessorBase
    {
        public MonikersIsTheMonikerForMoniker() :
            base(
            @"(.+) is (the|an|a) (.+) (for|at|on) (.+)",
            SortOrderEnum.SpecificStatement,
            "Kevin Cole is the MCM for Devfacto.",
            "Kevin Cole is an employee at Devfacto.",
            "Kevin Cole is a Senior Developer on Project CALI."
            )
        { }

        public override List<BinaryDataContract> Process(string query, MatchCollection matches)
        {
            using (new LogBlock(query))
            {
                var result = new List<BinaryDataContract>();

                query = query.Replace(".", "");
                var items = Tester.Matches(query);
                var groups = items[0].Groups;

                var monikers = new List<MonikerContract>();
                monikers.AddRange(MonikerRetriever.FindMonikers(groups[1].Value, true));
                monikers.AddRange(MonikerRetriever.FindMonikers(groups[3].Value, true));
                monikers.AddRange(MonikerRetriever.FindMonikers(groups[5].Value, true));

                var data = BinaryDataRetriever.StoreData("string.fact", query);
                MonikerRetriever.AssociateMonikers(data, monikers.ToArray());

                return result;
            }
        }
    }
}
