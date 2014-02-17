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
    public class ThisIsMonikers : ProcessorBase
    {
        public ThisIsMonikers() :
            base(
            @"(This|this|These|these|Here|here) (is|are) (the )?(.+)",
            SortOrderEnum.SpecificStatement,
            "These are the service accounts for DevFacto.",
            "This is Bob Stahl",
            "Here are the accounts for DevFacto."
            )
        { }

        public override List<BinaryDataContract> Process(string query, MatchCollection matches)
        {
            using (new LogBlock(query))
            {
                var result = new List<BinaryDataContract>();

                var items = Tester.Matches(query);
                var groups = items[0].Groups;

                var monikersStr = groups[4].Value;
                var monikers = MonikerRetriever.FindMonikers(monikersStr, true);

                var data = BinaryDataRetriever.StoreData(Router.DataType, Router.Data);
                MonikerRetriever.AssociateMonikers(data,monikers.ToArray());
                
                result.Add(data);

                return result;
            }
        }
    }
}
