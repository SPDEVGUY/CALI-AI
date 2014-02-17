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
        public delegate List<BinaryDataContract> QueryReceivedDelegate(ICaliQueryProvider source,string queryText);
        public delegate void SetDataContextDelegate(ICaliQueryProvider source,string dataType, byte[] data);
    }
    public interface ICaliQueryProvider
    {
        /// <summary>
        /// Raise this event to ask the system a query.
        /// </summary>
        event ICaliQueryProviderDelegates.QueryReceivedDelegate QueryReceived;

        /// <summary>
        /// Call this to set the data context to something (Data context used in statements like "This is bob marley" or "These are the accounts for blahblahblah"
        /// </summary>
        event ICaliQueryProviderDelegates.SetDataContextDelegate SetDataContext;
    }
}
