using CALI.Database.Contracts.Data;
using CALI.Database.Logic;
using CALI.Database.Logic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALI.Logic.Common.Util
{
    public class QueryRetriever
    {
        public static QueryContract GetQuery(string text)
        {
            var query = new QueryContract
                               {
                                   Text = text,
                                   IsSuccess = false
                               };
            QueryLogic.SaveNow(query);
            return query;
        }
    }
}
