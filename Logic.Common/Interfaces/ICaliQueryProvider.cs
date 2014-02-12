using CALI.Database.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALI.Logic.Common.Interfaces
{
    public static class ICaliQueryProviderDelegates
    {
        public delegate List<BinaryDataContract> QueryReceivedDelegate(string queryText);
    }
    public interface ICaliQueryProvider
    {
        event ICaliQueryProviderDelegates.QueryReceivedDelegate QueryReceived;
    }
}
