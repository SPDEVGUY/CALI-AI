using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Serialization;
using CALI.Database.Contracts;
using CALI.Database.Contracts.Data;

//////////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.	//
//Override methods in the logic front class.				//
//////////////////////////////////////////////////////////////

namespace CALI.Database.Logic.Data
{
	[Serializable]
	public abstract partial class QueryLogicBase : LogicBase<QueryLogicBase>
	{
		//Put your code in a separate file.  This is auto generated.
    
		[XmlArray] public List<QueryContract> Results;

		public QueryLogicBase()
		{
			Results =  new List<QueryContract>();
		}

		/// <summary>
		/// Run Query_Insert.
		/// </summary>
		/// <param name="fldText">Value for Text</param>
		/// <param name="fldProcessorUsed">Value for ProcessorUsed</param>
		/// <param name="fldExceptions">Value for Exceptions</param>
		/// <param name="fldIsSuccess">Value for IsSuccess</param>
		/// <returns>The new ID</returns>
		public virtual int? Insert(string fldText
, string fldProcessorUsed
, string fldExceptions
, bool fldIsSuccess
)
		{
			int? result = null;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[Query_Insert]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@Text", fldText)
,
						new SqlParameter("@ProcessorUsed", fldProcessorUsed)
,
						new SqlParameter("@Exceptions", fldExceptions)
,
						new SqlParameter("@IsSuccess", fldIsSuccess)

					});

					result = (int?)cmd.ExecuteScalar();
				}
			});
			return result;
		}

		/// <summary>
		/// Run Query_Insert.
		/// </summary>
		/// <param name="fldText">Value for Text</param>
		/// <param name="fldProcessorUsed">Value for ProcessorUsed</param>
		/// <param name="fldExceptions">Value for Exceptions</param>
		/// <param name="fldIsSuccess">Value for IsSuccess</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The new ID</returns>
		public virtual int? Insert(string fldText
, string fldProcessorUsed
, string fldExceptions
, bool fldIsSuccess
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Data].[Query_Insert]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@Text", fldText)
,
						new SqlParameter("@ProcessorUsed", fldProcessorUsed)
,
						new SqlParameter("@Exceptions", fldExceptions)
,
						new SqlParameter("@IsSuccess", fldIsSuccess)

					});

				return (int?)cmd.ExecuteScalar();
			}
		}

		/// <summary>
		/// Insert by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>1, if insert was successful</returns>
		public int Insert(QueryContract row)
		{
			int? result = null;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[Query_Insert]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@Text", row.Text)
,
						new SqlParameter("@ProcessorUsed", row.ProcessorUsed)
,
						new SqlParameter("@Exceptions", row.Exceptions)
,
						new SqlParameter("@IsSuccess", row.IsSuccess)

					});
            
					result = (int?)cmd.ExecuteScalar();
					row.QueryId = result;
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
		public int Insert(QueryContract row, SqlConnection connection, SqlTransaction transaction)
		{
			int? result = null;
			using (
				var cmd = new SqlCommand("[Data].[Query_Insert]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@Text", row.Text)
,
						new SqlParameter("@ProcessorUsed", row.ProcessorUsed)
,
						new SqlParameter("@Exceptions", row.Exceptions)
,
						new SqlParameter("@IsSuccess", row.IsSuccess)

					});
            
				result = (int?)cmd.ExecuteScalar();
				row.QueryId = result;
			}
			return result != null ? 1 : 0;
		}
		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int InsertAll(List<QueryContract> rows)
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
		public virtual int InsertAll(List<QueryContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Insert(row, connection, transaction);
			return rowCount;
		}

		/// <summary>
		/// Run Query_Update.
		/// </summary>
		/// <returns>The number of rows affected.</returns>
		/// <param name="fldQueryId">Value for QueryId</param>
		/// <param name="fldText">Value for Text</param>
		/// <param name="fldProcessorUsed">Value for ProcessorUsed</param>
		/// <param name="fldExceptions">Value for Exceptions</param>
		/// <param name="fldIsSuccess">Value for IsSuccess</param>
		public virtual int Update(int fldQueryId
, string fldText
, string fldProcessorUsed
, string fldExceptions
, bool fldIsSuccess
)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[Query_Update]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@QueryId", fldQueryId)
,
						new SqlParameter("@Text", fldText)
,
						new SqlParameter("@ProcessorUsed", fldProcessorUsed)
,
						new SqlParameter("@Exceptions", fldExceptions)
,
						new SqlParameter("@IsSuccess", fldIsSuccess)

					});

					rowCount = cmd.ExecuteNonQuery();
				}
			});
			
			
			return rowCount;
		}

		/// <summary>
		/// Run Query_Update.
		/// </summary>
		/// <param name="fldQueryId">Value for QueryId</param>
		/// <param name="fldText">Value for Text</param>
		/// <param name="fldProcessorUsed">Value for ProcessorUsed</param>
		/// <param name="fldExceptions">Value for Exceptions</param>
		/// <param name="fldIsSuccess">Value for IsSuccess</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Update(int fldQueryId
, string fldText
, string fldProcessorUsed
, string fldExceptions
, bool fldIsSuccess
, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Data].[Query_Update]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@QueryId", fldQueryId)
,
						new SqlParameter("@Text", fldText)
,
						new SqlParameter("@ProcessorUsed", fldProcessorUsed)
,
						new SqlParameter("@Exceptions", fldExceptions)
,
						new SqlParameter("@IsSuccess", fldIsSuccess)

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
		public virtual int Update(QueryContract row)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[Query_Update]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@QueryId", row.QueryId)
,
						new SqlParameter("@Text", row.Text)
,
						new SqlParameter("@ProcessorUsed", row.ProcessorUsed)
,
						new SqlParameter("@Exceptions", row.Exceptions)
,
						new SqlParameter("@IsSuccess", row.IsSuccess)

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
		public virtual int Update(QueryContract row, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Data].[Query_Update]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@QueryId", row.QueryId)
,
						new SqlParameter("@Text", row.Text)
,
						new SqlParameter("@ProcessorUsed", row.ProcessorUsed)
,
						new SqlParameter("@Exceptions", row.Exceptions)
,
						new SqlParameter("@IsSuccess", row.IsSuccess)

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
		public virtual int UpdateAll(List<QueryContract> rows)
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
		public virtual int UpdateAll(List<QueryContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Update(row, connection, transaction);
			return rowCount;
		}

		/// <summary>
		/// Run Query_Delete.
		/// </summary>
		/// <returns>The number of rows affected.</returns>
		/// <param name="fldQueryId">Value for QueryId</param>
		public virtual int Delete(int fldQueryId
)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[Query_Delete]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@QueryId", fldQueryId)

					});

					rowCount = cmd.ExecuteNonQuery();
				}
			});
			
			
			return rowCount;
		}

		/// <summary>
		/// Run Query_Delete.
		/// </summary>
		/// <param name="fldQueryId">Value for QueryId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Delete(int fldQueryId
, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Data].[Query_Delete]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@QueryId", fldQueryId)

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
		public virtual int Delete(QueryContract row)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[Query_Delete]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@QueryId", row.QueryId)

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
		public virtual int Delete(QueryContract row, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Data].[Query_Delete]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@QueryId", row.QueryId)

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
		public virtual int DeleteAll(List<QueryContract> rows)
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
		public virtual int DeleteAll(List<QueryContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Delete(row, connection, transaction);
			return rowCount;
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldQueryId">Value for QueryId</param>
		/// <returns>True, if the values exist, or false.</returns>
		public virtual bool Exists(int fldQueryId
)
		{
			bool result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[Query_Exists]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@QueryId", fldQueryId)

					});

					result = (bool)cmd.ExecuteScalar();
				}
			});

			return result;
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldQueryId">Value for QueryId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>True, if the values exist, or false.</returns>
		public virtual bool Exists(int fldQueryId
, SqlConnection connection, SqlTransaction transaction)
		{					
			using (
				var cmd = new SqlCommand("[Data].[Query_Exists]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@QueryId", fldQueryId)

					});

					return (bool)cmd.ExecuteScalar();
			}
		}

		/// <summary>
		/// Run Query_Search, and return results as a list of QueryRow.
		/// </summary>
		/// <param name="fldText">Value for Text</param>
		/// <param name="fldProcessorUsed">Value for ProcessorUsed</param>
		/// <param name="fldExceptions">Value for Exceptions</param>
		/// <returns>A collection of QueryRow.</returns>
		public virtual bool Search(string fldText
, string fldProcessorUsed
, string fldExceptions
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[Query_Search]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@Text", fldText)
,
						new SqlParameter("@ProcessorUsed", fldProcessorUsed)
,
						new SqlParameter("@Exceptions", fldExceptions)

					});

					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
		}

		/// <summary>
		/// Run Query_Search, and return results as a list of QueryRow.
		/// </summary>
		/// <param name="fldText">Value for Text</param>
		/// <param name="fldProcessorUsed">Value for ProcessorUsed</param>
		/// <param name="fldExceptions">Value for Exceptions</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of QueryRow.</returns>
		public virtual bool Search(string fldText
, string fldProcessorUsed
, string fldExceptions
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Data].[Query_Search]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@Text", fldText)
,
						new SqlParameter("@ProcessorUsed", fldProcessorUsed)
,
						new SqlParameter("@Exceptions", fldExceptions)

					});

				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run Query_SelectAll, and return results as a list of QueryRow.
		/// </summary>

		/// <returns>A collection of QueryRow.</returns>
		public virtual bool SelectAll()
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[Query_SelectAll]", x)
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
		/// Run Query_SelectAll, and return results as a list of QueryRow.
		/// </summary>

		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of QueryRow.</returns>
		public virtual bool SelectAll(SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Data].[Query_SelectAll]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run Query_SelectBy_QueryId, and return results as a list of QueryRow.
		/// </summary>
		/// <param name="fldQueryId">Value for QueryId</param>
		/// <returns>A collection of QueryRow.</returns>
		public virtual bool SelectBy_QueryId(int fldQueryId
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[Query_SelectBy_QueryId]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@QueryId", fldQueryId)

					});

					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
		}

		/// <summary>
		/// Run Query_SelectBy_QueryId, and return results as a list of QueryRow.
		/// </summary>
		/// <param name="fldQueryId">Value for QueryId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of QueryRow.</returns>
		public virtual bool SelectBy_QueryId(int fldQueryId
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Data].[Query_SelectBy_QueryId]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@QueryId", fldQueryId)

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
					new QueryContract
					{
					QueryId = reader.GetInt32(0),
					Text = reader.GetString(1),
					ProcessorUsed = reader.IsDBNull(2) ? null : reader.GetString(2),
					Exceptions = reader.IsDBNull(3) ? null : reader.GetString(3),
					IsSuccess = reader.GetBoolean(4),

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
		public virtual int Save(QueryContract row)
		{
			if(row == null) return 0;
			if(row.QueryId != null) return Update(row);
			
			return Insert(row);
		}

		/// <summary>
		/// Saves the row, either by inserting (when the identity key is null) or by updating (identity key has value).
		/// </summary>
		/// <param name="row">The data to save</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Save(QueryContract row, SqlConnection connection, SqlTransaction transaction)
		{
			if(row == null) return 0;
			if(row.QueryId != null) return Update(row, connection, transaction);
			
			return Insert(row, connection, transaction);
		}		

		/// <summary>
		/// Save the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Save</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int SaveAll(List<QueryContract> rows)
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
		public virtual int SaveAll(List<QueryContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Save(row, connection, transaction);
			return rowCount;
		}
	}
}