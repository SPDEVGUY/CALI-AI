using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CALI.Database.Contracts;
using CALI.Database.Contracts.Data;

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This file contains static implementations of the QueryLogic
// Add your own static methods by making a new partial class.
// You cannot override static methods, instead override the methods
// located in QueryLogicBase by making a partial class of QueryLogic
// and overriding the base methods.

namespace CALI.Database.Logic.Data
{
	public partial class QueryLogic
	{
		//Put your code in a separate file.  This is auto generated.
		/// <summary>
		/// Run Query_Insert.
		/// </summary>
		/// <param name="fldText">Value for Text</param>
		/// <param name="fldPoviderSource">Value for PoviderSource</param>
		/// <param name="fldProcessorUsed">Value for ProcessorUsed</param>
		/// <param name="fldExceptions">Value for Exceptions</param>
		/// <param name="fldIsSuccess">Value for IsSuccess</param>
		public static int? InsertNow(string fldText
, string fldPoviderSource
, string fldProcessorUsed
, string fldExceptions
, bool fldIsSuccess
)
		{
			return (new QueryLogic()).Insert(fldText
, fldPoviderSource
, fldProcessorUsed
, fldExceptions
, fldIsSuccess
);
		}
		/// <summary>
		/// Run Query_Insert.
		/// </summary>
		/// <param name="fldText">Value for Text</param>
		/// <param name="fldPoviderSource">Value for PoviderSource</param>
		/// <param name="fldProcessorUsed">Value for ProcessorUsed</param>
		/// <param name="fldExceptions">Value for Exceptions</param>
		/// <param name="fldIsSuccess">Value for IsSuccess</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		public static int? InsertNow(string fldText
, string fldPoviderSource
, string fldProcessorUsed
, string fldExceptions
, bool fldIsSuccess
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new QueryLogic()).Insert(fldText
, fldPoviderSource
, fldProcessorUsed
, fldExceptions
, fldIsSuccess
, connection, transaction);
		}

		/// <summary>
		/// Insert by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertNow(QueryContract row)
		{
			return (new QueryLogic()).Insert(row);
		}

		/// <summary>
		/// Insert by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertNow(QueryContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new QueryLogic()).Insert(row, connection, transaction);
		}

		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertAllNow(List<QueryContract> rows)
		{
			return (new QueryLogic()).InsertAll(rows);
		}

		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertAllNow(List<QueryContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new QueryLogic()).InsertAll(rows, connection, transaction);
		}
		/// <summary>
		/// Run Query_Update.
		/// </summary>
		/// <param name="fldQueryId">Value for QueryId</param>
		/// <param name="fldText">Value for Text</param>
		/// <param name="fldPoviderSource">Value for PoviderSource</param>
		/// <param name="fldProcessorUsed">Value for ProcessorUsed</param>
		/// <param name="fldExceptions">Value for Exceptions</param>
		/// <param name="fldIsSuccess">Value for IsSuccess</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(int fldQueryId
, string fldText
, string fldPoviderSource
, string fldProcessorUsed
, string fldExceptions
, bool fldIsSuccess
)
		{
			return (new QueryLogic()).Update(fldQueryId
, fldText
, fldPoviderSource
, fldProcessorUsed
, fldExceptions
, fldIsSuccess
);
		}

		/// <summary>
		/// Run Query_Update.
		/// </summary>
		/// <param name="fldQueryId">Value for QueryId</param>
		/// <param name="fldText">Value for Text</param>
		/// <param name="fldPoviderSource">Value for PoviderSource</param>
		/// <param name="fldProcessorUsed">Value for ProcessorUsed</param>
		/// <param name="fldExceptions">Value for Exceptions</param>
		/// <param name="fldIsSuccess">Value for IsSuccess</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(int fldQueryId
, string fldText
, string fldPoviderSource
, string fldProcessorUsed
, string fldExceptions
, bool fldIsSuccess
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new QueryLogic()).Update(fldQueryId
, fldText
, fldPoviderSource
, fldProcessorUsed
, fldExceptions
, fldIsSuccess
, connection, transaction);
		}
		/// <summary>
		/// Update by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(QueryContract row)
		{
			return (new QueryLogic()).Update(row);
		}

		/// <summary>
		/// Update by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(QueryContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new QueryLogic()).Update(row, connection, transaction);
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateAllNow(List<QueryContract> rows)
		{
			return (new QueryLogic()).UpdateAll(rows);
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateAllNow(List<QueryContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new QueryLogic()).UpdateAll(rows, connection, transaction);
		}
		/// <summary>
		/// Run Query_Delete.
		/// </summary>
		/// <param name="fldQueryId">Value for QueryId</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(int fldQueryId
)
		{
			return (new QueryLogic()).Delete(fldQueryId
);
		}

		/// <summary>
		/// Run Query_Delete.
		/// </summary>
		/// <param name="fldQueryId">Value for QueryId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(int fldQueryId
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new QueryLogic()).Delete(fldQueryId
, connection, transaction);
		}
		/// <summary>
		/// Delete by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(QueryContract row)
		{
			return (new QueryLogic()).Delete(row);
		}

		/// <summary>
		/// Delete by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(QueryContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new QueryLogic()).Delete(row, connection, transaction);
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteAllNow(List<QueryContract> rows)
		{
			return (new QueryLogic()).DeleteAll(rows);
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteAllNow(List<QueryContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new QueryLogic()).DeleteAll(rows, connection, transaction);
		}
		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldQueryId">Value for QueryId</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldQueryId
)
		{
			return (new QueryLogic()).Exists(fldQueryId
);
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldQueryId">Value for QueryId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldQueryId
, SqlConnection connection, SqlTransaction transaction)
		{					
			return (new QueryLogic()).Exists(fldQueryId
, connection, transaction);
		}

		/// <summary>
		/// Run Query_Search, and return results as a list of QueryRow.
		/// </summary>
		/// <param name="fldText">Value for Text</param>
		/// <param name="fldPoviderSource">Value for PoviderSource</param>
		/// <param name="fldProcessorUsed">Value for ProcessorUsed</param>
		/// <param name="fldExceptions">Value for Exceptions</param>
		/// <returns>A collection of QueryRow.</returns>
		public static List<QueryContract> SearchNow(string fldText
, string fldPoviderSource
, string fldProcessorUsed
, string fldExceptions
)
		{
			var driver = new QueryLogic();
			driver.Search(fldText
, fldPoviderSource
, fldProcessorUsed
, fldExceptions
);
			return driver.Results;
		}

		/// <summary>
		/// Run Query_Search, and return results as a list of QueryRow.
		/// </summary>
		/// <param name="fldText">Value for Text</param>
		/// <param name="fldPoviderSource">Value for PoviderSource</param>
		/// <param name="fldProcessorUsed">Value for ProcessorUsed</param>
		/// <param name="fldExceptions">Value for Exceptions</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of QueryRow.</returns>
		public static List<QueryContract> SearchNow(string fldText
, string fldPoviderSource
, string fldProcessorUsed
, string fldExceptions
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new QueryLogic();
			driver.Search(fldText
, fldPoviderSource
, fldProcessorUsed
, fldExceptions
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run Query_SelectAll, and return results as a list of QueryRow.
		/// </summary>

		/// <returns>A collection of QueryRow.</returns>
		public static List<QueryContract> SelectAllNow()
		{			
			var driver = new QueryLogic();
			driver.SelectAll();
			return driver.Results;
		}

		/// <summary>
		/// Run Query_SelectAll, and return results as a list of QueryRow.
		/// </summary>

		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of QueryRow.</returns>
		public static List<QueryContract> SelectAllNow(SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new QueryLogic();
			driver.SelectAll(connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run Query_SelectBy_QueryId, and return results as a list of QueryRow.
		/// </summary>
		/// <param name="fldQueryId">Value for QueryId</param>
		/// <returns>A collection of QueryRow.</returns>
		public static List<QueryContract> SelectBy_QueryIdNow(int fldQueryId
)
		{
			var driver = new QueryLogic();
			driver.SelectBy_QueryId(fldQueryId
);
			return driver.Results;
		}

		/// <summary>
		/// Run Query_SelectBy_QueryId, and return results as a list of QueryRow.
		/// </summary>
		/// <param name="fldQueryId">Value for QueryId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of QueryRow.</returns>
		public static List<QueryContract> SelectBy_QueryIdNow(int fldQueryId
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new QueryLogic();
			driver.SelectBy_QueryId(fldQueryId
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Read all Query rows from the provided reader into the list structure of QueryRows
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>
		/// <returns>A populated QueryRows or an empty QueryRows if there are no results.</returns>
		public static List<QueryContract> ReadAllNow(SqlDataReader reader)
		{
			var driver = new QueryLogic();

			driver.ReadAll(reader);
			
			return driver.Results;
		}
		/// <summary>");
		/// Advance one, and read values into a Query
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>");
		/// <returns>A Query or null if there are no results.</returns>
		public static QueryContract ReadOneNow(SqlDataReader reader)
		{
			var driver = new QueryLogic();			
		    return driver.ReadOne(reader) ? driver.Results[0] : null;
		}
		/// <summary>
		/// Saves the row, either by inserting (when the identity key is null) or by updating (identity key has value).
		/// </summary>
		/// <param name="row">The data to save</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveNow(QueryContract row)
		{
			if(row.QueryId == null)
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
		public static int SaveNow(QueryContract row, SqlConnection connection, SqlTransaction transaction)
		{
			if(row.QueryId == null)
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
		public static int SaveAllNow(List<QueryContract> rows)
		{
			return (new QueryLogic()).SaveAll(rows);
		}

		/// <summary>
		/// Save the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Save</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveAllNow(List<QueryContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new QueryLogic()).SaveAll(rows, connection, transaction);
		}        
	}
}