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
    public class WhatIsMonikers : ProcessorBase
    {
        public WhatIsMonikers() :
            base(
            @"(who|what|how|why|Who|What|How|Why) (are|is) (the|an|a)* *(.+)",
            SortOrderEnum.GeneralQuery,
            "What is DevFacto?",
            "Why is the sky blue?",
            "How are you?",
            "Who is Kevin?"
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
                monikers.AddRange(MonikerRetriever.FindMonikers(groups[4].Value));

                result = BinaryDataRetriever.GetData(monikers.ToArray());
                return result;
            }
        }
    }
}
