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
	public abstract partial class BinaryDataMonikerLogicBase : LogicBase<BinaryDataMonikerLogicBase>
	{
		//Put your code in a separate file.  This is auto generated.
    
		[XmlArray] public List<BinaryDataMonikerContract> Results;

		public BinaryDataMonikerLogicBase()
		{
			Results =  new List<BinaryDataMonikerContract>();
		}

		/// <summary>
		/// Run BinaryDataMoniker_Insert.
		/// </summary>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <param name="fldMonikerId">Value for MonikerId</param>
		/// <returns>The new ID</returns>
		public virtual int? Insert(int fldBinaryDataId
, int fldMonikerId
)
		{
			int? result = null;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryDataMoniker_Insert]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataId", fldBinaryDataId)
,
						new SqlParameter("@MonikerId", fldMonikerId)

					});

					result = (int?)cmd.ExecuteScalar();
				}
			});
			return result;
		}

		/// <summary>
		/// Run BinaryDataMoniker_Insert.
		/// </summary>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <param name="fldMonikerId">Value for MonikerId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The new ID</returns>
		public virtual int? Insert(int fldBinaryDataId
, int fldMonikerId
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Data].[BinaryDataMoniker_Insert]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataId", fldBinaryDataId)
,
						new SqlParameter("@MonikerId", fldMonikerId)

					});

				return (int?)cmd.ExecuteScalar();
			}
		}

		/// <summary>
		/// Insert by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>1, if insert was successful</returns>
		public int Insert(BinaryDataMonikerContract row)
		{
			int? result = null;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryDataMoniker_Insert]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataId", row.BinaryDataId)
,
						new SqlParameter("@MonikerId", row.MonikerId)

					});
            
					result = (int?)cmd.ExecuteScalar();
					row.BinaryDataMonikerId = result;
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
		public int Insert(BinaryDataMonikerContract row, SqlConnection connection, SqlTransaction transaction)
		{
			int? result = null;
			using (
				var cmd = new SqlCommand("[Data].[BinaryDataMoniker_Insert]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataId", row.BinaryDataId)
,
						new SqlParameter("@MonikerId", row.MonikerId)

					});
            
				result = (int?)cmd.ExecuteScalar();
				row.BinaryDataMonikerId = result;
			}
			return result != null ? 1 : 0;
		}
		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int InsertAll(List<BinaryDataMonikerContract> rows)
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
		public virtual int InsertAll(List<BinaryDataMonikerContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Insert(row, connection, transaction);
			return rowCount;
		}

		/// <summary>
		/// Run BinaryDataMoniker_Update.
		/// </summary>
		/// <returns>The number of rows affected.</returns>
		/// <param name="fldBinaryDataMonikerId">Value for BinaryDataMonikerId</param>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <param name="fldMonikerId">Value for MonikerId</param>
		public virtual int Update(int fldBinaryDataMonikerId
, int fldBinaryDataId
, int fldMonikerId
)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryDataMoniker_Update]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataMonikerId", fldBinaryDataMonikerId)
,
						new SqlParameter("@BinaryDataId", fldBinaryDataId)
,
						new SqlParameter("@MonikerId", fldMonikerId)

					});

					rowCount = cmd.ExecuteNonQuery();
				}
			});
			
			
			return rowCount;
		}

		/// <summary>
		/// Run BinaryDataMoniker_Update.
		/// </summary>
		/// <param name="fldBinaryDataMonikerId">Value for BinaryDataMonikerId</param>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <param name="fldMonikerId">Value for MonikerId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Update(int fldBinaryDataMonikerId
, int fldBinaryDataId
, int fldMonikerId
, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Data].[BinaryDataMoniker_Update]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataMonikerId", fldBinaryDataMonikerId)
,
						new SqlParameter("@BinaryDataId", fldBinaryDataId)
,
						new SqlParameter("@MonikerId", fldMonikerId)

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
		public virtual int Update(BinaryDataMonikerContract row)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryDataMoniker_Update]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataMonikerId", row.BinaryDataMonikerId)
,
						new SqlParameter("@BinaryDataId", row.BinaryDataId)
,
						new SqlParameter("@MonikerId", row.MonikerId)

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
		public virtual int Update(BinaryDataMonikerContract row, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Data].[BinaryDataMoniker_Update]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataMonikerId", row.BinaryDataMonikerId)
,
						new SqlParameter("@BinaryDataId", row.BinaryDataId)
,
						new SqlParameter("@MonikerId", row.MonikerId)

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
		public virtual int UpdateAll(List<BinaryDataMonikerContract> rows)
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
		public virtual int UpdateAll(List<BinaryDataMonikerContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Update(row, connection, transaction);
			return rowCount;
		}

		/// <summary>
		/// Run BinaryDataMoniker_Delete.
		/// </summary>
		/// <returns>The number of rows affected.</returns>
		/// <param name="fldBinaryDataMonikerId">Value for BinaryDataMonikerId</param>
		public virtual int Delete(int fldBinaryDataMonikerId
)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryDataMoniker_Delete]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataMonikerId", fldBinaryDataMonikerId)

					});

					rowCount = cmd.ExecuteNonQuery();
				}
			});
			
			
			return rowCount;
		}

		/// <summary>
		/// Run BinaryDataMoniker_Delete.
		/// </summary>
		/// <param name="fldBinaryDataMonikerId">Value for BinaryDataMonikerId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Delete(int fldBinaryDataMonikerId
, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Data].[BinaryDataMoniker_Delete]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataMonikerId", fldBinaryDataMonikerId)

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
		public virtual int Delete(BinaryDataMonikerContract row)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryDataMoniker_Delete]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataMonikerId", row.BinaryDataMonikerId)

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
		public virtual int Delete(BinaryDataMonikerContract row, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Data].[BinaryDataMoniker_Delete]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataMonikerId", row.BinaryDataMonikerId)

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
		public virtual int DeleteAll(List<BinaryDataMonikerContract> rows)
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
		public virtual int DeleteAll(List<BinaryDataMonikerContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Delete(row, connection, transaction);
			return rowCount;
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldBinaryDataMonikerId">Value for BinaryDataMonikerId</param>
		/// <returns>True, if the values exist, or false.</returns>
		public virtual bool Exists(int fldBinaryDataMonikerId
)
		{
			bool result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryDataMoniker_Exists]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataMonikerId", fldBinaryDataMonikerId)

					});

					result = (bool)cmd.ExecuteScalar();
				}
			});

			return result;
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldBinaryDataMonikerId">Value for BinaryDataMonikerId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>True, if the values exist, or false.</returns>
		public virtual bool Exists(int fldBinaryDataMonikerId
, SqlConnection connection, SqlTransaction transaction)
		{					
			using (
				var cmd = new SqlCommand("[Data].[BinaryDataMoniker_Exists]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataMonikerId", fldBinaryDataMonikerId)

					});

					return (bool)cmd.ExecuteScalar();
			}
		}

		/// <summary>
		/// Run BinaryDataMoniker_SelectAll, and return results as a list of BinaryDataMonikerRow.
		/// </summary>

		/// <returns>A collection of BinaryDataMonikerRow.</returns>
		public virtual bool SelectAll()
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryDataMoniker_SelectAll]", x)
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
		/// Run BinaryDataMoniker_SelectAll, and return results as a list of BinaryDataMonikerRow.
		/// </summary>

		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of BinaryDataMonikerRow.</returns>
		public virtual bool SelectAll(SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Data].[BinaryDataMoniker_SelectAll]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run BinaryDataMoniker_SelectBy_BinaryDataMonikerId, and return results as a list of BinaryDataMonikerRow.
		/// </summary>
		/// <param name="fldBinaryDataMonikerId">Value for BinaryDataMonikerId</param>
		/// <returns>A collection of BinaryDataMonikerRow.</returns>
		public virtual bool SelectBy_BinaryDataMonikerId(int fldBinaryDataMonikerId
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryDataMoniker_SelectBy_BinaryDataMonikerId]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataMonikerId", fldBinaryDataMonikerId)

					});

					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
		}

		/// <summary>
		/// Run BinaryDataMoniker_SelectBy_BinaryDataMonikerId, and return results as a list of BinaryDataMonikerRow.
		/// </summary>
		/// <param name="fldBinaryDataMonikerId">Value for BinaryDataMonikerId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of BinaryDataMonikerRow.</returns>
		public virtual bool SelectBy_BinaryDataMonikerId(int fldBinaryDataMonikerId
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Data].[BinaryDataMoniker_SelectBy_BinaryDataMonikerId]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataMonikerId", fldBinaryDataMonikerId)

					});

				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run BinaryDataMoniker_SelectBy_BinaryDataId, and return results as a list of BinaryDataMonikerRow.
		/// </summary>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <returns>A collection of BinaryDataMonikerRow.</returns>
		public virtual bool SelectBy_BinaryDataId(int fldBinaryDataId
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryDataMoniker_SelectBy_BinaryDataId]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataId", fldBinaryDataId)

					});

					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
		}

		/// <summary>
		/// Run BinaryDataMoniker_SelectBy_BinaryDataId, and return results as a list of BinaryDataMonikerRow.
		/// </summary>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of BinaryDataMonikerRow.</returns>
		public virtual bool SelectBy_BinaryDataId(int fldBinaryDataId
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Data].[BinaryDataMoniker_SelectBy_BinaryDataId]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataId", fldBinaryDataId)

					});

				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run BinaryDataMoniker_SelectBy_MonikerId, and return results as a list of BinaryDataMonikerRow.
		/// </summary>
		/// <param name="fldMonikerId">Value for MonikerId</param>
		/// <returns>A collection of BinaryDataMonikerRow.</returns>
		public virtual bool SelectBy_MonikerId(int fldMonikerId
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryDataMoniker_SelectBy_MonikerId]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@MonikerId", fldMonikerId)

					});

					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
		}

		/// <summary>
		/// Run BinaryDataMoniker_SelectBy_MonikerId, and return results as a list of BinaryDataMonikerRow.
		/// </summary>
		/// <param name="fldMonikerId">Value for MonikerId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of BinaryDataMonikerRow.</returns>
		public virtual bool SelectBy_MonikerId(int fldMonikerId
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Data].[BinaryDataMoniker_SelectBy_MonikerId]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@MonikerId", fldMonikerId)

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
					new BinaryDataMonikerContract
					{
					BinaryDataMonikerId = reader.GetInt32(0),
					BinaryDataId = reader.GetInt32(1),
					MonikerId = reader.GetInt32(2),

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
		public virtual int Save(BinaryDataMonikerContract row)
		{
			if(row == null) return 0;
			if(row.BinaryDataMonikerId != null) return Update(row);
			
			return Insert(row);
		}

		/// <summary>
		/// Saves the row, either by inserting (when the identity key is null) or by updating (identity key has value).
		/// </summary>
		/// <param name="row">The data to save</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Save(BinaryDataMonikerContract row, SqlConnection connection, SqlTransaction transaction)
		{
			if(row == null) return 0;
			if(row.BinaryDataMonikerId != null) return Update(row, connection, transaction);
			
			return Insert(row, connection, transaction);
		}		

		/// <summary>
		/// Save the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Save</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int SaveAll(List<BinaryDataMonikerContract> rows)
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
		public virtual int SaveAll(List<BinaryDataMonikerContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Save(row, connection, transaction);
			return rowCount;
		}
	}
}