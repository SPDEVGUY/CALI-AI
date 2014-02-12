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
	public abstract partial class BinaryDataLogicBase : LogicBase<BinaryDataLogicBase>
	{
		//Put your code in a separate file.  This is auto generated.
    
		[XmlArray] public List<BinaryDataContract> Results;

		public BinaryDataLogicBase()
		{
			Results =  new List<BinaryDataContract>();
		}

		/// <summary>
		/// Run BinaryData_Insert.
		/// </summary>
		/// <param name="fldDataType">Value for DataType</param>
		/// <param name="fldHash">Value for Hash</param>
		/// <param name="fldData">Value for Data</param>
		/// <param name="fldDateCreated">Value for DateCreated</param>
		/// <returns>The new ID</returns>
		public virtual int? Insert(string fldDataType
, string fldHash
, byte[] fldData
, DateTime fldDateCreated
)
		{
			int? result = null;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryData_Insert]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@DataType", fldDataType)
,
						new SqlParameter("@Hash", fldHash)
,
						new SqlParameter("@Data", fldData)
,
						new SqlParameter("@DateCreated", fldDateCreated)

					});

					result = (int?)cmd.ExecuteScalar();
				}
			});
			return result;
		}

		/// <summary>
		/// Run BinaryData_Insert.
		/// </summary>
		/// <param name="fldDataType">Value for DataType</param>
		/// <param name="fldHash">Value for Hash</param>
		/// <param name="fldData">Value for Data</param>
		/// <param name="fldDateCreated">Value for DateCreated</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The new ID</returns>
		public virtual int? Insert(string fldDataType
, string fldHash
, byte[] fldData
, DateTime fldDateCreated
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Data].[BinaryData_Insert]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@DataType", fldDataType)
,
						new SqlParameter("@Hash", fldHash)
,
						new SqlParameter("@Data", fldData)
,
						new SqlParameter("@DateCreated", fldDateCreated)

					});

				return (int?)cmd.ExecuteScalar();
			}
		}

		/// <summary>
		/// Insert by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>1, if insert was successful</returns>
		public int Insert(BinaryDataContract row)
		{
			int? result = null;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryData_Insert]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@DataType", row.DataType)
,
						new SqlParameter("@Hash", row.Hash)
,
						new SqlParameter("@Data", row.Data)
,
						new SqlParameter("@DateCreated", row.DateCreated)

					});
            
					result = (int?)cmd.ExecuteScalar();
					row.BinaryDataId = result;
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
		public int Insert(BinaryDataContract row, SqlConnection connection, SqlTransaction transaction)
		{
			int? result = null;
			using (
				var cmd = new SqlCommand("[Data].[BinaryData_Insert]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@DataType", row.DataType)
,
						new SqlParameter("@Hash", row.Hash)
,
						new SqlParameter("@Data", row.Data)
,
						new SqlParameter("@DateCreated", row.DateCreated)

					});
            
				result = (int?)cmd.ExecuteScalar();
				row.BinaryDataId = result;
			}
			return result != null ? 1 : 0;
		}
		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int InsertAll(List<BinaryDataContract> rows)
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
		public virtual int InsertAll(List<BinaryDataContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Insert(row, connection, transaction);
			return rowCount;
		}

		/// <summary>
		/// Run BinaryData_Update.
		/// </summary>
		/// <returns>The number of rows affected.</returns>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <param name="fldDataType">Value for DataType</param>
		/// <param name="fldHash">Value for Hash</param>
		/// <param name="fldData">Value for Data</param>
		/// <param name="fldDateCreated">Value for DateCreated</param>
		public virtual int Update(int fldBinaryDataId
, string fldDataType
, string fldHash
, byte[] fldData
, DateTime fldDateCreated
)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryData_Update]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataId", fldBinaryDataId)
,
						new SqlParameter("@DataType", fldDataType)
,
						new SqlParameter("@Hash", fldHash)
,
						new SqlParameter("@Data", fldData)
,
						new SqlParameter("@DateCreated", fldDateCreated)

					});

					rowCount = cmd.ExecuteNonQuery();
				}
			});
			
			
			return rowCount;
		}

		/// <summary>
		/// Run BinaryData_Update.
		/// </summary>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <param name="fldDataType">Value for DataType</param>
		/// <param name="fldHash">Value for Hash</param>
		/// <param name="fldData">Value for Data</param>
		/// <param name="fldDateCreated">Value for DateCreated</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Update(int fldBinaryDataId
, string fldDataType
, string fldHash
, byte[] fldData
, DateTime fldDateCreated
, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Data].[BinaryData_Update]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataId", fldBinaryDataId)
,
						new SqlParameter("@DataType", fldDataType)
,
						new SqlParameter("@Hash", fldHash)
,
						new SqlParameter("@Data", fldData)
,
						new SqlParameter("@DateCreated", fldDateCreated)

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
		public virtual int Update(BinaryDataContract row)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryData_Update]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataId", row.BinaryDataId)
,
						new SqlParameter("@DataType", row.DataType)
,
						new SqlParameter("@Hash", row.Hash)
,
						new SqlParameter("@Data", row.Data)
,
						new SqlParameter("@DateCreated", row.DateCreated)

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
		public virtual int Update(BinaryDataContract row, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Data].[BinaryData_Update]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataId", row.BinaryDataId)
,
						new SqlParameter("@DataType", row.DataType)
,
						new SqlParameter("@Hash", row.Hash)
,
						new SqlParameter("@Data", row.Data)
,
						new SqlParameter("@DateCreated", row.DateCreated)

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
		public virtual int UpdateAll(List<BinaryDataContract> rows)
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
		public virtual int UpdateAll(List<BinaryDataContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Update(row, connection, transaction);
			return rowCount;
		}

		/// <summary>
		/// Run BinaryData_Delete.
		/// </summary>
		/// <returns>The number of rows affected.</returns>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		public virtual int Delete(int fldBinaryDataId
)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryData_Delete]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataId", fldBinaryDataId)

					});

					rowCount = cmd.ExecuteNonQuery();
				}
			});
			
			
			return rowCount;
		}

		/// <summary>
		/// Run BinaryData_Delete.
		/// </summary>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Delete(int fldBinaryDataId
, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Data].[BinaryData_Delete]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataId", fldBinaryDataId)

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
		public virtual int Delete(BinaryDataContract row)
		{
			var rowCount = 0;
			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryData_Delete]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataId", row.BinaryDataId)

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
		public virtual int Delete(BinaryDataContract row, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			using (
				var cmd = new SqlCommand("[Data].[BinaryData_Delete]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataId", row.BinaryDataId)

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
		public virtual int DeleteAll(List<BinaryDataContract> rows)
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
		public virtual int DeleteAll(List<BinaryDataContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Delete(row, connection, transaction);
			return rowCount;
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <returns>True, if the values exist, or false.</returns>
		public virtual bool Exists(int fldBinaryDataId
)
		{
			bool result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryData_Exists]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataId", fldBinaryDataId)

					});

					result = (bool)cmd.ExecuteScalar();
				}
			});

			return result;
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>True, if the values exist, or false.</returns>
		public virtual bool Exists(int fldBinaryDataId
, SqlConnection connection, SqlTransaction transaction)
		{					
			using (
				var cmd = new SqlCommand("[Data].[BinaryData_Exists]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataId", fldBinaryDataId)

					});

					return (bool)cmd.ExecuteScalar();
			}
		}

		/// <summary>
		/// Run BinaryData_Search, and return results as a list of BinaryDataRow.
		/// </summary>
		/// <param name="fldDataType">Value for DataType</param>
		/// <param name="fldHash">Value for Hash</param>
		/// <returns>A collection of BinaryDataRow.</returns>
		public virtual bool Search(string fldDataType
, string fldHash
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryData_Search]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@DataType", fldDataType)
,
						new SqlParameter("@Hash", fldHash)

					});

					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
		}

		/// <summary>
		/// Run BinaryData_Search, and return results as a list of BinaryDataRow.
		/// </summary>
		/// <param name="fldDataType">Value for DataType</param>
		/// <param name="fldHash">Value for Hash</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of BinaryDataRow.</returns>
		public virtual bool Search(string fldDataType
, string fldHash
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Data].[BinaryData_Search]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@DataType", fldDataType)
,
						new SqlParameter("@Hash", fldHash)

					});

				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run BinaryData_SelectAll, and return results as a list of BinaryDataRow.
		/// </summary>

		/// <returns>A collection of BinaryDataRow.</returns>
		public virtual bool SelectAll()
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryData_SelectAll]", x)
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
		/// Run BinaryData_SelectAll, and return results as a list of BinaryDataRow.
		/// </summary>

		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of BinaryDataRow.</returns>
		public virtual bool SelectAll(SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Data].[BinaryData_SelectAll]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run BinaryData_SelectBy_BinaryDataId, and return results as a list of BinaryDataRow.
		/// </summary>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <returns>A collection of BinaryDataRow.</returns>
		public virtual bool SelectBy_BinaryDataId(int fldBinaryDataId
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryData_SelectBy_BinaryDataId]", x)
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
		/// Run BinaryData_SelectBy_BinaryDataId, and return results as a list of BinaryDataRow.
		/// </summary>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of BinaryDataRow.</returns>
		public virtual bool SelectBy_BinaryDataId(int fldBinaryDataId
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Data].[BinaryData_SelectBy_BinaryDataId]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@BinaryDataId", fldBinaryDataId)

					});

				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run BinaryData_SelectBy_Hash, and return results as a list of BinaryDataRow.
		/// </summary>
		/// <param name="fldHash">Value for Hash</param>
		/// <returns>A collection of BinaryDataRow.</returns>
		public virtual bool SelectBy_Hash(string fldHash
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Data].[BinaryData_SelectBy_Hash]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@Hash", fldHash)

					});

					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
		}

		/// <summary>
		/// Run BinaryData_SelectBy_Hash, and return results as a list of BinaryDataRow.
		/// </summary>
		/// <param name="fldHash">Value for Hash</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of BinaryDataRow.</returns>
		public virtual bool SelectBy_Hash(string fldHash
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Data].[BinaryData_SelectBy_Hash]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@Hash", fldHash)

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
					new BinaryDataContract
					{
					BinaryDataId = reader.GetInt32(0),
					DataType = reader.GetString(1),
					Hash = reader.IsDBNull(2) ? null : reader.GetString(2),
					Data = (byte[])reader.GetValue(3),
					DateCreated = reader.GetDateTime(4),

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
		public virtual int Save(BinaryDataContract row)
		{
			if(row == null) return 0;
			if(row.BinaryDataId != null) return Update(row);
			
			return Insert(row);
		}

		/// <summary>
		/// Saves the row, either by inserting (when the identity key is null) or by updating (identity key has value).
		/// </summary>
		/// <param name="row">The data to save</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int Save(BinaryDataContract row, SqlConnection connection, SqlTransaction transaction)
		{
			if(row == null) return 0;
			if(row.BinaryDataId != null) return Update(row, connection, transaction);
			
			return Insert(row, connection, transaction);
		}		

		/// <summary>
		/// Save the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Save</param>
		/// <returns>The number of rows affected.</returns>
		public virtual int SaveAll(List<BinaryDataContract> rows)
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
		public virtual int SaveAll(List<BinaryDataContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			var rowCount = 0;
			foreach(var row in rows) rowCount += Save(row, connection, transaction);
			return rowCount;
		}
	}
}