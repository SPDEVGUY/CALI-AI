using System;
using System.Configuration; //NOTE: Requires reference to System.Configuration for ConfigurationManager

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////

namespace CALI.Database.Logic
{

    /// <summary>
    /// This class provides the connection string to the Database connection controller class
    /// </summary>
    public abstract partial class DbConnectionStringBase
    {
        //DO NOT MODIFY THIS FILE/CLASS, Instead use partial class.

        public virtual string ConnectionStringKey { get { return "CALIConnectionString"; } }

        public virtual string ConnectionString
        {
            get
            {
                var connectionString = ConfigurationManager.ConnectionStrings[ConnectionStringKey];
                if (connectionString == null)
                    throw new Exception("You have not defined a connection string by the name of '" +
                                        ConnectionStringKey + "'.");
                return connectionString.ConnectionString;
            }
        }
    }
}
