using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CALI.Database.Contracts;
using CALI.Database.Contracts.Data;

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This file contains static implementations of the BinaryDataMonikerLogic
// Add your own static methods by making a new partial class.
// You cannot override static methods, instead override the methods
// located in BinaryDataMonikerLogicBase by making a partial class of BinaryDataMonikerLogic
// and overriding the base methods.

namespace CALI.Database.Logic.Data
{
	public partial class BinaryDataMonikerLogic
	{
		//Put your code in a separate file.  This is auto generated.
		/// <summary>
		/// Run BinaryDataMoniker_Insert.
		/// </summary>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <param name="fldMonikerId">Value for MonikerId</param>
		public static int? InsertNow(int fldBinaryDataId
, int fldMonikerId
)
		{
			return (new BinaryDataMonikerLogic()).Insert(fldBinaryDataId
, fldMonikerId
);
		}
		/// <summary>
		/// Run BinaryDataMoniker_Insert.
		/// </summary>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <param name="fldMonikerId">Value for MonikerId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		public static int? InsertNow(int fldBinaryDataId
, int fldMonikerId
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new BinaryDataMonikerLogic()).Insert(fldBinaryDataId
, fldMonikerId
, connection, transaction);
		}

		/// <summary>
		/// Insert by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertNow(BinaryDataMonikerContract row)
		{
			return (new BinaryDataMonikerLogic()).Insert(row);
		}

		/// <summary>
		/// Insert by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertNow(BinaryDataMonikerContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new BinaryDataMonikerLogic()).Insert(row, connection, transaction);
		}

		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertAllNow(List<BinaryDataMonikerContract> rows)
		{
			return (new BinaryDataMonikerLogic()).InsertAll(rows);
		}

		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertAllNow(List<BinaryDataMonikerContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new BinaryDataMonikerLogic()).InsertAll(rows, connection, transaction);
		}
		/// <summary>
		/// Run BinaryDataMoniker_Update.
		/// </summary>
		/// <param name="fldBinaryDataMonikerId">Value for BinaryDataMonikerId</param>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <param name="fldMonikerId">Value for MonikerId</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(int fldBinaryDataMonikerId
, int fldBinaryDataId
, int fldMonikerId
)
		{
			return (new BinaryDataMonikerLogic()).Update(fldBinaryDataMonikerId
, fldBinaryDataId
, fldMonikerId
);
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
		public static int UpdateNow(int fldBinaryDataMonikerId
, int fldBinaryDataId
, int fldMonikerId
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new BinaryDataMonikerLogic()).Update(fldBinaryDataMonikerId
, fldBinaryDataId
, fldMonikerId
, connection, transaction);
		}
		/// <summary>
		/// Update by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(BinaryDataMonikerContract row)
		{
			return (new BinaryDataMonikerLogic()).Update(row);
		}

		/// <summary>
		/// Update by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(BinaryDataMonikerContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new BinaryDataMonikerLogic()).Update(row, connection, transaction);
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateAllNow(List<BinaryDataMonikerContract> rows)
		{
			return (new BinaryDataMonikerLogic()).UpdateAll(rows);
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateAllNow(List<BinaryDataMonikerContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new BinaryDataMonikerLogic()).UpdateAll(rows, connection, transaction);
		}
		/// <summary>
		/// Run BinaryDataMoniker_Delete.
		/// </summary>
		/// <param name="fldBinaryDataMonikerId">Value for BinaryDataMonikerId</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(int fldBinaryDataMonikerId
)
		{
			return (new BinaryDataMonikerLogic()).Delete(fldBinaryDataMonikerId
);
		}

		/// <summary>
		/// Run BinaryDataMoniker_Delete.
		/// </summary>
		/// <param name="fldBinaryDataMonikerId">Value for BinaryDataMonikerId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(int fldBinaryDataMonikerId
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new BinaryDataMonikerLogic()).Delete(fldBinaryDataMonikerId
, connection, transaction);
		}
		/// <summary>
		/// Delete by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(BinaryDataMonikerContract row)
		{
			return (new BinaryDataMonikerLogic()).Delete(row);
		}

		/// <summary>
		/// Delete by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(BinaryDataMonikerContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new BinaryDataMonikerLogic()).Delete(row, connection, transaction);
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteAllNow(List<BinaryDataMonikerContract> rows)
		{
			return (new BinaryDataMonikerLogic()).DeleteAll(rows);
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteAllNow(List<BinaryDataMonikerContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new BinaryDataMonikerLogic()).DeleteAll(rows, connection, transaction);
		}
		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldBinaryDataMonikerId">Value for BinaryDataMonikerId</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldBinaryDataMonikerId
)
		{
			return (new BinaryDataMonikerLogic()).Exists(fldBinaryDataMonikerId
);
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldBinaryDataMonikerId">Value for BinaryDataMonikerId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldBinaryDataMonikerId
, SqlConnection connection, SqlTransaction transaction)
		{					
			return (new BinaryDataMonikerLogic()).Exists(fldBinaryDataMonikerId
, connection, transaction);
		}

		/// <summary>
		/// Run BinaryDataMoniker_SelectAll, and return results as a list of BinaryDataMonikerRow.
		/// </summary>

		/// <returns>A collection of BinaryDataMonikerRow.</returns>
		public static List<BinaryDataMonikerContract> SelectAllNow()
		{			
			var driver = new BinaryDataMonikerLogic();
			driver.SelectAll();
			return driver.Results;
		}

		/// <summary>
		/// Run BinaryDataMoniker_SelectAll, and return results as a list of BinaryDataMonikerRow.
		/// </summary>

		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of BinaryDataMonikerRow.</returns>
		public static List<BinaryDataMonikerContract> SelectAllNow(SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new BinaryDataMonikerLogic();
			driver.SelectAll(connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run BinaryDataMoniker_SelectBy_BinaryDataMonikerId, and return results as a list of BinaryDataMonikerRow.
		/// </summary>
		/// <param name="fldBinaryDataMonikerId">Value for BinaryDataMonikerId</param>
		/// <returns>A collection of BinaryDataMonikerRow.</returns>
		public static List<BinaryDataMonikerContract> SelectBy_BinaryDataMonikerIdNow(int fldBinaryDataMonikerId
)
		{
			var driver = new BinaryDataMonikerLogic();
			driver.SelectBy_BinaryDataMonikerId(fldBinaryDataMonikerId
);
			return driver.Results;
		}

		/// <summary>
		/// Run BinaryDataMoniker_SelectBy_BinaryDataMonikerId, and return results as a list of BinaryDataMonikerRow.
		/// </summary>
		/// <param name="fldBinaryDataMonikerId">Value for BinaryDataMonikerId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of BinaryDataMonikerRow.</returns>
		public static List<BinaryDataMonikerContract> SelectBy_BinaryDataMonikerIdNow(int fldBinaryDataMonikerId
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new BinaryDataMonikerLogic();
			driver.SelectBy_BinaryDataMonikerId(fldBinaryDataMonikerId
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run BinaryDataMoniker_SelectBy_BinaryDataId, and return results as a list of BinaryDataMonikerRow.
		/// </summary>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <returns>A collection of BinaryDataMonikerRow.</returns>
		public static List<BinaryDataMonikerContract> SelectBy_BinaryDataIdNow(int fldBinaryDataId
)
		{
			var driver = new BinaryDataMonikerLogic();
			driver.SelectBy_BinaryDataId(fldBinaryDataId
);
			return driver.Results;
		}

		/// <summary>
		/// Run BinaryDataMoniker_SelectBy_BinaryDataId, and return results as a list of BinaryDataMonikerRow.
		/// </summary>
		/// <param name="fldBinaryDataId">Value for BinaryDataId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of BinaryDataMonikerRow.</returns>
		public static List<BinaryDataMonikerContract> SelectBy_BinaryDataIdNow(int fldBinaryDataId
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new BinaryDataMonikerLogic();
			driver.SelectBy_BinaryDataId(fldBinaryDataId
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run BinaryDataMoniker_SelectBy_MonikerId, and return results as a list of BinaryDataMonikerRow.
		/// </summary>
		/// <param name="fldMonikerId">Value for MonikerId</param>
		/// <returns>A collection of BinaryDataMonikerRow.</returns>
		public static List<BinaryDataMonikerContract> SelectBy_MonikerIdNow(int fldMonikerId
)
		{
			var driver = new BinaryDataMonikerLogic();
			driver.SelectBy_MonikerId(fldMonikerId
);
			return driver.Results;
		}

		/// <summary>
		/// Run BinaryDataMoniker_SelectBy_MonikerId, and return results as a list of BinaryDataMonikerRow.
		/// </summary>
		/// <param name="fldMonikerId">Value for MonikerId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of BinaryDataMonikerRow.</returns>
		public static List<BinaryDataMonikerContract> SelectBy_MonikerIdNow(int fldMonikerId
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new BinaryDataMonikerLogic();
			driver.SelectBy_MonikerId(fldMonikerId
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Read all BinaryDataMoniker rows from the provided reader into the list structure of BinaryDataMonikerRows
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>
		/// <returns>A populated BinaryDataMonikerRows or an empty BinaryDataMonikerRows if there are no results.</returns>
		public static List<BinaryDataMonikerContract> ReadAllNow(SqlDataReader reader)
		{
			var driver = new BinaryDataMonikerLogic();

			driver.ReadAll(reader);
			
			return driver.Results;
		}
		/// <summary>");
		/// Advance one, and read values into a BinaryDataMoniker
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>");
		/// <returns>A BinaryDataMoniker or null if there are no results.</returns>
		public static BinaryDataMonikerContract ReadOneNow(SqlDataReader reader)
		{
			var driver = new BinaryDataMonikerLogic();			
		    return driver.ReadOne(reader) ? driver.Results[0] : null;
		}
		/// <summary>
		/// Saves the row, either by inserting (when the identity key is null) or by updating (identity key has value).
		/// </summary>
		/// <param name="row">The data to save</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveNow(BinaryDataMonikerContract row)
		{
			if(row.BinaryDataMonikerId == null)
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
		public static int SaveNow(BinaryDataMonikerContract row, SqlConnection connection, SqlTransaction transaction)
		{
			if(row.BinaryDataMonikerId == null)
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
		public static int SaveAllNow(List<BinaryDataMonikerContract> rows)
		{
			return (new BinaryDataMonikerLogic()).SaveAll(rows);
		}

		/// <summary>
		/// Save the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Save</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveAllNow(List<BinaryDataMonikerContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new BinaryDataMonikerLogic()).SaveAll(rows, connection, transaction);
		}        
	}
}