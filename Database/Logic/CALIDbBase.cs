using System;
using System.Data.SqlClient;

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////

namespace CALI.Database.Logic
{
    /******************************************
     * Sample Code usage
     * 
     * Wire up a handler for exceptions;
     *  CALIDb.ExceptionHandler = x => Console.WriteLine(x.Message);
     * 
     * Run a query:
     * 
     * CALIDb.ConnectThen(x => {
     *      var queryText = "SELECT cookies FROM yourMom";
     *      using (var cmd = new SqlCommand(queryText, x))
     *      {
     *         cmd.ExecuteNonQuery();
     *      }
     * });
     * 
     ******************************************/

    
    /// <summary>
    /// This class represents all the piping required to connect to CALI
    /// </summary>
    public abstract partial class CALIDbBase : DbConnectionString
    {
        //DO NOT MODIFY THIS FILE/CLASS
        //To change how the connection string works, make a partial class
        //of this class and then override the connectin string property.

        private int _defaultCommandTimeout = 30;
        public virtual int DefaultCommandTimeout
	    {
	        get { return _defaultCommandTimeout; }
	        set { _defaultCommandTimeout = value; }
	    }

        public delegate void ConnectThenDelegate(SqlConnection connection);
        public delegate void ExceptionLoggingDelegate(Exception ex);       
        
        /// <summary>
        /// The exception handler is a method that provides a way to handle exceptions
        /// </summary>
        public static ExceptionLoggingDelegate ExceptionHandler;

        /// <summary>
        /// Use this method to encapsulte a data call method.
        /// </summary>
        /// <param name="runMethod"></param>
        public virtual void InConnected(ConnectThenDelegate runMethod)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    try
                    {
                        runMethod(connection);
                    }
                    catch (Exception ex)
                    {
                        var helpfulDetails = string.Empty;
                        if(ex.Message.Contains("DataReader associated with this Command"))
                        {
                            helpfulDetails += " (hint: You probably need to specify MultipleActiveResultSets=True in your connection string.) ";
                        }

                        if (ExceptionHandler != null)
                        {
                            ExceptionHandler(new Exception("Failed to run data method (" + runMethod.Method.Name + ")." + helpfulDetails, ex));
                        } 
                        else 
                        {
                            if(helpfulDetails != string.Empty)
                            { 
                                throw new Exception(ex.Message + helpfulDetails, ex);
                            } else {
                                throw;
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                if (ExceptionHandler != null)
                {
                    ExceptionHandler(new Exception("Failed to connect to database.", ex));
                } else {
                    throw;
                }
            }
        }


        /// <summary>
        /// Use this method to run calls in a transaction.
        /// </summary>
        /// <param name="runMethod">A method that makes use of the connection and transaction objects, and returns true or false to commit or rollback the transaction.</param>
        public virtual void InTransaction(Func<SqlConnection, SqlTransaction, bool> runMethod)
        {
            InConnected(
                x =>
                {
                    var transaction = x.BeginTransaction();

                    try
                    {
                        var result = runMethod(x, transaction);

                        try
                        {
                            if (result)
                            {
                                transaction.Commit();
                            }
                            else
                            {
                                transaction.Rollback();
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Failed to rollback transaction.", ex);
                        }

                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            transaction.Rollback();
                            throw new Exception("The process has failed, but the transaction has been successfully rolled back. " + ex.Message, ex);
                        }
                        catch (Exception ex2)
                        {
                            throw new Exception("Failed to rollback transaction. " + ex2.Message, ex);
                        }
                    }
                });
        }
    }
}
