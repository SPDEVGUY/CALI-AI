using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CALI.Database.Contracts;
using CALI.Database.Contracts.Data;

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This file contains static implementations of the LogLogic
// Add your own static methods by making a new partial class.
// You cannot override static methods, instead override the methods
// located in LogLogicBase by making a partial class of LogLogic
// and overriding the base methods.

namespace CALI.Database.Logic.Data
{
	public partial class LogLogic
	{
		//Put your code in a separate file.  This is auto generated.
		/// <summary>
		/// Run Log_Insert.
		/// </summary>
		/// <param name="fldRunOnMachineName">Value for RunOnMachineName</param>
		/// <param name="fldLogContents">Value for LogContents</param>
		/// <param name="fldRunTime">Value for RunTime</param>
		public static int? InsertNow(string fldRunOnMachineName
, string fldLogContents
, DateTime fldRunTime
)
		{
			return (new LogLogic()).Insert(fldRunOnMachineName
, fldLogContents
, fldRunTime
);
		}
		/// <summary>
		/// Run Log_Insert.
		/// </summary>
		/// <param name="fldRunOnMachineName">Value for RunOnMachineName</param>
		/// <param name="fldLogContents">Value for LogContents</param>
		/// <param name="fldRunTime">Value for RunTime</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		public static int? InsertNow(string fldRunOnMachineName
, string fldLogContents
, DateTime fldRunTime
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new LogLogic()).Insert(fldRunOnMachineName
, fldLogContents
, fldRunTime
, connection, transaction);
		}

		/// <summary>
		/// Insert by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertNow(LogContract row)
		{
			return (new LogLogic()).Insert(row);
		}

		/// <summary>
		/// Insert by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertNow(LogContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new LogLogic()).Insert(row, connection, transaction);
		}

		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertAllNow(List<LogContract> rows)
		{
			return (new LogLogic()).InsertAll(rows);
		}

		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertAllNow(List<LogContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new LogLogic()).InsertAll(rows, connection, transaction);
		}
		/// <summary>
		/// Run Log_Update.
		/// </summary>
		/// <param name="fldLogId">Value for LogId</param>
		/// <param name="fldRunOnMachineName">Value for RunOnMachineName</param>
		/// <param name="fldLogContents">Value for LogContents</param>
		/// <param name="fldRunTime">Value for RunTime</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(int fldLogId
, string fldRunOnMachineName
, string fldLogContents
, DateTime fldRunTime
)
		{
			return (new LogLogic()).Update(fldLogId
, fldRunOnMachineName
, fldLogContents
, fldRunTime
);
		}

		/// <summary>
		/// Run Log_Update.
		/// </summary>
		/// <param name="fldLogId">Value for LogId</param>
		/// <param name="fldRunOnMachineName">Value for RunOnMachineName</param>
		/// <param name="fldLogContents">Value for LogContents</param>
		/// <param name="fldRunTime">Value for RunTime</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(int fldLogId
, string fldRunOnMachineName
, string fldLogContents
, DateTime fldRunTime
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new LogLogic()).Update(fldLogId
, fldRunOnMachineName
, fldLogContents
, fldRunTime
, connection, transaction);
		}
		/// <summary>
		/// Update by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(LogContract row)
		{
			return (new LogLogic()).Update(row);
		}

		/// <summary>
		/// Update by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(LogContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new LogLogic()).Update(row, connection, transaction);
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateAllNow(List<LogContract> rows)
		{
			return (new LogLogic()).UpdateAll(rows);
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateAllNow(List<LogContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new LogLogic()).UpdateAll(rows, connection, transaction);
		}
		/// <summary>
		/// Run Log_Delete.
		/// </summary>
		/// <param name="fldLogId">Value for LogId</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(int fldLogId
)
		{
			return (new LogLogic()).Delete(fldLogId
);
		}

		/// <summary>
		/// Run Log_Delete.
		/// </summary>
		/// <param name="fldLogId">Value for LogId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(int fldLogId
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new LogLogic()).Delete(fldLogId
, connection, transaction);
		}
		/// <summary>
		/// Delete by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(LogContract row)
		{
			return (new LogLogic()).Delete(row);
		}

		/// <summary>
		/// Delete by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(LogContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new LogLogic()).Delete(row, connection, transaction);
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteAllNow(List<LogContract> rows)
		{
			return (new LogLogic()).DeleteAll(rows);
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteAllNow(List<LogContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new LogLogic()).DeleteAll(rows, connection, transaction);
		}
		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldLogId">Value for LogId</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldLogId
)
		{
			return (new LogLogic()).Exists(fldLogId
);
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldLogId">Value for LogId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldLogId
, SqlConnection connection, SqlTransaction transaction)
		{					
			return (new LogLogic()).Exists(fldLogId
, connection, transaction);
		}

		/// <summary>
		/// Run Log_Search, and return results as a list of LogRow.
		/// </summary>
		/// <param name="fldRunOnMachineName">Value for RunOnMachineName</param>
		/// <param name="fldLogContents">Value for LogContents</param>
		/// <returns>A collection of LogRow.</returns>
		public static List<LogContract> SearchNow(string fldRunOnMachineName
, string fldLogContents
)
		{
			var driver = new LogLogic();
			driver.Search(fldRunOnMachineName
, fldLogContents
);
			return driver.Results;
		}

		/// <summary>
		/// Run Log_Search, and return results as a list of LogRow.
		/// </summary>
		/// <param name="fldRunOnMachineName">Value for RunOnMachineName</param>
		/// <param name="fldLogContents">Value for LogContents</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of LogRow.</returns>
		public static List<LogContract> SearchNow(string fldRunOnMachineName
, string fldLogContents
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new LogLogic();
			driver.Search(fldRunOnMachineName
, fldLogContents
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run Log_SelectAll, and return results as a list of LogRow.
		/// </summary>

		/// <returns>A collection of LogRow.</returns>
		public static List<LogContract> SelectAllNow()
		{			
			var driver = new LogLogic();
			driver.SelectAll();
			return driver.Results;
		}

		/// <summary>
		/// Run Log_SelectAll, and return results as a list of LogRow.
		/// </summary>

		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of LogRow.</returns>
		public static List<LogContract> SelectAllNow(SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new LogLogic();
			driver.SelectAll(connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run Log_SelectBy_LogId, and return results as a list of LogRow.
		/// </summary>
		/// <param name="fldLogId">Value for LogId</param>
		/// <returns>A collection of LogRow.</returns>
		public static List<LogContract> SelectBy_LogIdNow(int fldLogId
)
		{
			var driver = new LogLogic();
			driver.SelectBy_LogId(fldLogId
);
			return driver.Results;
		}

		/// <summary>
		/// Run Log_SelectBy_LogId, and return results as a list of LogRow.
		/// </summary>
		/// <param name="fldLogId">Value for LogId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of LogRow.</returns>
		public static List<LogContract> SelectBy_LogIdNow(int fldLogId
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new LogLogic();
			driver.SelectBy_LogId(fldLogId
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Read all Log rows from the provided reader into the list structure of LogRows
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>
		/// <returns>A populated LogRows or an empty LogRows if there are no results.</returns>
		public static List<LogContract> ReadAllNow(SqlDataReader reader)
		{
			var driver = new LogLogic();

			driver.ReadAll(reader);
			
			return driver.Results;
		}
		/// <summary>");
		/// Advance one, and read values into a Log
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>");
		/// <returns>A Log or null if there are no results.</returns>
		public static LogContract ReadOneNow(SqlDataReader reader)
		{
			var driver = new LogLogic();			
		    return driver.ReadOne(reader) ? driver.Results[0] : null;
		}
		/// <summary>
		/// Saves the row, either by inserting (when the identity key is null) or by updating (identity key has value).
		/// </summary>
		/// <param name="row">The data to save</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveNow(LogContract row)
		{
			if(row.LogId == null)
			{
				return InsertNow(row);
			}
			else
			{
				return UpdateNow(row);
			}
		}
		
		/// <summary>
		/// Saves the row, either by inserting (when the identity key is null) or by updating (identity key has value).
		/// </summary>
		/// <param name="row">The data to save</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveNow(LogContract row, SqlConnection connection, SqlTransaction transaction)
		{
			if(row.LogId == null)
			{
				return InsertNow(row, connection, transaction);
			}
			else
			{
				return UpdateNow(row, connection, transaction);
			}
		}
		
		/// <summary>
		/// Save the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Save</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveAllNow(List<LogContract> rows)
		{
			return (new LogLogic()).SaveAll(rows);
		}

		/// <summary>
		/// Save the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Save</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveAllNow(List<LogContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new LogLogic()).SaveAll(rows, connection, transaction);
		}        
	}
}