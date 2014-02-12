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
	public abstract partial class RoleLogicBase : LogicBase<RoleLogicBase>
	{
		//Put your code in a separate file.  This is auto generated.
    
		[XmlArray] public List<RoleContract> Results;

		public RoleLogicBase()
		{
			Results =  new List<RoleContract>();
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
		/// <returns>The new ID</returns>
		public virtual int? Insert(string fldTitle
, string fldDescription
, bool fldIsActive
, bool fldApplyToAnon
, bool fldApplyToAllUsers
, bool fldPreventAddingUsers
, string fldWINSID
)
		{
			int? result = null;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Role_Insert]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@Title", fldTitle)
,
						new SqlParameter("@Description", fldDescription)
,
						new SqlParameter("@IsActive", fldIsActive)
,
						new SqlParameter("@ApplyToAnon", fldApplyToAnon)
,
						new SqlParameter("@ApplyToAllUsers", fldApplyToAllUsers)
,
						new SqlParameter("@PreventAddingUsers", fldPreventAddingUsers)
,
						new SqlParameter("@WINSID", fldWINSID)

					});

					result = (int?)cmd.ExecuteScalar();
				}
			});
			return result;
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
		/// <returns>The new ID</returns>
		public virtual int? Insert(string fldTitle
, string fldDescription
, bool fldIsActive
, bool fldApplyToAnon
, bool fldApplyToAllUsers
, bool fldPreventAddingUsers
, string fldWINSID
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[Role_Insert]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@Title", fldTitle)
,
						new SqlParameter("@Description", fldDescription)
,
						new SqlParameter("@IsActive", fldIsActive)
,
						new SqlParameter("@ApplyToAnon", fldApplyToAnon)
,
						new SqlParameter("@ApplyToAllUsers", fldApplyToAllUsers)
,
						new SqlParameter("@PreventAddingUsers", fldPreventAddingUsers)
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
		public int Insert(RoleContract row)
		{
			int? result = null;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Role_Insert]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@Title", row.Title)
,
						new SqlParameter("@Description", row.Description)
,
						new SqlParameter("@IsActive", row.IsActive)
,
						new SqlParameter("@ApplyToAnon", row.ApplyToAnon)
,
						new SqlParameter("@ApplyToAllUsers", row.ApplyToAllUsers)
,
						new SqlParameter("@PreventAddingUsers", row.PreventAddingUsers)
,
						new SqlParameter("@WINSID", row.WINSID)

					});
            
					result = (int?)cmd.ExecuteScalar();
					row.RoleId = result;
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
		public int Insert(RoleContract row, SqlConnection connection, SqlTransaction transaction)
		{
			int? result = null;
			using (
				var cmd = new SqlCommand("[Auth].[Role_Insert]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@Title", row.Title)
,
						new SqlParameter("@Description", row.Description)
,
						new SqlParameter("@IsActive", row.IsActive)
,
						new SqlParameter("@ApplyToAnon", row.ApplyToAnon)
,
						new SqlParameter("@ApplyToAllUsers", row.ApplyToAllUsers)
,
						new SqlParameter("@PreventAddingUsers", row.PreventAddingUsers)
,
						new SqlParameter("@WINSID", row.WINSID)

					});
            
				result = (int?)cmd.ExecuteScalar();
				row.RoleId = result;
			}
			return result != null ? 1 : 0;
		}
		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int InsertAll(List<RoleContract> rows)
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
		public virtual int InsertAll(List<RoleContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Insert(row, connection, transaction);
			return rowCount;
		}

		/// <summary>
		/// Run Role_Update.
		/// </summary>
		/// <returns>The number of rows affected.</returns>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <param name="fldTitle">Value for Title</param>
		/// <param name="fldDescription">Value for Description</param>
		/// <param name="fldIsActive">Value for IsActive</param>
		/// <param name="fldApplyToAnon">Value for ApplyToAnon</param>
		/// <param name="fldApplyToAllUsers">Value for ApplyToAllUsers</param>
		/// <param name="fldPreventAddingUsers">Value for PreventAddingUsers</param>
		/// <param name="fldWINSID">Value for WINSID</param>
		public virtual int Update(int fldRoleId
, string fldTitle
, string fldDescription
, bool fldIsActive
, bool fldApplyToAnon
, bool fldApplyToAllUsers
, bool fldPreventAddingUsers
, string fldWINSID
)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Role_Update]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@RoleId", fldRoleId)
,
						new SqlParameter("@Title", fldTitle)
,
						new SqlParameter("@Description", fldDescription)
,
						new SqlParameter("@IsActive", fldIsActive)
,
						new SqlParameter("@ApplyToAnon", fldApplyToAnon)
,
						new SqlParameter("@ApplyToAllUsers", fldApplyToAllUsers)
,
						new SqlParameter("@PreventAddingUsers", fldPreventAddingUsers)
,
						new SqlParameter("@WINSID", fldWINSID)

					});

					rowCount = cmd.ExecuteNonQuery();
				}
			});
			
			
			return rowCount;
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
		public virtual int Update(int fldRoleId
, string fldTitle
, string fldDescription
, bool fldIsActive
, bool fldApplyToAnon
, bool fldApplyToAllUsers
, bool fldPreventAddingUsers
, string fldWINSID
, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Auth].[Role_Update]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@RoleId", fldRoleId)
,
						new SqlParameter("@Title", fldTitle)
,
						new SqlParameter("@Description", fldDescription)
,
						new SqlParameter("@IsActive", fldIsActive)
,
						new SqlParameter("@ApplyToAnon", fldApplyToAnon)
,
						new SqlParameter("@ApplyToAllUsers", fldApplyToAllUsers)
,
						new SqlParameter("@PreventAddingUsers", fldPreventAddingUsers)
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
		public virtual int Update(RoleContract row)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Role_Update]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@RoleId", row.RoleId)
,
						new SqlParameter("@Title", row.Title)
,
						new SqlParameter("@Description", row.Description)
,
						new SqlParameter("@IsActive", row.IsActive)
,
						new SqlParameter("@ApplyToAnon", row.ApplyToAnon)
,
						new SqlParameter("@ApplyToAllUsers", row.ApplyToAllUsers)
,
						new SqlParameter("@PreventAddingUsers", row.PreventAddingUsers)
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
		public virtual int Update(RoleContract row, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Auth].[Role_Update]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@RoleId", row.RoleId)
,
						new SqlParameter("@Title", row.Title)
,
						new SqlParameter("@Description", row.Description)
,
						new SqlParameter("@IsActive", row.IsActive)
,
						new SqlParameter("@ApplyToAnon", row.ApplyToAnon)
,
						new SqlParameter("@ApplyToAllUsers", row.ApplyToAllUsers)
,
						new SqlParameter("@PreventAddingUsers", row.PreventAddingUsers)
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
		public virtual int UpdateAll(List<RoleContract> rows)
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
		public virtual int UpdateAll(List<RoleContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Update(row, connection, transaction);
			return rowCount;
		}

		/// <summary>
		/// Run Role_Delete.
		/// </summary>
		/// <returns>The number of rows affected.</returns>
		/// <param name="fldRoleId">Value for RoleId</param>
		public virtual int Delete(int fldRoleId
)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Role_Delete]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@RoleId", fldRoleId)

					});

					rowCount = cmd.ExecuteNonQuery();
				}
			});
			
			
			return rowCount;
		}

		/// <summary>
		/// Run Role_Delete.
		/// </summary>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Delete(int fldRoleId
, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Auth].[Role_Delete]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@RoleId", fldRoleId)

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
		public virtual int Delete(RoleContract row)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Role_Delete]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@RoleId", row.RoleId)

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
		public virtual int Delete(RoleContract row, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Auth].[Role_Delete]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@RoleId", row.RoleId)

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
		public virtual int DeleteAll(List<RoleContract> rows)
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
		public virtual int DeleteAll(List<RoleContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Delete(row, connection, transaction);
			return rowCount;
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <returns>True, if the values exist, or false.</returns>
		public virtual bool Exists(int fldRoleId
)
		{
			bool result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Role_Exists]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@RoleId", fldRoleId)

					});

					result = (bool)cmd.ExecuteScalar();
				}
			});

			return result;
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>True, if the values exist, or false.</returns>
		public virtual bool Exists(int fldRoleId
, SqlConnection connection, SqlTransaction transaction)
		{					
			using (
				var cmd = new SqlCommand("[Auth].[Role_Exists]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@RoleId", fldRoleId)

					});

					return (bool)cmd.ExecuteScalar();
			}
		}

		/// <summary>
		/// Run Role_Search, and return results as a list of RoleRow.
		/// </summary>
		/// <param name="fldTitle">Value for Title</param>
		/// <param name="fldDescription">Value for Description</param>
		/// <param name="fldWINSID">Value for WINSID</param>
		/// <returns>A collection of RoleRow.</returns>
		public virtual bool Search(string fldTitle
, string fldDescription
, string fldWINSID
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Role_Search]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@Title", fldTitle)
,
						new SqlParameter("@Description", fldDescription)
,
						new SqlParameter("@WINSID", fldWINSID)

					});

					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
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
		public virtual bool Search(string fldTitle
, string fldDescription
, string fldWINSID
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[Role_Search]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@Title", fldTitle)
,
						new SqlParameter("@Description", fldDescription)
,
						new SqlParameter("@WINSID", fldWINSID)

					});

				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run Role_SelectAll, and return results as a list of RoleRow.
		/// </summary>

		/// <returns>A collection of RoleRow.</returns>
		public virtual bool SelectAll()
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Role_SelectAll]", x)
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
		/// Run Role_SelectAll, and return results as a list of RoleRow.
		/// </summary>

		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of RoleRow.</returns>
		public virtual bool SelectAll(SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[Role_SelectAll]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run Role_List, and return results as a list.
		/// </summary>
		/// <param name="fldTitle">Value for Title</param>
		/// <returns>A collection of __ListItemRow.</returns>
		public virtual List<ListItemContract> List(string fldTitle
)
		{
			List<ListItemContract> result = null;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Role_List]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@Title", fldTitle)

					});

					using(var r = cmd.ExecuteReader()) result = ListItemLogic.ReadAllNow(r);
				}
			});

			return result;
		}

		/// <summary>
		/// Run Role_List, and return results as a list.
		/// </summary>
		/// <param name="fldTitle">Value for Title</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of __ListItemRow.</returns>
		public virtual List<ListItemContract> List(string fldTitle
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[Role_List]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@Title", fldTitle)

					});

				using(var r = cmd.ExecuteReader()) return ListItemLogic.ReadAllNow(r);				
			}
		}

		/// <summary>
		/// Run Role_SelectBy_RoleId, and return results as a list of RoleRow.
		/// </summary>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <returns>A collection of RoleRow.</returns>
		public virtual bool SelectBy_RoleId(int fldRoleId
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Role_SelectBy_RoleId]", x)
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
		/// Run Role_SelectBy_RoleId, and return results as a list of RoleRow.
		/// </summary>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of RoleRow.</returns>
		public virtual bool SelectBy_RoleId(int fldRoleId
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[Role_SelectBy_RoleId]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@RoleId", fldRoleId)

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
					new RoleContract
					{
					RoleId = reader.GetInt32(0),
					Title = reader.GetString(1),
					Description = reader.GetString(2),
					IsActive = reader.GetBoolean(3),
					ApplyToAnon = reader.GetBoolean(4),
					ApplyToAllUsers = reader.GetBoolean(5),
					PreventAddingUsers = reader.GetBoolean(6),
					WINSID = reader.IsDBNull(7) ? null : reader.GetString(7),

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
		public virtual int Save(RoleContract row)
		{
			if(row == null) return 0;
			if(row.RoleId != null) return Update(row);
			
			return Insert(row);
		}

		/// <summary>
		/// Saves the row, either by inserting (when the identity key is null) or by updating (identity key has value).
		/// </summary>
		/// <param name="row">The data to save</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Save(RoleContract row, SqlConnection connection, SqlTransaction transaction)
		{
			if(row == null) return 0;
			if(row.RoleId != null) return Update(row, connection, transaction);
			
			return Insert(row, connection, transaction);
		}		

		/// <summary>
		/// Save the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Save</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int SaveAll(List<RoleContract> rows)
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
		public virtual int SaveAll(List<RoleContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Save(row, connection, transaction);
			return rowCount;
		}
	}
}