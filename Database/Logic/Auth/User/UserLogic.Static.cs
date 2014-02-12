using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CALI.Database.Contracts;
using CALI.Database.Contracts.Auth;

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This file contains static implementations of the UserLogic
// Add your own static methods by making a new partial class.
// You cannot override static methods, instead override the methods
// located in UserLogicBase by making a partial class of UserLogic
// and overriding the base methods.

namespace CALI.Database.Logic.Auth
{
	public partial class UserLogic
	{
		//Put your code in a separate file.  This is auto generated.
		/// <summary>
		/// Run User_Insert.
		/// </summary>
		/// <param name="fldUserName">Value for UserName</param>
		/// <param name="fldPassword">Value for Password</param>
		/// <param name="fldDisplayName">Value for DisplayName</param>
		/// <param name="fldEmail">Value for Email</param>
		/// <param name="fldAuthToken">Value for AuthToken</param>
		/// <param name="fldUserToken">Value for UserToken</param>
		/// <param name="fldFailedLogins">Value for FailedLogins</param>
		/// <param name="fldIsActive">Value for IsActive</param>
		/// <param name="fldWINSID">Value for WINSID</param>
		public static int? InsertNow(string fldUserName
, byte[] fldPassword
, string fldDisplayName
, string fldEmail
, Guid fldAuthToken
, Guid fldUserToken
, int fldFailedLogins
, bool fldIsActive
, string fldWINSID
)
		{
			return (new UserLogic()).Insert(fldUserName
, fldPassword
, fldDisplayName
, fldEmail
, fldAuthToken
, fldUserToken
, fldFailedLogins
, fldIsActive
, fldWINSID
);
		}
		/// <summary>
		/// Run User_Insert.
		/// </summary>
		/// <param name="fldUserName">Value for UserName</param>
		/// <param name="fldPassword">Value for Password</param>
		/// <param name="fldDisplayName">Value for DisplayName</param>
		/// <param name="fldEmail">Value for Email</param>
		/// <param name="fldAuthToken">Value for AuthToken</param>
		/// <param name="fldUserToken">Value for UserToken</param>
		/// <param name="fldFailedLogins">Value for FailedLogins</param>
		/// <param name="fldIsActive">Value for IsActive</param>
		/// <param name="fldWINSID">Value for WINSID</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		public static int? InsertNow(string fldUserName
, byte[] fldPassword
, string fldDisplayName
, string fldEmail
, Guid fldAuthToken
, Guid fldUserToken
, int fldFailedLogins
, bool fldIsActive
, string fldWINSID
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new UserLogic()).Insert(fldUserName
, fldPassword
, fldDisplayName
, fldEmail
, fldAuthToken
, fldUserToken
, fldFailedLogins
, fldIsActive
, fldWINSID
, connection, transaction);
		}

		/// <summary>
		/// Insert by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertNow(UserContract row)
		{
			return (new UserLogic()).Insert(row);
		}

		/// <summary>
		/// Insert by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertNow(UserContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new UserLogic()).Insert(row, connection, transaction);
		}

		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertAllNow(List<UserContract> rows)
		{
			return (new UserLogic()).InsertAll(rows);
		}

		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertAllNow(List<UserContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new UserLogic()).InsertAll(rows, connection, transaction);
		}
		/// <summary>
		/// Run User_Update.
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <param name="fldUserName">Value for UserName</param>
		/// <param name="fldPassword">Value for Password</param>
		/// <param name="fldDisplayName">Value for DisplayName</param>
		/// <param name="fldEmail">Value for Email</param>
		/// <param name="fldAuthToken">Value for AuthToken</param>
		/// <param name="fldUserToken">Value for UserToken</param>
		/// <param name="fldFailedLogins">Value for FailedLogins</param>
		/// <param name="fldIsActive">Value for IsActive</param>
		/// <param name="fldWINSID">Value for WINSID</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(int fldUserId
, string fldUserName
, byte[] fldPassword
, string fldDisplayName
, string fldEmail
, Guid fldAuthToken
, Guid fldUserToken
, int fldFailedLogins
, bool fldIsActive
, string fldWINSID
)
		{
			return (new UserLogic()).Update(fldUserId
, fldUserName
, fldPassword
, fldDisplayName
, fldEmail
, fldAuthToken
, fldUserToken
, fldFailedLogins
, fldIsActive
, fldWINSID
);
		}

		/// <summary>
		/// Run User_Update.
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <param name="fldUserName">Value for UserName</param>
		/// <param name="fldPassword">Value for Password</param>
		/// <param name="fldDisplayName">Value for DisplayName</param>
		/// <param name="fldEmail">Value for Email</param>
		/// <param name="fldAuthToken">Value for AuthToken</param>
		/// <param name="fldUserToken">Value for UserToken</param>
		/// <param name="fldFailedLogins">Value for FailedLogins</param>
		/// <param name="fldIsActive">Value for IsActive</param>
		/// <param name="fldWINSID">Value for WINSID</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(int fldUserId
, string fldUserName
, byte[] fldPassword
, string fldDisplayName
, string fldEmail
, Guid fldAuthToken
, Guid fldUserToken
, int fldFailedLogins
, bool fldIsActive
, string fldWINSID
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new UserLogic()).Update(fldUserId
, fldUserName
, fldPassword
, fldDisplayName
, fldEmail
, fldAuthToken
, fldUserToken
, fldFailedLogins
, fldIsActive
, fldWINSID
, connection, transaction);
		}
		/// <summary>
		/// Update by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(UserContract row)
		{
			return (new UserLogic()).Update(row);
		}

		/// <summary>
		/// Update by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(UserContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new UserLogic()).Update(row, connection, transaction);
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateAllNow(List<UserContract> rows)
		{
			return (new UserLogic()).UpdateAll(rows);
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateAllNow(List<UserContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new UserLogic()).UpdateAll(rows, connection, transaction);
		}
		/// <summary>
		/// Run User_Delete.
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(int fldUserId
)
		{
			return (new UserLogic()).Delete(fldUserId
);
		}

		/// <summary>
		/// Run User_Delete.
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(int fldUserId
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new UserLogic()).Delete(fldUserId
, connection, transaction);
		}
		/// <summary>
		/// Delete by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(UserContract row)
		{
			return (new UserLogic()).Delete(row);
		}

		/// <summary>
		/// Delete by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(UserContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new UserLogic()).Delete(row, connection, transaction);
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteAllNow(List<UserContract> rows)
		{
			return (new UserLogic()).DeleteAll(rows);
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteAllNow(List<UserContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new UserLogic()).DeleteAll(rows, connection, transaction);
		}
		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldUserId
)
		{
			return (new UserLogic()).Exists(fldUserId
);
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldUserId
, SqlConnection connection, SqlTransaction transaction)
		{					
			return (new UserLogic()).Exists(fldUserId
, connection, transaction);
		}

		/// <summary>
		/// Run User_Search, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldUserName">Value for UserName</param>
		/// <param name="fldDisplayName">Value for DisplayName</param>
		/// <param name="fldEmail">Value for Email</param>
		/// <param name="fldWINSID">Value for WINSID</param>
		/// <returns>A collection of UserRow.</returns>
		public static List<UserContract> SearchNow(string fldUserName
, string fldDisplayName
, string fldEmail
, string fldWINSID
)
		{
			var driver = new UserLogic();
			driver.Search(fldUserName
, fldDisplayName
, fldEmail
, fldWINSID
);
			return driver.Results;
		}

		/// <summary>
		/// Run User_Search, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldUserName">Value for UserName</param>
		/// <param name="fldDisplayName">Value for DisplayName</param>
		/// <param name="fldEmail">Value for Email</param>
		/// <param name="fldWINSID">Value for WINSID</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UserRow.</returns>
		public static List<UserContract> SearchNow(string fldUserName
, string fldDisplayName
, string fldEmail
, string fldWINSID
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new UserLogic();
			driver.Search(fldUserName
, fldDisplayName
, fldEmail
, fldWINSID
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run User_SelectAll, and return results as a list of UserRow.
		/// </summary>

		/// <returns>A collection of UserRow.</returns>
		public static List<UserContract> SelectAllNow()
		{			
			var driver = new UserLogic();
			driver.SelectAll();
			return driver.Results;
		}

		/// <summary>
		/// Run User_SelectAll, and return results as a list of UserRow.
		/// </summary>

		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UserRow.</returns>
		public static List<UserContract> SelectAllNow(SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new UserLogic();
			driver.SelectAll(connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run User_List, and return results as a list.
		/// </summary>
		/// <param name="fldUserName">Value for UserName</param>
		/// <returns>A collection of __ListItemRow.</returns>
		public static List<ListItemContract> ListNow(string fldUserName
)
		{
			return (new UserLogic()).List(fldUserName
);
		}

		/// <summary>
		/// Run User_List, and return results as a list.
		/// </summary>
		/// <param name="fldUserName">Value for UserName</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of __ListItemRow.</returns>
		public static List<ListItemContract> ListNow(string fldUserName
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new UserLogic()).List(fldUserName
, connection, transaction);
		}

		/// <summary>
		/// Run User_SelectBy_UserId, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <returns>A collection of UserRow.</returns>
		public static List<UserContract> SelectBy_UserIdNow(int fldUserId
)
		{
			var driver = new UserLogic();
			driver.SelectBy_UserId(fldUserId
);
			return driver.Results;
		}

		/// <summary>
		/// Run User_SelectBy_UserId, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UserRow.</returns>
		public static List<UserContract> SelectBy_UserIdNow(int fldUserId
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new UserLogic();
			driver.SelectBy_UserId(fldUserId
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run User_SelectBy_UserName, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldUserName">Value for UserName</param>
		/// <returns>A collection of UserRow.</returns>
		public static List<UserContract> SelectBy_UserNameNow(string fldUserName
)
		{
			var driver = new UserLogic();
			driver.SelectBy_UserName(fldUserName
);
			return driver.Results;
		}

		/// <summary>
		/// Run User_SelectBy_UserName, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldUserName">Value for UserName</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UserRow.</returns>
		public static List<UserContract> SelectBy_UserNameNow(string fldUserName
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new UserLogic();
			driver.SelectBy_UserName(fldUserName
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run User_SelectBy_Email, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldEmail">Value for Email</param>
		/// <returns>A collection of UserRow.</returns>
		public static List<UserContract> SelectBy_EmailNow(string fldEmail
)
		{
			var driver = new UserLogic();
			driver.SelectBy_Email(fldEmail
);
			return driver.Results;
		}

		/// <summary>
		/// Run User_SelectBy_Email, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldEmail">Value for Email</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UserRow.</returns>
		public static List<UserContract> SelectBy_EmailNow(string fldEmail
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new UserLogic();
			driver.SelectBy_Email(fldEmail
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run User_SelectBy_UserToken, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldUserToken">Value for UserToken</param>
		/// <returns>A collection of UserRow.</returns>
		public static List<UserContract> SelectBy_UserTokenNow(Guid fldUserToken
)
		{
			var driver = new UserLogic();
			driver.SelectBy_UserToken(fldUserToken
);
			return driver.Results;
		}

		/// <summary>
		/// Run User_SelectBy_UserToken, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldUserToken">Value for UserToken</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UserRow.</returns>
		public static List<UserContract> SelectBy_UserTokenNow(Guid fldUserToken
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new UserLogic();
			driver.SelectBy_UserToken(fldUserToken
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run User_SelectBy_WINSID, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldWINSID">Value for WINSID</param>
		/// <returns>A collection of UserRow.</returns>
		public static List<UserContract> SelectBy_WINSIDNow(string fldWINSID
)
		{
			var driver = new UserLogic();
			driver.SelectBy_WINSID(fldWINSID
);
			return driver.Results;
		}

		/// <summary>
		/// Run User_SelectBy_WINSID, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldWINSID">Value for WINSID</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UserRow.</returns>
		public static List<UserContract> SelectBy_WINSIDNow(string fldWINSID
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new UserLogic();
			driver.SelectBy_WINSID(fldWINSID
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Read all User rows from the provided reader into the list structure of UserRows
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>
		/// <returns>A populated UserRows or an empty UserRows if there are no results.</returns>
		public static List<UserContract> ReadAllNow(SqlDataReader reader)
		{
			var driver = new UserLogic();

			driver.ReadAll(reader);
			
			return driver.Results;
		}
		/// <summary>");
		/// Advance one, and read values into a User
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>");
		/// <returns>A User or null if there are no results.</returns>
		public static UserContract ReadOneNow(SqlDataReader reader)
		{
			var driver = new UserLogic();			
		    return driver.ReadOne(reader) ? driver.Results[0] : null;
		}
		/// <summary>
		/// Saves the row, either by inserting (when the identity key is null) or by updating (identity key has value).
		/// </summary>
		/// <param name="row">The data to save</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveNow(UserContract row)
		{
			if(row.UserId == null)
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
		public static int SaveNow(UserContract row, SqlConnection connection, SqlTransaction transaction)
		{
			if(row.UserId == null)
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
		public static int SaveAllNow(List<UserContract> rows)
		{
			return (new UserLogic()).SaveAll(rows);
		}

		/// <summary>
		/// Save the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Save</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveAllNow(List<UserContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new UserLogic()).SaveAll(rows, connection, transaction);
		}        
	}
}