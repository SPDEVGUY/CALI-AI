///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////

using System;
using System.Data.SqlClient;

namespace CALI.Database.Logic
{
    /// <summary>
    /// This class represents all the piping required to connect to CALI
    /// </summary>
    public partial class CALIDb : CALIDbBase
    {
        //DO NOT MODIFY THIS FILE/CLASS        
    
    
        private static CALIDb _singleton;
        public static CALIDb Singleton
	    {
	        get { return _singleton = _singleton ?? new CALIDb(); }
	    }
        
        
        /// <summary>
        /// Run a series of commands after connecting to the db.
        /// </summary>
        /// <param name="runMethod">A delegate method that runs your logic commands.</param>
        public static void ConnectThen(ConnectThenDelegate runMethod)
        {
            var db = new CALIDb();
            db.InConnected(runMethod);
        }


        /// <summary>
        /// Run a series of commands in a transactional scope
        /// </summary>
        /// <param name="runMethod">A method that returns true to commit the transaction after running various logic methods.</param>
        public static void Transactional(Func<SqlConnection, SqlTransaction, bool> runMethod)
        {
            var db = new CALIDb();
            db.InTransaction(runMethod);
        }
    }
}
