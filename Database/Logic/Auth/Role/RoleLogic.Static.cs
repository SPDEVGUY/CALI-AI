using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CALI.Database.Contracts;
using CALI.Database.Contracts.Auth;

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This file contains static implementations of the RoleLogic
// Add your own static methods by making a new partial class.
// You cannot override static methods, instead override the methods
// located in RoleLogicBase by making a partial class of RoleLogic
// and overriding the base methods.

namespace CALI.Database.Logic.Auth
{
	public partial class RoleLogic
	{
		//Put your code in a separate file.  This is auto generated.
		/// <summary>
		/// Run Role_Insert.
		/// </summary>
		/// <param name="fldTitle">Value for Title</param>
		/// <param name="fldDescription">Value for Description</param>
		/// <param name="fldIsActive">Value for IsActive</param>
		/// <param name="fldApplyToAnon">Value for ApplyToAnon</param>
		/// <param name="fldApplyToAllUsers">Value for ApplyToAllUsers</param>
		/// <param name="fldPreventAddingUsers">Value for PreventAddingUsers</param>
		/// <param name="fldWINSID">Value for WINSID</param>
		public static int? InsertNow(string fldTitle
, string fldDescription
, bool fldIsActive
, bool fldApplyToAnon
, bool fldApplyToAllUsers
, bool fldPreventAddingUsers
, string fldWINSID
)
		{
			return (new RoleLogic()).Insert(fldTitle
, fldDescription
, fldIsActive
, fldApplyToAnon
, fldApplyToAllUsers
, fldPreventAddingUsers
, fldWINSID
);
		}
		/// <summary>
		/// Run Role_Insert.
		/// </summary>
		/// <param name="fldTitle">Value for Title</param>
		/// <param name="fldDescription">Value for Description</param>
		/// <param name="fldIsActive">Value for IsActive</param>
		/// <param name="fldApplyToAnon">Value for ApplyToAnon</param>
		/// <param name="fldApplyToAllUsers">Value for ApplyToAllUsers</param>
		/// <param name="fldPreventAddingUsers">Value for PreventAddingUsers</param>
		/// <param name="fldWINSID">Value for WINSID</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		public static int? InsertNow(string fldTitle
, string fldDescription
, bool fldIsActive
, bool fldApplyToAnon
, bool fldApplyToAllUsers
, bool fldPreventAddingUsers
, string fldWINSID
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new RoleLogic()).Insert(fldTitle
, fldDescription
, fldIsActive
, fldApplyToAnon
, fldApplyToAllUsers
, fldPreventAddingUsers
, fldWINSID
, connection, transaction);
		}

		/// <summary>
		/// Insert by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertNow(RoleContract row)
		{
			return (new RoleLogic()).Insert(row);
		}

		/// <summary>
		/// Insert by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertNow(RoleContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new RoleLogic()).Insert(row, connection, transaction);
		}

		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertAllNow(List<RoleContract> rows)
		{
			return (new RoleLogic()).InsertAll(rows);
		}

		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertAllNow(List<RoleContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new RoleLogic()).InsertAll(rows, connection, transaction);
		}
		/// <summary>
		/// Run Role_Update.
		/// </summary>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <param name="fldTitle">Value for Title</param>
		/// <param name="fldDescription">Value for Description</param>
		/// <param name="fldIsActive">Value for IsActive</param>
		/// <param name="fldApplyToAnon">Value for ApplyToAnon</param>
		/// <param name="fldApplyToAllUsers">Value for ApplyToAllUsers</param>
		/// <param name="fldPreventAddingUsers">Value for PreventAddingUsers</param>
		/// <param name="fldWINSID">Value for WINSID</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(int fldRoleId
, string fldTitle
, string fldDescription
, bool fldIsActive
, bool fldApplyToAnon
, bool fldApplyToAllUsers
, bool fldPreventAddingUsers
, string fldWINSID
)
		{
			return (new RoleLogic()).Update(fldRoleId
, fldTitle
, fldDescription
, fldIsActive
, fldApplyToAnon
, fldApplyToAllUsers
, fldPreventAddingUsers
, fldWINSID
);
		}

		/// <summary>
		/// Run Role_Update.
		/// </summary>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <param name="fldTitle">Value for Title</param>
		/// <param name="fldDescription">Value for Description</param>
		/// <param name="fldIsActive">Value for IsActive</param>
		/// <param name="fldApplyToAnon">Value for ApplyToAnon</param>
		/// <param name="fldApplyToAllUsers">Value for ApplyToAllUsers</param>
		/// <param name="fldPreventAddingUsers">Value for PreventAddingUsers</param>
		/// <param name="fldWINSID">Value for WINSID</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(int fldRoleId
, string fldTitle
, string fldDescription
, bool fldIsActive
, bool fldApplyToAnon
, bool fldApplyToAllUsers
, bool fldPreventAddingUsers
, string fldWINSID
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new RoleLogic()).Update(fldRoleId
, fldTitle
, fldDescription
, fldIsActive
, fldApplyToAnon
, fldApplyToAllUsers
, fldPreventAddingUsers
, fldWINSID
, connection, transaction);
		}
		/// <summary>
		/// Update by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(RoleContract row)
		{
			return (new RoleLogic()).Update(row);
		}

		/// <summary>
		/// Update by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(RoleContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new RoleLogic()).Update(row, connection, transaction);
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateAllNow(List<RoleContract> rows)
		{
			return (new RoleLogic()).UpdateAll(rows);
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateAllNow(List<RoleContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new RoleLogic()).UpdateAll(rows, connection, transaction);
		}
		/// <summary>
		/// Run Role_Delete.
		/// </summary>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(int fldRoleId
)
		{
			return (new RoleLogic()).Delete(fldRoleId
);
		}

		/// <summary>
		/// Run Role_Delete.
		/// </summary>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(int fldRoleId
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new RoleLogic()).Delete(fldRoleId
, connection, transaction);
		}
		/// <summary>
		/// Delete by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(RoleContract row)
		{
			return (new RoleLogic()).Delete(row);
		}

		/// <summary>
		/// Delete by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(RoleContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new RoleLogic()).Delete(row, connection, transaction);
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteAllNow(List<RoleContract> rows)
		{
			return (new RoleLogic()).DeleteAll(rows);
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteAllNow(List<RoleContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new RoleLogic()).DeleteAll(rows, connection, transaction);
		}
		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldRoleId
)
		{
			return (new RoleLogic()).Exists(fldRoleId
);
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldRoleId
, SqlConnection connection, SqlTransaction transaction)
		{					
			return (new RoleLogic()).Exists(fldRoleId
, connection, transaction);
		}

		/// <summary>
		/// Run Role_Search, and return results as a list of RoleRow.
		/// </summary>
		/// <param name="fldTitle">Value for Title</param>
		/// <param name="fldDescription">Value for Description</param>
		/// <param name="fldWINSID">Value for WINSID</param>
		/// <returns>A collection of RoleRow.</returns>
		public static List<RoleContract> SearchNow(string fldTitle
, string fldDescription
, string fldWINSID
)
		{
			var driver = new RoleLogic();
			driver.Search(fldTitle
, fldDescription
, fldWINSID
);
			return driver.Results;
		}

		/// <summary>
		/// Run Role_Search, and return results as a list of RoleRow.
		/// </summary>
		/// <param name="fldTitle">Value for Title</param>
		/// <param name="fldDescription">Value for Description</param>
		/// <param name="fldWINSID">Value for WINSID</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of RoleRow.</returns>
		public static List<RoleContract> SearchNow(string fldTitle
, string fldDescription
, string fldWINSID
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new RoleLogic();
			driver.Search(fldTitle
, fldDescription
, fldWINSID
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run Role_SelectAll, and return results as a list of RoleRow.
		/// </summary>

		/// <returns>A collection of RoleRow.</returns>
		public static List<RoleContract> SelectAllNow()
		{			
			var driver = new RoleLogic();
			driver.SelectAll();
			return driver.Results;
		}

		/// <summary>
		/// Run Role_SelectAll, and return results as a list of RoleRow.
		/// </summary>

		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of RoleRow.</returns>
		public static List<RoleContract> SelectAllNow(SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new RoleLogic();
			driver.SelectAll(connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run Role_List, and return results as a list.
		/// </summary>
		/// <param name="fldTitle">Value for Title</param>
		/// <returns>A collection of __ListItemRow.</returns>
		public static List<ListItemContract> ListNow(string fldTitle
)
		{
			return (new RoleLogic()).List(fldTitle
);
		}

		/// <summary>
		/// Run Role_List, and return results as a list.
		/// </summary>
		/// <param name="fldTitle">Value for Title</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of __ListItemRow.</returns>
		public static List<ListItemContract> ListNow(string fldTitle
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new RoleLogic()).List(fldTitle
, connection, transaction);
		}

		/// <summary>
		/// Run Role_SelectBy_RoleId, and return results as a list of RoleRow.
		/// </summary>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <returns>A collection of RoleRow.</returns>
		public static List<RoleContract> SelectBy_RoleIdNow(int fldRoleId
)
		{
			var driver = new RoleLogic();
			driver.SelectBy_RoleId(fldRoleId
);
			return driver.Results;
		}

		/// <summary>
		/// Run Role_SelectBy_RoleId, and return results as a list of RoleRow.
		/// </summary>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of RoleRow.</returns>
		public static List<RoleContract> SelectBy_RoleIdNow(int fldRoleId
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new RoleLogic();
			driver.SelectBy_RoleId(fldRoleId
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Read all Role rows from the provided reader into the list structure of RoleRows
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>
		/// <returns>A populated RoleRows or an empty RoleRows if there are no results.</returns>
		public static List<RoleContract> ReadAllNow(SqlDataReader reader)
		{
			var driver = new RoleLogic();

			driver.ReadAll(reader);
			
			return driver.Results;
		}
		/// <summary>");
		/// Advance one, and read values into a Role
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>");
		/// <returns>A Role or null if there are no results.</returns>
		public static RoleContract ReadOneNow(SqlDataReader reader)
		{
			var driver = new RoleLogic();			
		    return driver.ReadOne(reader) ? driver.Results[0] : null;
		}
		/// <summary>
		/// Saves the row, either by inserting (when the identity key is null) or by updating (identity key has value).
		/// </summary>
		/// <param name="row">The data to save</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveNow(RoleContract row)
		{
			if(row.RoleId == null)
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
		public static int SaveNow(RoleContract row, SqlConnection connection, SqlTransaction transaction)
		{
			if(row.RoleId == null)
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
		public static int SaveAllNow(List<RoleContract> rows)
		{
			return (new RoleLogic()).SaveAll(rows);
		}

		/// <summary>
		/// Save the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Save</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveAllNow(List<RoleContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new RoleLogic()).SaveAll(rows, connection, transaction);
		}        
	}
}