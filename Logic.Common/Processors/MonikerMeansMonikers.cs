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
    public class MonikerMeansMonikers : ProcessorBase
    {
        public MonikerMeansMonikers() :
            base(
            @"((The|the|A|a|An|an) )?(.+) (means|is( the same as| plural for)*|=|stands for) (.+)",
            SortOrderEnum.GeneralStatement,
            "Farm account is the same as admin account.",
            "SP stands for SharePoint",
            "bldr = builder",
            "gogle is google",
            "employees is plural for employee"
            )
        { }

        public override List<BinaryDataContract> Process(string query, MatchCollection matches)
        {
            using (new LogBlock(query))
            {
                var result = new List<BinaryDataContract>();

                query = query.Replace("?", "");
                var items = Tester.Matches(query);
                var groups = items[0].Groups;

                var source = groups[3].Value;
                var meansThis = groups[6].Value;
                
                if (groups[4].Value == "=")
                {
                    MonikerRetriever.AssociateMonikers(source, meansThis);
                }


                var noun1 = MonikerRetriever.GetMoniker(source, true);
                var noun2 = MonikerRetriever.GetMoniker(meansThis, true);

                var data = BinaryDataRetriever.StoreData("string.association", query);
                MonikerRetriever.AssociateMonikers(data, noun1, noun2);
                result.Add(data);

                return result;
            }
        }
    }
}
