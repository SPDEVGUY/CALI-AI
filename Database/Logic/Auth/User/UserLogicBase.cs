using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Serialization;
using CALI.Database.Contracts;
using CALI.Database.Contracts.Auth;

//////////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.	//
//Override methods in the logic front class.				//
//////////////////////////////////////////////////////////////

namespace CALI.Database.Logic.Auth
{
	[Serializable]
	public abstract partial class UserLogicBase : LogicBase<UserLogicBase>
	{
		//Put your code in a separate file.  This is auto generated.
    
		[XmlArray] public List<UserContract> Results;

		public UserLogicBase()
		{
			Results =  new List<UserContract>();
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
		/// <returns>The new ID</returns>
		public virtual int? Insert(string fldUserName
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
			int? result = null;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[User_Insert]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserName", fldUserName)
,
						new SqlParameter("@Password", fldPassword)
,
						new SqlParameter("@DisplayName", fldDisplayName)
,
						new SqlParameter("@Email", fldEmail)
,
						new SqlParameter("@AuthToken", fldAuthToken)
,
						new SqlParameter("@UserToken", fldUserToken)
,
						new SqlParameter("@FailedLogins", fldFailedLogins)
,
						new SqlParameter("@IsActive", fldIsActive)
,
						new SqlParameter("@WINSID", fldWINSID)

					});

					result = (int?)cmd.ExecuteScalar();
				}
			});
			return result;
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
		/// <returns>The new ID</returns>
		public virtual int? Insert(string fldUserName
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
			using (
				var cmd = new SqlCommand("[Auth].[User_Insert]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserName", fldUserName)
,
						new SqlParameter("@Password", fldPassword)
,
						new SqlParameter("@DisplayName", fldDisplayName)
,
						new SqlParameter("@Email", fldEmail)
,
						new SqlParameter("@AuthToken", fldAuthToken)
,
						new SqlParameter("@UserToken", fldUserToken)
,
						new SqlParameter("@FailedLogins", fldFailedLogins)
,
						new SqlParameter("@IsActive", fldIsActive)
,
						new SqlParameter("@WINSID", fldWINSID)

					});

				return (int?)cmd.ExecuteScalar();
			}
		}

		/// <summary>
		/// Insert by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>1, if insert was successful</returns>
		public int Insert(UserContract row)
		{
			int? result = null;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[User_Insert]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserName", row.UserName)
,
						new SqlParameter("@Password", row.Password)
,
						new SqlParameter("@DisplayName", row.DisplayName)
,
						new SqlParameter("@Email", row.Email)
,
						new SqlParameter("@AuthToken", row.AuthToken)
,
						new SqlParameter("@UserToken", row.UserToken)
,
						new SqlParameter("@FailedLogins", row.FailedLogins)
,
						new SqlParameter("@IsActive", row.IsActive)
,
						new SqlParameter("@WINSID", row.WINSID)

					});
            
					result = (int?)cmd.ExecuteScalar();
					row.UserId = result;
				}
			});
			return result != null ? 1 : 0;
		}

		/// <summary>
		/// Insert by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>1, if insert was successful</returns>
		public int Insert(UserContract row, SqlConnection connection, SqlTransaction transaction)
		{
			int? result = null;
			using (
				var cmd = new SqlCommand("[Auth].[User_Insert]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserName", row.UserName)
,
						new SqlParameter("@Password", row.Password)
,
						new SqlParameter("@DisplayName", row.DisplayName)
,
						new SqlParameter("@Email", row.Email)
,
						new SqlParameter("@AuthToken", row.AuthToken)
,
						new SqlParameter("@UserToken", row.UserToken)
,
						new SqlParameter("@FailedLogins", row.FailedLogins)
,
						new SqlParameter("@IsActive", row.IsActive)
,
						new SqlParameter("@WINSID", row.WINSID)

					});
            
				result = (int?)cmd.ExecuteScalar();
				row.UserId = result;
			}
			return result != null ? 1 : 0;
		}
		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int InsertAll(List<UserContract> rows)
		{		
			var rowCount = 0;
			CALIDb.ConnectThen(x => 
			{
				rowCount = InsertAll(rows, x, null);
			});
			return rowCount;
		}

		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int InsertAll(List<UserContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Insert(row, connection, transaction);
			return rowCount;
		}

		/// <summary>
		/// Run User_Update.
		/// </summary>
		/// <returns>The number of rows affected.</returns>
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
		public virtual int Update(int fldUserId
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
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[User_Update]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserId", fldUserId)
,
						new SqlParameter("@UserName", fldUserName)
,
						new SqlParameter("@Password", fldPassword)
,
						new SqlParameter("@DisplayName", fldDisplayName)
,
						new SqlParameter("@Email", fldEmail)
,
						new SqlParameter("@AuthToken", fldAuthToken)
,
						new SqlParameter("@UserToken", fldUserToken)
,
						new SqlParameter("@FailedLogins", fldFailedLogins)
,
						new SqlParameter("@IsActive", fldIsActive)
,
						new SqlParameter("@WINSID", fldWINSID)

					});

					rowCount = cmd.ExecuteNonQuery();
				}
			});
			
			
			return rowCount;
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
		public virtual int Update(int fldUserId
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
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Auth].[User_Update]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserId", fldUserId)
,
						new SqlParameter("@UserName", fldUserName)
,
						new SqlParameter("@Password", fldPassword)
,
						new SqlParameter("@DisplayName", fldDisplayName)
,
						new SqlParameter("@Email", fldEmail)
,
						new SqlParameter("@AuthToken", fldAuthToken)
,
						new SqlParameter("@UserToken", fldUserToken)
,
						new SqlParameter("@FailedLogins", fldFailedLogins)
,
						new SqlParameter("@IsActive", fldIsActive)
,
						new SqlParameter("@WINSID", fldWINSID)

					});

				rowCount = cmd.ExecuteNonQuery();
			}
			
			
			return rowCount;
		}
		
		/// <summary>
		/// Update by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Update(UserContract row)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[User_Update]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserId", row.UserId)
,
						new SqlParameter("@UserName", row.UserName)
,
						new SqlParameter("@Password", row.Password)
,
						new SqlParameter("@DisplayName", row.DisplayName)
,
						new SqlParameter("@Email", row.Email)
,
						new SqlParameter("@AuthToken", row.AuthToken)
,
						new SqlParameter("@UserToken", row.UserToken)
,
						new SqlParameter("@FailedLogins", row.FailedLogins)
,
						new SqlParameter("@IsActive", row.IsActive)
,
						new SqlParameter("@WINSID", row.WINSID)

					});
            
					rowCount = cmd.ExecuteNonQuery();
				}
			});
			
			
			return rowCount;
		}

		/// <summary>
		/// Update by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Update(UserContract row, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Auth].[User_Update]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserId", row.UserId)
,
						new SqlParameter("@UserName", row.UserName)
,
						new SqlParameter("@Password", row.Password)
,
						new SqlParameter("@DisplayName", row.DisplayName)
,
						new SqlParameter("@Email", row.Email)
,
						new SqlParameter("@AuthToken", row.AuthToken)
,
						new SqlParameter("@UserToken", row.UserToken)
,
						new SqlParameter("@FailedLogins", row.FailedLogins)
,
						new SqlParameter("@IsActive", row.IsActive)
,
						new SqlParameter("@WINSID", row.WINSID)

					});
            
				rowCount = cmd.ExecuteNonQuery();
			}
			
			
			return rowCount;
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int UpdateAll(List<UserContract> rows)
		{		
			var rowCount = 0;
			CALIDb.ConnectThen(x => 
			{
				rowCount = UpdateAll(rows, x, null);
			});
			return rowCount;
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int UpdateAll(List<UserContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Update(row, connection, transaction);
			return rowCount;
		}

		/// <summary>
		/// Run User_Delete.
		/// </summary>
		/// <returns>The number of rows affected.</returns>
		/// <param name="fldUserId">Value for UserId</param>
		public virtual int Delete(int fldUserId
)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[User_Delete]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserId", fldUserId)

					});

					rowCount = cmd.ExecuteNonQuery();
				}
			});
			
			
			return rowCount;
		}

		/// <summary>
		/// Run User_Delete.
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Delete(int fldUserId
, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Auth].[User_Delete]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserId", fldUserId)

					});

				rowCount = cmd.ExecuteNonQuery();
			}
			
			
			return rowCount;
		}
		
		/// <summary>
		/// Delete by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Delete(UserContract row)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[User_Delete]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserId", row.UserId)

					});
            
					rowCount = cmd.ExecuteNonQuery();
				}
			});
			
			
			return rowCount;
		}

		/// <summary>
		/// Delete by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Delete(UserContract row, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Auth].[User_Delete]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserId", row.UserId)

					});
            
				rowCount = cmd.ExecuteNonQuery();
			}
			
			
			return rowCount;
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int DeleteAll(List<UserContract> rows)
		{		
			var rowCount = 0;
			CALIDb.ConnectThen(x => 
			{
				rowCount = DeleteAll(rows, x, null);
			});
			return rowCount;
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int DeleteAll(List<UserContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Delete(row, connection, transaction);
			return rowCount;
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <returns>True, if the values exist, or false.</returns>
		public virtual bool Exists(int fldUserId
)
		{
			bool result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[User_Exists]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserId", fldUserId)

					});

					result = (bool)cmd.ExecuteScalar();
				}
			});

			return result;
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>True, if the values exist, or false.</returns>
		public virtual bool Exists(int fldUserId
, SqlConnection connection, SqlTransaction transaction)
		{					
			using (
				var cmd = new SqlCommand("[Auth].[User_Exists]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserId", fldUserId)

					});

					return (bool)cmd.ExecuteScalar();
			}
		}

		/// <summary>
		/// Run User_Search, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldUserName">Value for UserName</param>
		/// <param name="fldDisplayName">Value for DisplayName</param>
		/// <param name="fldEmail">Value for Email</param>
		/// <param name="fldWINSID">Value for WINSID</param>
		/// <returns>A collection of UserRow.</returns>
		public virtual bool Search(string fldUserName
, string fldDisplayName
, string fldEmail
, string fldWINSID
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[User_Search]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserName", fldUserName)
,
						new SqlParameter("@DisplayName", fldDisplayName)
,
						new SqlParameter("@Email", fldEmail)
,
						new SqlParameter("@WINSID", fldWINSID)

					});

					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
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
		public virtual bool Search(string fldUserName
, string fldDisplayName
, string fldEmail
, string fldWINSID
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[User_Search]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserName", fldUserName)
,
						new SqlParameter("@DisplayName", fldDisplayName)
,
						new SqlParameter("@Email", fldEmail)
,
						new SqlParameter("@WINSID", fldWINSID)

					});

				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run User_SelectAll, and return results as a list of UserRow.
		/// </summary>

		/// <returns>A collection of UserRow.</returns>
		public virtual bool SelectAll()
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[User_SelectAll]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
		}

		/// <summary>
		/// Run User_SelectAll, and return results as a list of UserRow.
		/// </summary>

		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UserRow.</returns>
		public virtual bool SelectAll(SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[User_SelectAll]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run User_List, and return results as a list.
		/// </summary>
		/// <param name="fldUserName">Value for UserName</param>
		/// <returns>A collection of __ListItemRow.</returns>
		public virtual List<ListItemContract> List(string fldUserName
)
		{
			List<ListItemContract> result = null;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[User_List]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserName", fldUserName)

					});

					using(var r = cmd.ExecuteReader()) result = ListItemLogic.ReadAllNow(r);
				}
			});

			return result;
		}

		/// <summary>
		/// Run User_List, and return results as a list.
		/// </summary>
		/// <param name="fldUserName">Value for UserName</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of __ListItemRow.</returns>
		public virtual List<ListItemContract> List(string fldUserName
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[User_List]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserName", fldUserName)

					});

				using(var r = cmd.ExecuteReader()) return ListItemLogic.ReadAllNow(r);				
			}
		}

		/// <summary>
		/// Run User_SelectBy_UserId, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <returns>A collection of UserRow.</returns>
		public virtual bool SelectBy_UserId(int fldUserId
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[User_SelectBy_UserId]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserId", fldUserId)

					});

					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
		}

		/// <summary>
		/// Run User_SelectBy_UserId, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UserRow.</returns>
		public virtual bool SelectBy_UserId(int fldUserId
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[User_SelectBy_UserId]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserId", fldUserId)

					});

				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run User_SelectBy_UserName, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldUserName">Value for UserName</param>
		/// <returns>A collection of UserRow.</returns>
		public virtual bool SelectBy_UserName(string fldUserName
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[User_SelectBy_UserName]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserName", fldUserName)

					});

					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
		}

		/// <summary>
		/// Run User_SelectBy_UserName, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldUserName">Value for UserName</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UserRow.</returns>
		public virtual bool SelectBy_UserName(string fldUserName
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[User_SelectBy_UserName]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserName", fldUserName)

					});

				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run User_SelectBy_Email, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldEmail">Value for Email</param>
		/// <returns>A collection of UserRow.</returns>
		public virtual bool SelectBy_Email(string fldEmail
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[User_SelectBy_Email]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@Email", fldEmail)

					});

					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
		}

		/// <summary>
		/// Run User_SelectBy_Email, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldEmail">Value for Email</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UserRow.</returns>
		public virtual bool SelectBy_Email(string fldEmail
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[User_SelectBy_Email]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@Email", fldEmail)

					});

				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run User_SelectBy_UserToken, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldUserToken">Value for UserToken</param>
		/// <returns>A collection of UserRow.</returns>
		public virtual bool SelectBy_UserToken(Guid fldUserToken
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[User_SelectBy_UserToken]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserToken", fldUserToken)

					});

					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
		}

		/// <summary>
		/// Run User_SelectBy_UserToken, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldUserToken">Value for UserToken</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UserRow.</returns>
		public virtual bool SelectBy_UserToken(Guid fldUserToken
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[User_SelectBy_UserToken]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserToken", fldUserToken)

					});

				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run User_SelectBy_WINSID, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldWINSID">Value for WINSID</param>
		/// <returns>A collection of UserRow.</returns>
		public virtual bool SelectBy_WINSID(string fldWINSID
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[User_SelectBy_WINSID]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@WINSID", fldWINSID)

					});

					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
		}

		/// <summary>
		/// Run User_SelectBy_WINSID, and return results as a list of UserRow.
		/// </summary>
		/// <param name="fldWINSID">Value for WINSID</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UserRow.</returns>
		public virtual bool SelectBy_WINSID(string fldWINSID
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[User_SelectBy_WINSID]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@WINSID", fldWINSID)

					});

				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Read all items into this collection
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>
		public virtual bool ReadAll(SqlDataReader reader)
		{
			var canRead = ReadOne(reader);
			var result = canRead;

			while (canRead) canRead = ReadOne(reader);

			return result;
		}
		/// <summary>
		/// Read one item into Results
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>
		public virtual bool ReadOne(SqlDataReader reader)
		{
			if (reader.Read())
			{
				Results.Add(
					new UserContract
					{
					UserId = reader.GetInt32(0),
					UserName = reader.GetString(1),
					Password = (byte[])reader.GetValue(2),
					DisplayName = reader.GetString(3),
					Email = reader.GetString(4),
					AuthToken = reader.GetGuid(5),
					UserToken = reader.GetGuid(6),
					FailedLogins = reader.GetInt32(7),
					IsActive = reader.GetBoolean(8),
					WINSID = reader.IsDBNull(9) ? null : reader.GetString(9),

					});
				return true;
			}
			return false;
		}
		/// <summary>
		/// Saves the row, either by inserting (when the identity key is null) or by updating (identity key has value).
		/// </summary>
		/// <param name="row">The data to save</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Save(UserContract row)
		{
			if(row == null) return 0;
			if(row.UserId != null) return Update(row);
			
			return Insert(row);
		}

		/// <summary>
		/// Saves the row, either by inserting (when the identity key is null) or by updating (identity key has value).
		/// </summary>
		/// <param name="row">The data to save</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Save(UserContract row, SqlConnection connection, SqlTransaction transaction)
		{
			if(row == null) return 0;
			if(row.UserId != null) return Update(row, connection, transaction);
			
			return Insert(row, connection, transaction);
		}		

		/// <summary>
		/// Save the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Save</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int SaveAll(List<UserContract> rows)
		{		
			var rowCount = 0;
			CALIDb.ConnectThen(x => 
			{
				foreach(var row in rows) rowCount += Save(row, x, null);
			});
			return rowCount;
		}

		/// <summary>
		/// Save the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Save</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int SaveAll(List<UserContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Save(row, connection, transaction);
			return rowCount;
		}
	}
}