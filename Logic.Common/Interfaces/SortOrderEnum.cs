using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALI.Logic.Common.Interfaces
{
    public enum SortOrderEnum
    {
        SpecificQuery = 1,
        GeneralQuery = 5,
        SpecificStatement=10,
        GeneralStatement=15,
        CatchAll=100
    }
}
