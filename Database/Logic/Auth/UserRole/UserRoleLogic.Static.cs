using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CALI.Database.Contracts;
using CALI.Database.Contracts.Auth;

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This file contains static implementations of the UserRoleLogic
// Add your own static methods by making a new partial class.
// You cannot override static methods, instead override the methods
// located in UserRoleLogicBase by making a partial class of UserRoleLogic
// and overriding the base methods.

namespace CALI.Database.Logic.Auth
{
	public partial class UserRoleLogic
	{
		//Put your code in a separate file.  This is auto generated.
		/// <summary>
		/// Run UserRole_Insert.
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <param name="fldRoleId">Value for RoleId</param>
		public static int? InsertNow(int fldUserId
, int fldRoleId
)
		{
			return (new UserRoleLogic()).Insert(fldUserId
, fldRoleId
);
		}
		/// <summary>
		/// Run UserRole_Insert.
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		public static int? InsertNow(int fldUserId
, int fldRoleId
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new UserRoleLogic()).Insert(fldUserId
, fldRoleId
, connection, transaction);
		}

		/// <summary>
		/// Insert by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertNow(UserRoleContract row)
		{
			return (new UserRoleLogic()).Insert(row);
		}

		/// <summary>
		/// Insert by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertNow(UserRoleContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new UserRoleLogic()).Insert(row, connection, transaction);
		}

		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertAllNow(List<UserRoleContract> rows)
		{
			return (new UserRoleLogic()).InsertAll(rows);
		}

		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertAllNow(List<UserRoleContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new UserRoleLogic()).InsertAll(rows, connection, transaction);
		}
		/// <summary>
		/// Run UserRole_Update.
		/// </summary>
		/// <param name="fldUserRoleId">Value for UserRoleId</param>
		/// <param name="fldUserId">Value for UserId</param>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(int fldUserRoleId
, int fldUserId
, int fldRoleId
)
		{
			return (new UserRoleLogic()).Update(fldUserRoleId
, fldUserId
, fldRoleId
);
		}

		/// <summary>
		/// Run UserRole_Update.
		/// </summary>
		/// <param name="fldUserRoleId">Value for UserRoleId</param>
		/// <param name="fldUserId">Value for UserId</param>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(int fldUserRoleId
, int fldUserId
, int fldRoleId
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new UserRoleLogic()).Update(fldUserRoleId
, fldUserId
, fldRoleId
, connection, transaction);
		}
		/// <summary>
		/// Update by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(UserRoleContract row)
		{
			return (new UserRoleLogic()).Update(row);
		}

		/// <summary>
		/// Update by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(UserRoleContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new UserRoleLogic()).Update(row, connection, transaction);
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateAllNow(List<UserRoleContract> rows)
		{
			return (new UserRoleLogic()).UpdateAll(rows);
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateAllNow(List<UserRoleContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new UserRoleLogic()).UpdateAll(rows, connection, transaction);
		}
		/// <summary>
		/// Run UserRole_Delete.
		/// </summary>
		/// <param name="fldUserRoleId">Value for UserRoleId</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(int fldUserRoleId
)
		{
			return (new UserRoleLogic()).Delete(fldUserRoleId
);
		}

		/// <summary>
		/// Run UserRole_Delete.
		/// </summary>
		/// <param name="fldUserRoleId">Value for UserRoleId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(int fldUserRoleId
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new UserRoleLogic()).Delete(fldUserRoleId
, connection, transaction);
		}
		/// <summary>
		/// Delete by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(UserRoleContract row)
		{
			return (new UserRoleLogic()).Delete(row);
		}

		/// <summary>
		/// Delete by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(UserRoleContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new UserRoleLogic()).Delete(row, connection, transaction);
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteAllNow(List<UserRoleContract> rows)
		{
			return (new UserRoleLogic()).DeleteAll(rows);
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteAllNow(List<UserRoleContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new UserRoleLogic()).DeleteAll(rows, connection, transaction);
		}
		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldUserRoleId">Value for UserRoleId</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldUserRoleId
)
		{
			return (new UserRoleLogic()).Exists(fldUserRoleId
);
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldUserRoleId">Value for UserRoleId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldUserRoleId
, SqlConnection connection, SqlTransaction transaction)
		{					
			return (new UserRoleLogic()).Exists(fldUserRoleId
, connection, transaction);
		}

		/// <summary>
		/// Run UserRole_SelectAll, and return results as a list of UserRoleRow.
		/// </summary>

		/// <returns>A collection of UserRoleRow.</returns>
		public static List<UserRoleContract> SelectAllNow()
		{			
			var driver = new UserRoleLogic();
			driver.SelectAll();
			return driver.Results;
		}

		/// <summary>
		/// Run UserRole_SelectAll, and return results as a list of UserRoleRow.
		/// </summary>

		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UserRoleRow.</returns>
		public static List<UserRoleContract> SelectAllNow(SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new UserRoleLogic();
			driver.SelectAll(connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run UserRole_SelectBy_UserRoleId, and return results as a list of UserRoleRow.
		/// </summary>
		/// <param name="fldUserRoleId">Value for UserRoleId</param>
		/// <returns>A collection of UserRoleRow.</returns>
		public static List<UserRoleContract> SelectBy_UserRoleIdNow(int fldUserRoleId
)
		{
			var driver = new UserRoleLogic();
			driver.SelectBy_UserRoleId(fldUserRoleId
);
			return driver.Results;
		}

		/// <summary>
		/// Run UserRole_SelectBy_UserRoleId, and return results as a list of UserRoleRow.
		/// </summary>
		/// <param name="fldUserRoleId">Value for UserRoleId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UserRoleRow.</returns>
		public static List<UserRoleContract> SelectBy_UserRoleIdNow(int fldUserRoleId
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new UserRoleLogic();
			driver.SelectBy_UserRoleId(fldUserRoleId
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run UserRole_SelectBy_RoleId, and return results as a list of UserRoleRow.
		/// </summary>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <returns>A collection of UserRoleRow.</returns>
		public static List<UserRoleContract> SelectBy_RoleIdNow(int fldRoleId
)
		{
			var driver = new UserRoleLogic();
			driver.SelectBy_RoleId(fldRoleId
);
			return driver.Results;
		}

		/// <summary>
		/// Run UserRole_SelectBy_RoleId, and return results as a list of UserRoleRow.
		/// </summary>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UserRoleRow.</returns>
		public static List<UserRoleContract> SelectBy_RoleIdNow(int fldRoleId
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new UserRoleLogic();
			driver.SelectBy_RoleId(fldRoleId
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run UserRole_SelectBy_UserId, and return results as a list of UserRoleRow.
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <returns>A collection of UserRoleRow.</returns>
		public static List<UserRoleContract> SelectBy_UserIdNow(int fldUserId
)
		{
			var driver = new UserRoleLogic();
			driver.SelectBy_UserId(fldUserId
);
			return driver.Results;
		}

		/// <summary>
		/// Run UserRole_SelectBy_UserId, and return results as a list of UserRoleRow.
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UserRoleRow.</returns>
		public static List<UserRoleContract> SelectBy_UserIdNow(int fldUserId
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new UserRoleLogic();
			driver.SelectBy_UserId(fldUserId
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Read all UserRole rows from the provided reader into the list structure of UserRoleRows
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>
		/// <returns>A populated UserRoleRows or an empty UserRoleRows if there are no results.</returns>
		public static List<UserRoleContract> ReadAllNow(SqlDataReader reader)
		{
			var driver = new UserRoleLogic();

			driver.ReadAll(reader);
			
			return driver.Results;
		}
		/// <summary>");
		/// Advance one, and read values into a UserRole
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>");
		/// <returns>A UserRole or null if there are no results.</returns>
		public static UserRoleContract ReadOneNow(SqlDataReader reader)
		{
			var driver = new UserRoleLogic();			
		    return driver.ReadOne(reader) ? driver.Results[0] : null;
		}
		/// <summary>
		/// Saves the row, either by inserting (when the identity key is null) or by updating (identity key has value).
		/// </summary>
		/// <param name="row">The data to save</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveNow(UserRoleContract row)
		{
			if(row.UserRoleId == null)
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
		public static int SaveNow(UserRoleContract row, SqlConnection connection, SqlTransaction transaction)
		{
			if(row.UserRoleId == null)
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
		public static int SaveAllNow(List<UserRoleContract> rows)
		{
			return (new UserRoleLogic()).SaveAll(rows);
		}

		/// <summary>
		/// Save the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Save</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveAllNow(List<UserRoleContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new UserRoleLogic()).SaveAll(rows, connection, transaction);
		}        
	}
}