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
	public abstract partial class UserRoleLogicBase : LogicBase<UserRoleLogicBase>
	{
		//Put your code in a separate file.  This is auto generated.
    
		[XmlArray] public List<UserRoleContract> Results;

		public UserRoleLogicBase()
		{
			Results =  new List<UserRoleContract>();
		}

		/// <summary>
		/// Run UserRole_Insert.
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <returns>The new ID</returns>
		public virtual int? Insert(int fldUserId
, int fldRoleId
)
		{
			int? result = null;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[UserRole_Insert]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserId", fldUserId)
,
						new SqlParameter("@RoleId", fldRoleId)

					});

					result = (int?)cmd.ExecuteScalar();
				}
			});
			return result;
		}

		/// <summary>
		/// Run UserRole_Insert.
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The new ID</returns>
		public virtual int? Insert(int fldUserId
, int fldRoleId
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[UserRole_Insert]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserId", fldUserId)
,
						new SqlParameter("@RoleId", fldRoleId)

					});

				return (int?)cmd.ExecuteScalar();
			}
		}

		/// <summary>
		/// Insert by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>1, if insert was successful</returns>
		public int Insert(UserRoleContract row)
		{
			int? result = null;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[UserRole_Insert]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserId", row.UserId)
,
						new SqlParameter("@RoleId", row.RoleId)

					});
            
					result = (int?)cmd.ExecuteScalar();
					row.UserRoleId = result;
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
		public int Insert(UserRoleContract row, SqlConnection connection, SqlTransaction transaction)
		{
			int? result = null;
			using (
				var cmd = new SqlCommand("[Auth].[UserRole_Insert]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserId", row.UserId)
,
						new SqlParameter("@RoleId", row.RoleId)

					});
            
				result = (int?)cmd.ExecuteScalar();
				row.UserRoleId = result;
			}
			return result != null ? 1 : 0;
		}
		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int InsertAll(List<UserRoleContract> rows)
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
		public virtual int InsertAll(List<UserRoleContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Insert(row, connection, transaction);
			return rowCount;
		}

		/// <summary>
		/// Run UserRole_Update.
		/// </summary>
		/// <returns>The number of rows affected.</returns>
		/// <param name="fldUserRoleId">Value for UserRoleId</param>
		/// <param name="fldUserId">Value for UserId</param>
		/// <param name="fldRoleId">Value for RoleId</param>
		public virtual int Update(int fldUserRoleId
, int fldUserId
, int fldRoleId
)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[UserRole_Update]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserRoleId", fldUserRoleId)
,
						new SqlParameter("@UserId", fldUserId)
,
						new SqlParameter("@RoleId", fldRoleId)

					});

					rowCount = cmd.ExecuteNonQuery();
				}
			});
			
			
			return rowCount;
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
		public virtual int Update(int fldUserRoleId
, int fldUserId
, int fldRoleId
, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Auth].[UserRole_Update]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserRoleId", fldUserRoleId)
,
						new SqlParameter("@UserId", fldUserId)
,
						new SqlParameter("@RoleId", fldRoleId)

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
		public virtual int Update(UserRoleContract row)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[UserRole_Update]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserRoleId", row.UserRoleId)
,
						new SqlParameter("@UserId", row.UserId)
,
						new SqlParameter("@RoleId", row.RoleId)

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
		public virtual int Update(UserRoleContract row, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Auth].[UserRole_Update]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserRoleId", row.UserRoleId)
,
						new SqlParameter("@UserId", row.UserId)
,
						new SqlParameter("@RoleId", row.RoleId)

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
		public virtual int UpdateAll(List<UserRoleContract> rows)
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
		public virtual int UpdateAll(List<UserRoleContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Update(row, connection, transaction);
			return rowCount;
		}

		/// <summary>
		/// Run UserRole_Delete.
		/// </summary>
		/// <returns>The number of rows affected.</returns>
		/// <param name="fldUserRoleId">Value for UserRoleId</param>
		public virtual int Delete(int fldUserRoleId
)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[UserRole_Delete]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserRoleId", fldUserRoleId)

					});

					rowCount = cmd.ExecuteNonQuery();
				}
			});
			
			
			return rowCount;
		}

		/// <summary>
		/// Run UserRole_Delete.
		/// </summary>
		/// <param name="fldUserRoleId">Value for UserRoleId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Delete(int fldUserRoleId
, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Auth].[UserRole_Delete]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserRoleId", fldUserRoleId)

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
		public virtual int Delete(UserRoleContract row)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[UserRole_Delete]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserRoleId", row.UserRoleId)

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
		public virtual int Delete(UserRoleContract row, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Auth].[UserRole_Delete]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserRoleId", row.UserRoleId)

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
		public virtual int DeleteAll(List<UserRoleContract> rows)
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
		public virtual int DeleteAll(List<UserRoleContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Delete(row, connection, transaction);
			return rowCount;
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldUserRoleId">Value for UserRoleId</param>
		/// <returns>True, if the values exist, or false.</returns>
		public virtual bool Exists(int fldUserRoleId
)
		{
			bool result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[UserRole_Exists]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserRoleId", fldUserRoleId)

					});

					result = (bool)cmd.ExecuteScalar();
				}
			});

			return result;
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldUserRoleId">Value for UserRoleId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>True, if the values exist, or false.</returns>
		public virtual bool Exists(int fldUserRoleId
, SqlConnection connection, SqlTransaction transaction)
		{					
			using (
				var cmd = new SqlCommand("[Auth].[UserRole_Exists]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserRoleId", fldUserRoleId)

					});

					return (bool)cmd.ExecuteScalar();
			}
		}

		/// <summary>
		/// Run UserRole_SelectAll, and return results as a list of UserRoleRow.
		/// </summary>

		/// <returns>A collection of UserRoleRow.</returns>
		public virtual bool SelectAll()
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[UserRole_SelectAll]", x)
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
		/// Run UserRole_SelectAll, and return results as a list of UserRoleRow.
		/// </summary>

		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UserRoleRow.</returns>
		public virtual bool SelectAll(SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[UserRole_SelectAll]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run UserRole_SelectBy_UserRoleId, and return results as a list of UserRoleRow.
		/// </summary>
		/// <param name="fldUserRoleId">Value for UserRoleId</param>
		/// <returns>A collection of UserRoleRow.</returns>
		public virtual bool SelectBy_UserRoleId(int fldUserRoleId
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[UserRole_SelectBy_UserRoleId]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserRoleId", fldUserRoleId)

					});

					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
		}

		/// <summary>
		/// Run UserRole_SelectBy_UserRoleId, and return results as a list of UserRoleRow.
		/// </summary>
		/// <param name="fldUserRoleId">Value for UserRoleId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UserRoleRow.</returns>
		public virtual bool SelectBy_UserRoleId(int fldUserRoleId
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[UserRole_SelectBy_UserRoleId]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserRoleId", fldUserRoleId)

					});

				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run UserRole_SelectBy_RoleId, and return results as a list of UserRoleRow.
		/// </summary>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <returns>A collection of UserRoleRow.</returns>
		public virtual bool SelectBy_RoleId(int fldRoleId
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[UserRole_SelectBy_RoleId]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@RoleId", fldRoleId)

					});

					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
		}

		/// <summary>
		/// Run UserRole_SelectBy_RoleId, and return results as a list of UserRoleRow.
		/// </summary>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UserRoleRow.</returns>
		public virtual bool SelectBy_RoleId(int fldRoleId
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[UserRole_SelectBy_RoleId]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@RoleId", fldRoleId)

					});

				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run UserRole_SelectBy_UserId, and return results as a list of UserRoleRow.
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <returns>A collection of UserRoleRow.</returns>
		public virtual bool SelectBy_UserId(int fldUserId
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[UserRole_SelectBy_UserId]", x)
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
		/// Run UserRole_SelectBy_UserId, and return results as a list of UserRoleRow.
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UserRoleRow.</returns>
		public virtual bool SelectBy_UserId(int fldUserId
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[UserRole_SelectBy_UserId]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserId", fldUserId)

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
					new UserRoleContract
					{
					UserRoleId = reader.GetInt32(0),
					UserId = reader.GetInt32(1),
					RoleId = reader.GetInt32(2),

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
		public virtual int Save(UserRoleContract row)
		{
			if(row == null) return 0;
			if(row.UserRoleId != null) return Update(row);
			
			return Insert(row);
		}

		/// <summary>
		/// Saves the row, either by inserting (when the identity key is null) or by updating (identity key has value).
		/// </summary>
		/// <param name="row">The data to save</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Save(UserRoleContract row, SqlConnection connection, SqlTransaction transaction)
		{
			if(row == null) return 0;
			if(row.UserRoleId != null) return Update(row, connection, transaction);
			
			return Insert(row, connection, transaction);
		}		

		/// <summary>
		/// Save the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Save</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int SaveAll(List<UserRoleContract> rows)
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
		public virtual int SaveAll(List<UserRoleContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Save(row, connection, transaction);
			return rowCount;
		}
	}
}