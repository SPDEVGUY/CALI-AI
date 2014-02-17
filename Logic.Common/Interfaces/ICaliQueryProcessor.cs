using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CALI.Database.Contracts.Data;

namespace CALI.Logic.Common.Interfaces
{
    public interface ICaliQueryProcessor
    {
        QueryRouter Router { get; set; }
        string[] Examples { get; }
        SortOrderEnum SortOrder { get; }
        Regex Tester { get; }
        List<BinaryDataContract> Process(string query, MatchCollection match);
    }
}
