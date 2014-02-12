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
	public abstract partial class PermissionLogicBase : LogicBase<PermissionLogicBase>
	{
		//Put your code in a separate file.  This is auto generated.
    
		[XmlArray] public List<PermissionContract> Results;

		public PermissionLogicBase()
		{
			Results =  new List<PermissionContract>();
		}

		/// <summary>
		/// Run Permission_SelectBy_UserId, and return results as a list of PermissionRow.
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <returns>A collection of PermissionRow.</returns>
		public virtual bool SelectBy_UserId(int fldUserId
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Permission_SelectBy_UserId]", x)
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
		/// Run Permission_SelectBy_UserId, and return results as a list of PermissionRow.
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of PermissionRow.</returns>
		public virtual bool SelectBy_UserId(int fldUserId
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[Permission_SelectBy_UserId]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserId", fldUserId)

					});

				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run Permission_Insert.
		/// </summary>
		/// <param name="fldPermissionName">Value for PermissionName</param>
		/// <param name="fldTitle">Value for Title</param>
		/// <param name="fldIsRead">Value for IsRead</param>
		/// <returns>The new ID</returns>
		public virtual int? Insert(string fldPermissionName
, string fldTitle
, bool fldIsRead
)
		{
			int? result = null;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Permission_Insert]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@PermissionName", fldPermissionName)
,
						new SqlParameter("@Title", fldTitle)
,
						new SqlParameter("@IsRead", fldIsRead)

					});

					result = (int?)cmd.ExecuteScalar();
				}
			});
			return result;
		}

		/// <summary>
		/// Run Permission_Insert.
		/// </summary>
		/// <param name="fldPermissionName">Value for PermissionName</param>
		/// <param name="fldTitle">Value for Title</param>
		/// <param name="fldIsRead">Value for IsRead</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The new ID</returns>
		public virtual int? Insert(string fldPermissionName
, string fldTitle
, bool fldIsRead
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[Permission_Insert]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@PermissionName", fldPermissionName)
,
						new SqlParameter("@Title", fldTitle)
,
						new SqlParameter("@IsRead", fldIsRead)

					});

				return (int?)cmd.ExecuteScalar();
			}
		}

		/// <summary>
		/// Insert by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>1, if insert was successful</returns>
		public int Insert(PermissionContract row)
		{
			int? result = null;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Permission_Insert]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@PermissionName", row.PermissionName)
,
						new SqlParameter("@Title", row.Title)
,
						new SqlParameter("@IsRead", row.IsRead)

					});
            
					result = (int?)cmd.ExecuteScalar();
					row.PermissionId = result;
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
		public int Insert(PermissionContract row, SqlConnection connection, SqlTransaction transaction)
		{
			int? result = null;
			using (
				var cmd = new SqlCommand("[Auth].[Permission_Insert]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@PermissionName", row.PermissionName)
,
						new SqlParameter("@Title", row.Title)
,
						new SqlParameter("@IsRead", row.IsRead)

					});
            
				result = (int?)cmd.ExecuteScalar();
				row.PermissionId = result;
			}
			return result != null ? 1 : 0;
		}
		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int InsertAll(List<PermissionContract> rows)
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
		public virtual int InsertAll(List<PermissionContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Insert(row, connection, transaction);
			return rowCount;
		}

		/// <summary>
		/// Run Permission_Update.
		/// </summary>
		/// <returns>The number of rows affected.</returns>
		/// <param name="fldPermissionId">Value for PermissionId</param>
		/// <param name="fldPermissionName">Value for PermissionName</param>
		/// <param name="fldTitle">Value for Title</param>
		/// <param name="fldIsRead">Value for IsRead</param>
		public virtual int Update(int fldPermissionId
, string fldPermissionName
, string fldTitle
, bool fldIsRead
)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Permission_Update]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@PermissionId", fldPermissionId)
,
						new SqlParameter("@PermissionName", fldPermissionName)
,
						new SqlParameter("@Title", fldTitle)
,
						new SqlParameter("@IsRead", fldIsRead)

					});

					rowCount = cmd.ExecuteNonQuery();
				}
			});
			
			
			return rowCount;
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
		public virtual int Update(int fldPermissionId
, string fldPermissionName
, string fldTitle
, bool fldIsRead
, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Auth].[Permission_Update]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@PermissionId", fldPermissionId)
,
						new SqlParameter("@PermissionName", fldPermissionName)
,
						new SqlParameter("@Title", fldTitle)
,
						new SqlParameter("@IsRead", fldIsRead)

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
		public virtual int Update(PermissionContract row)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Permission_Update]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@PermissionId", row.PermissionId)
,
						new SqlParameter("@PermissionName", row.PermissionName)
,
						new SqlParameter("@Title", row.Title)
,
						new SqlParameter("@IsRead", row.IsRead)

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
		public virtual int Update(PermissionContract row, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Auth].[Permission_Update]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@PermissionId", row.PermissionId)
,
						new SqlParameter("@PermissionName", row.PermissionName)
,
						new SqlParameter("@Title", row.Title)
,
						new SqlParameter("@IsRead", row.IsRead)

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
		public virtual int UpdateAll(List<PermissionContract> rows)
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
		public virtual int UpdateAll(List<PermissionContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Update(row, connection, transaction);
			return rowCount;
		}

		/// <summary>
		/// Run Permission_Delete.
		/// </summary>
		/// <returns>The number of rows affected.</returns>
		/// <param name="fldPermissionId">Value for PermissionId</param>
		public virtual int Delete(int fldPermissionId
)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Permission_Delete]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@PermissionId", fldPermissionId)

					});

					rowCount = cmd.ExecuteNonQuery();
				}
			});
			
			
			return rowCount;
		}

		/// <summary>
		/// Run Permission_Delete.
		/// </summary>
		/// <param name="fldPermissionId">Value for PermissionId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Delete(int fldPermissionId
, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Auth].[Permission_Delete]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@PermissionId", fldPermissionId)

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
		public virtual int Delete(PermissionContract row)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Permission_Delete]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@PermissionId", row.PermissionId)

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
		public virtual int Delete(PermissionContract row, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Auth].[Permission_Delete]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@PermissionId", row.PermissionId)

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
		public virtual int DeleteAll(List<PermissionContract> rows)
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
		public virtual int DeleteAll(List<PermissionContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Delete(row, connection, transaction);
			return rowCount;
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldPermissionId">Value for PermissionId</param>
		/// <returns>True, if the values exist, or false.</returns>
		public virtual bool Exists(int fldPermissionId
)
		{
			bool result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Permission_Exists]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@PermissionId", fldPermissionId)

					});

					result = (bool)cmd.ExecuteScalar();
				}
			});

			return result;
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldPermissionId">Value for PermissionId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>True, if the values exist, or false.</returns>
		public virtual bool Exists(int fldPermissionId
, SqlConnection connection, SqlTransaction transaction)
		{					
			using (
				var cmd = new SqlCommand("[Auth].[Permission_Exists]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@PermissionId", fldPermissionId)

					});

					return (bool)cmd.ExecuteScalar();
			}
		}

		/// <summary>
		/// Run Permission_Search, and return results as a list of PermissionRow.
		/// </summary>
		/// <param name="fldPermissionName">Value for PermissionName</param>
		/// <param name="fldTitle">Value for Title</param>
		/// <returns>A collection of PermissionRow.</returns>
		public virtual bool Search(string fldPermissionName
, string fldTitle
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Permission_Search]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@PermissionName", fldPermissionName)
,
						new SqlParameter("@Title", fldTitle)

					});

					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
		}

		/// <summary>
		/// Run Permission_Search, and return results as a list of PermissionRow.
		/// </summary>
		/// <param name="fldPermissionName">Value for PermissionName</param>
		/// <param name="fldTitle">Value for Title</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of PermissionRow.</returns>
		public virtual bool Search(string fldPermissionName
, string fldTitle
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[Permission_Search]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@PermissionName", fldPermissionName)
,
						new SqlParameter("@Title", fldTitle)

					});

				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run Permission_SelectAll, and return results as a list of PermissionRow.
		/// </summary>

		/// <returns>A collection of PermissionRow.</returns>
		public virtual bool SelectAll()
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Permission_SelectAll]", x)
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
		/// Run Permission_SelectAll, and return results as a list of PermissionRow.
		/// </summary>

		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of PermissionRow.</returns>
		public virtual bool SelectAll(SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[Permission_SelectAll]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run Permission_List, and return results as a list.
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
					var cmd = new SqlCommand("[Auth].[Permission_List]", x)
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
		/// Run Permission_List, and return results as a list.
		/// </summary>
		/// <param name="fldTitle">Value for Title</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of __ListItemRow.</returns>
		public virtual List<ListItemContract> List(string fldTitle
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[Permission_List]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@Title", fldTitle)

					});

				using(var r = cmd.ExecuteReader()) return ListItemLogic.ReadAllNow(r);				
			}
		}

		/// <summary>
		/// Run Permission_SelectBy_PermissionId, and return results as a list of PermissionRow.
		/// </summary>
		/// <param name="fldPermissionId">Value for PermissionId</param>
		/// <returns>A collection of PermissionRow.</returns>
		public virtual bool SelectBy_PermissionId(int fldPermissionId
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Auth].[Permission_SelectBy_PermissionId]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@PermissionId", fldPermissionId)

					});

					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
		}

		/// <summary>
		/// Run Permission_SelectBy_PermissionId, and return results as a list of PermissionRow.
		/// </summary>
		/// <param name="fldPermissionId">Value for PermissionId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of PermissionRow.</returns>
		public virtual bool SelectBy_PermissionId(int fldPermissionId
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Auth].[Permission_SelectBy_PermissionId]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@PermissionId", fldPermissionId)

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
					new PermissionContract
					{
					PermissionId = reader.GetInt32(0),
					PermissionName = reader.GetString(1),
					Title = reader.GetString(2),
					IsRead = reader.GetBoolean(3),

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
		public virtual int Save(PermissionContract row)
		{
			if(row == null) return 0;
			if(row.PermissionId != null) return Update(row);
			
			return Insert(row);
		}

		/// <summary>
		/// Saves the row, either by inserting (when the identity key is null) or by updating (identity key has value).
		/// </summary>
		/// <param name="row">The data to save</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Save(PermissionContract row, SqlConnection connection, SqlTransaction transaction)
		{
			if(row == null) return 0;
			if(row.PermissionId != null) return Update(row, connection, transaction);
			
			return Insert(row, connection, transaction);
		}		

		/// <summary>
		/// Save the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Save</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int SaveAll(List<PermissionContract> rows)
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
		public virtual int SaveAll(List<PermissionContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Save(row, connection, transaction);
			return rowCount;
		}
	}
}