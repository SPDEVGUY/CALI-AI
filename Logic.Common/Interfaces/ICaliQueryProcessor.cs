using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CALI.Database.Contracts.Data;

namespace CALI.Logic.Common.Interfaces
{
    public interface ICaliQueryProcessor
    {
        string Example { get; }
        int SortOrder { get; }
        bool Test(string query);
        List<BinaryDataContract> Run(string query);
    }
}
