using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CALI.Database.Contracts;
using CALI.Database.Contracts.Auth;

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This file contains static implementations of the PermissionLogic
// Add your own static methods by making a new partial class.
// You cannot override static methods, instead override the methods
// located in PermissionLogicBase by making a partial class of PermissionLogic
// and overriding the base methods.

namespace CALI.Database.Logic.Auth
{
	public partial class PermissionLogic
	{
		//Put your code in a separate file.  This is auto generated.
		/// <summary>
		/// Run Permission_SelectBy_UserId, and return results as a list of PermissionRow.
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <returns>A collection of PermissionRow.</returns>
		public static List<PermissionContract> SelectBy_UserIdNow(int fldUserId
)
		{
			var driver = new PermissionLogic();
			driver.SelectBy_UserId(fldUserId
);
			return driver.Results;
		}

		/// <summary>
		/// Run Permission_SelectBy_UserId, and return results as a list of PermissionRow.
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of PermissionRow.</returns>
		public static List<PermissionContract> SelectBy_UserIdNow(int fldUserId
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new PermissionLogic();
			driver.SelectBy_UserId(fldUserId
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run Permission_Insert.
		/// </summary>
		/// <param name="fldPermissionName">Value for PermissionName</param>
		/// <param name="fldTitle">Value for Title</param>
		/// <param name="fldIsRead">Value for IsRead</param>
		public static int? InsertNow(string fldPermissionName
, string fldTitle
, bool fldIsRead
)
		{
			return (new PermissionLogic()).Insert(fldPermissionName
, fldTitle
, fldIsRead
);
		}
		/// <summary>
		/// Run Permission_Insert.
		/// </summary>
		/// <param name="fldPermissionName">Value for PermissionName</param>
		/// <param name="fldTitle">Value for Title</param>
		/// <param name="fldIsRead">Value for IsRead</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		public static int? InsertNow(string fldPermissionName
, string fldTitle
, bool fldIsRead
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new PermissionLogic()).Insert(fldPermissionName
, fldTitle
, fldIsRead
, connection, transaction);
		}

		/// <summary>
		/// Insert by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertNow(PermissionContract row)
		{
			return (new PermissionLogic()).Insert(row);
		}

		/// <summary>
		/// Insert by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertNow(PermissionContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new PermissionLogic()).Insert(row, connection, transaction);
		}

		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertAllNow(List<PermissionContract> rows)
		{
			return (new PermissionLogic()).InsertAll(rows);
		}

		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertAllNow(List<PermissionContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new PermissionLogic()).InsertAll(rows, connection, transaction);
		}
		/// <summary>
		/// Run Permission_Update.
		/// </summary>
		/// <param name="fldPermissionId">Value for PermissionId</param>
		/// <param name="fldPermissionName">Value for PermissionName</param>
		/// <param name="fldTitle">Value for Title</param>
		/// <param name="fldIsRead">Value for IsRead</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(int fldPermissionId
, string fldPermissionName
, string fldTitle
, bool fldIsRead
)
		{
			return (new PermissionLogic()).Update(fldPermissionId
, fldPermissionName
, fldTitle
, fldIsRead
);
		}

		/// <summary>
		/// Run Permission_Update.
		/// </summary>
		/// <param name="fldPermissionId">Value for PermissionId</param>
		/// <param name="fldPermissionName">Value for PermissionName</param>
		/// <param name="fldTitle">Value for Title</param>
		/// <param name="fldIsRead">Value for IsRead</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(int fldPermissionId
, string fldPermissionName
, string fldTitle
, bool fldIsRead
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new PermissionLogic()).Update(fldPermissionId
, fldPermissionName
, fldTitle
, fldIsRead
, connection, transaction);
		}
		/// <summary>
		/// Update by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(PermissionContract row)
		{
			return (new PermissionLogic()).Update(row);
		}

		/// <summary>
		/// Update by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(PermissionContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new PermissionLogic()).Update(row, connection, transaction);
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateAllNow(List<PermissionContract> rows)
		{
			return (new PermissionLogic()).UpdateAll(rows);
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateAllNow(List<PermissionContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new PermissionLogic()).UpdateAll(rows, connection, transaction);
		}
		/// <summary>
		/// Run Permission_Delete.
		/// </summary>
		/// <param name="fldPermissionId">Value for PermissionId</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(int fldPermissionId
)
		{
			return (new PermissionLogic()).Delete(fldPermissionId
);
		}

		/// <summary>
		/// Run Permission_Delete.
		/// </summary>
		/// <param name="fldPermissionId">Value for PermissionId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(int fldPermissionId
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new PermissionLogic()).Delete(fldPermissionId
, connection, transaction);
		}
		/// <summary>
		/// Delete by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(PermissionContract row)
		{
			return (new PermissionLogic()).Delete(row);
		}

		/// <summary>
		/// Delete by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(PermissionContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new PermissionLogic()).Delete(row, connection, transaction);
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteAllNow(List<PermissionContract> rows)
		{
			return (new PermissionLogic()).DeleteAll(rows);
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteAllNow(List<PermissionContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new PermissionLogic()).DeleteAll(rows, connection, transaction);
		}
		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldPermissionId">Value for PermissionId</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldPermissionId
)
		{
			return (new PermissionLogic()).Exists(fldPermissionId
);
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldPermissionId">Value for PermissionId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldPermissionId
, SqlConnection connection, SqlTransaction transaction)
		{					
			return (new PermissionLogic()).Exists(fldPermissionId
, connection, transaction);
		}

		/// <summary>
		/// Run Permission_Search, and return results as a list of PermissionRow.
		/// </summary>
		/// <param name="fldPermissionName">Value for PermissionName</param>
		/// <param name="fldTitle">Value for Title</param>
		/// <returns>A collection of PermissionRow.</returns>
		public static List<PermissionContract> SearchNow(string fldPermissionName
, string fldTitle
)
		{
			var driver = new PermissionLogic();
			driver.Search(fldPermissionName
, fldTitle
);
			return driver.Results;
		}

		/// <summary>
		/// Run Permission_Search, and return results as a list of PermissionRow.
		/// </summary>
		/// <param name="fldPermissionName">Value for PermissionName</param>
		/// <param name="fldTitle">Value for Title</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of PermissionRow.</returns>
		public static List<PermissionContract> SearchNow(string fldPermissionName
, string fldTitle
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new PermissionLogic();
			driver.Search(fldPermissionName
, fldTitle
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run Permission_SelectAll, and return results as a list of PermissionRow.
		/// </summary>

		/// <returns>A collection of PermissionRow.</returns>
		public static List<PermissionContract> SelectAllNow()
		{			
			var driver = new PermissionLogic();
			driver.SelectAll();
			return driver.Results;
		}

		/// <summary>
		/// Run Permission_SelectAll, and return results as a list of PermissionRow.
		/// </summary>

		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of PermissionRow.</returns>
		public static List<PermissionContract> SelectAllNow(SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new PermissionLogic();
			driver.SelectAll(connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run Permission_List, and return results as a list.
		/// </summary>
		/// <param name="fldTitle">Value for Title</param>
		/// <returns>A collection of __ListItemRow.</returns>
		public static List<ListItemContract> ListNow(string fldTitle
)
		{
			return (new PermissionLogic()).List(fldTitle
);
		}

		/// <summary>
		/// Run Permission_List, and return results as a list.
		/// </summary>
		/// <param name="fldTitle">Value for Title</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of __ListItemRow.</returns>
		public static List<ListItemContract> ListNow(string fldTitle
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new PermissionLogic()).List(fldTitle
, connection, transaction);
		}

		/// <summary>
		/// Run Permission_SelectBy_PermissionId, and return results as a list of PermissionRow.
		/// </summary>
		/// <param name="fldPermissionId">Value for PermissionId</param>
		/// <returns>A collection of PermissionRow.</returns>
		public static List<PermissionContract> SelectBy_PermissionIdNow(int fldPermissionId
)
		{
			var driver = new PermissionLogic();
			driver.SelectBy_PermissionId(fldPermissionId
);
			return driver.Results;
		}

		/// <summary>
		/// Run Permission_SelectBy_PermissionId, and return results as a list of PermissionRow.
		/// </summary>
		/// <param name="fldPermissionId">Value for PermissionId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of PermissionRow.</returns>
		public static List<PermissionContract> SelectBy_PermissionIdNow(int fldPermissionId
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new PermissionLogic();
			driver.SelectBy_PermissionId(fldPermissionId
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Read all Permission rows from the provided reader into the list structure of PermissionRows
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>
		/// <returns>A populated PermissionRows or an empty PermissionRows if there are no results.</returns>
		public static List<PermissionContract> ReadAllNow(SqlDataReader reader)
		{
			var driver = new PermissionLogic();

			driver.ReadAll(reader);
			
			return driver.Results;
		}
		/// <summary>");
		/// Advance one, and read values into a Permission
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>");
		/// <returns>A Permission or null if there are no results.</returns>
		public static PermissionContract ReadOneNow(SqlDataReader reader)
		{
			var driver = new PermissionLogic();			
		    return driver.ReadOne(reader) ? driver.Results[0] : null;
		}
		/// <summary>
		/// Saves the row, either by inserting (when the identity key is null) or by updating (identity key has value).
		/// </summary>
		/// <param name="row">The data to save</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveNow(PermissionContract row)
		{
			if(row.PermissionId == null)
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
		public static int SaveNow(PermissionContract row, SqlConnection connection, SqlTransaction transaction)
		{
			if(row.PermissionId == null)
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
		public static int SaveAllNow(List<PermissionContract> rows)
		{
			return (new PermissionLogic()).SaveAll(rows);
		}

		/// <summary>
		/// Save the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Save</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveAllNow(List<PermissionContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new PermissionLogic()).SaveAll(rows, connection, transaction);
		}        
	}
}