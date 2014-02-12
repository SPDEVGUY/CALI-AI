using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CALI.Database.Contracts;
using CALI.Database.Contracts.Data;

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This file contains static implementations of the BinaryDataLogic
// Add your own static methods by making a new partial class.
// You cannot override static methods, instead override the methods
// located in BinaryDataLogicBase by making a partial class of BinaryDataLogic
// and overriding the base methods.

namespace CALI.Database.Logic.Data
{
	public partial class BinaryDataLogic
	{
		//Put your code in a separate file.  This is auto generated.
		/// <summary>
		/// Run BinaryData_Insert.
		/// </summary>
		/// <param name="fldDataType">Value for DataType</param>
		/// <param name="fldHash">Value for Hash</param>
		/// <param name="fldData">Value for Data</param>
		/// <param name="fldDateCreated">Value for DateCreated</param>
		public static int? InsertNow(string fldDataType
, string fldHash
, byte[] fldData
, DateTime fldDateCreated
)
		{
			return (new BinaryDataLogic()).Insert(fldDataType
, fldHash
, fldData
, fldDateCreated
);
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
		public static int? InsertNow(string fldDataType
, string fldHash
, byte[] fldData
, DateTime fldDateCreated
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new BinaryDataLogic()).Insert(fldDataType
, fldHash
, fldData
, fldDateCreated
, connection, transaction);
		}

		/// <summary>
		/// Insert by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertNow(BinaryDataContract row)
		{
			return (new BinaryDataLogic()).Insert(row);
		}

		/// <summary>
		/// Insert by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertNow(BinaryDataContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new BinaryDataLogic()).Insert(row, connection, transaction);
		}

		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertAllNow(List<BinaryDataContract> rows)
		{
			return (new BinaryDataLogic()).InsertAll(rows);
		}

		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertAllNow(List<BinaryDataContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new BinaryDataLogic()).InsertAll(rows, connection, transaction);
		}
		/// <summary>
		/// Run BinaryData_Update.
		/// </summary>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <param name="fldDataType">Value for DataType</param>
		/// <param name="fldHash">Value for Hash</param>
		/// <param name="fldData">Value for Data</param>
		/// <param name="fldDateCreated">Value for DateCreated</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(int fldBinaryDataId
, string fldDataType
, string fldHash
, byte[] fldData
, DateTime fldDateCreated
)
		{
			return (new BinaryDataLogic()).Update(fldBinaryDataId
, fldDataType
, fldHash
, fldData
, fldDateCreated
);
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
		public static int UpdateNow(int fldBinaryDataId
, string fldDataType
, string fldHash
, byte[] fldData
, DateTime fldDateCreated
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new BinaryDataLogic()).Update(fldBinaryDataId
, fldDataType
, fldHash
, fldData
, fldDateCreated
, connection, transaction);
		}
		/// <summary>
		/// Update by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(BinaryDataContract row)
		{
			return (new BinaryDataLogic()).Update(row);
		}

		/// <summary>
		/// Update by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(BinaryDataContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new BinaryDataLogic()).Update(row, connection, transaction);
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateAllNow(List<BinaryDataContract> rows)
		{
			return (new BinaryDataLogic()).UpdateAll(rows);
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateAllNow(List<BinaryDataContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new BinaryDataLogic()).UpdateAll(rows, connection, transaction);
		}
		/// <summary>
		/// Run BinaryData_Delete.
		/// </summary>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(int fldBinaryDataId
)
		{
			return (new BinaryDataLogic()).Delete(fldBinaryDataId
);
		}

		/// <summary>
		/// Run BinaryData_Delete.
		/// </summary>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(int fldBinaryDataId
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new BinaryDataLogic()).Delete(fldBinaryDataId
, connection, transaction);
		}
		/// <summary>
		/// Delete by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(BinaryDataContract row)
		{
			return (new BinaryDataLogic()).Delete(row);
		}

		/// <summary>
		/// Delete by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(BinaryDataContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new BinaryDataLogic()).Delete(row, connection, transaction);
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteAllNow(List<BinaryDataContract> rows)
		{
			return (new BinaryDataLogic()).DeleteAll(rows);
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteAllNow(List<BinaryDataContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new BinaryDataLogic()).DeleteAll(rows, connection, transaction);
		}
		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldBinaryDataId
)
		{
			return (new BinaryDataLogic()).Exists(fldBinaryDataId
);
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldBinaryDataId
, SqlConnection connection, SqlTransaction transaction)
		{					
			return (new BinaryDataLogic()).Exists(fldBinaryDataId
, connection, transaction);
		}

		/// <summary>
		/// Run BinaryData_Search, and return results as a list of BinaryDataRow.
		/// </summary>
		/// <param name="fldDataType">Value for DataType</param>
		/// <param name="fldHash">Value for Hash</param>
		/// <returns>A collection of BinaryDataRow.</returns>
		public static List<BinaryDataContract> SearchNow(string fldDataType
, string fldHash
)
		{
			var driver = new BinaryDataLogic();
			driver.Search(fldDataType
, fldHash
);
			return driver.Results;
		}

		/// <summary>
		/// Run BinaryData_Search, and return results as a list of BinaryDataRow.
		/// </summary>
		/// <param name="fldDataType">Value for DataType</param>
		/// <param name="fldHash">Value for Hash</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of BinaryDataRow.</returns>
		public static List<BinaryDataContract> SearchNow(string fldDataType
, string fldHash
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new BinaryDataLogic();
			driver.Search(fldDataType
, fldHash
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run BinaryData_SelectAll, and return results as a list of BinaryDataRow.
		/// </summary>

		/// <returns>A collection of BinaryDataRow.</returns>
		public static List<BinaryDataContract> SelectAllNow()
		{			
			var driver = new BinaryDataLogic();
			driver.SelectAll();
			return driver.Results;
		}

		/// <summary>
		/// Run BinaryData_SelectAll, and return results as a list of BinaryDataRow.
		/// </summary>

		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of BinaryDataRow.</returns>
		public static List<BinaryDataContract> SelectAllNow(SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new BinaryDataLogic();
			driver.SelectAll(connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run BinaryData_SelectBy_BinaryDataId, and return results as a list of BinaryDataRow.
		/// </summary>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <returns>A collection of BinaryDataRow.</returns>
		public static List<BinaryDataContract> SelectBy_BinaryDataIdNow(int fldBinaryDataId
)
		{
			var driver = new BinaryDataLogic();
			driver.SelectBy_BinaryDataId(fldBinaryDataId
);
			return driver.Results;
		}

		/// <summary>
		/// Run BinaryData_SelectBy_BinaryDataId, and return results as a list of BinaryDataRow.
		/// </summary>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of BinaryDataRow.</returns>
		public static List<BinaryDataContract> SelectBy_BinaryDataIdNow(int fldBinaryDataId
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new BinaryDataLogic();
			driver.SelectBy_BinaryDataId(fldBinaryDataId
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run BinaryData_SelectBy_Hash, and return results as a list of BinaryDataRow.
		/// </summary>
		/// <param name="fldHash">Value for Hash</param>
		/// <returns>A collection of BinaryDataRow.</returns>
		public static List<BinaryDataContract> SelectBy_HashNow(string fldHash
)
		{
			var driver = new BinaryDataLogic();
			driver.SelectBy_Hash(fldHash
);
			return driver.Results;
		}

		/// <summary>
		/// Run BinaryData_SelectBy_Hash, and return results as a list of BinaryDataRow.
		/// </summary>
		/// <param name="fldHash">Value for Hash</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of BinaryDataRow.</returns>
		public static List<BinaryDataContract> SelectBy_HashNow(string fldHash
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new BinaryDataLogic();
			driver.SelectBy_Hash(fldHash
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Read all BinaryData rows from the provided reader into the list structure of BinaryDataRows
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>
		/// <returns>A populated BinaryDataRows or an empty BinaryDataRows if there are no results.</returns>
		public static List<BinaryDataContract> ReadAllNow(SqlDataReader reader)
		{
			var driver = new BinaryDataLogic();

			driver.ReadAll(reader);
			
			return driver.Results;
		}
		/// <summary>");
		/// Advance one, and read values into a BinaryData
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>");
		/// <returns>A BinaryData or null if there are no results.</returns>
		public static BinaryDataContract ReadOneNow(SqlDataReader reader)
		{
			var driver = new BinaryDataLogic();			
		    return driver.ReadOne(reader) ? driver.Results[0] : null;
		}
		/// <summary>
		/// Saves the row, either by inserting (when the identity key is null) or by updating (identity key has value).
		/// </summary>
		/// <param name="row">The data to save</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveNow(BinaryDataContract row)
		{
			if(row.BinaryDataId == null)
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
		public static int SaveNow(BinaryDataContract row, SqlConnection connection, SqlTransaction transaction)
		{
			if(row.BinaryDataId == null)
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
		public static int SaveAllNow(List<BinaryDataContract> rows)
		{
			return (new BinaryDataLogic()).SaveAll(rows);
		}

		/// <summary>
		/// Save the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Save</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveAllNow(List<BinaryDataContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new BinaryDataLogic()).SaveAll(rows, connection, transaction);
		}        
	}
}