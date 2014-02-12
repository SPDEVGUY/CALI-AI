using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CALI.Database.Contracts;
using CALI.Database.Contracts.Data;

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This file contains static implementations of the MonikerLogic
// Add your own static methods by making a new partial class.
// You cannot override static methods, instead override the methods
// located in MonikerLogicBase by making a partial class of MonikerLogic
// and overriding the base methods.

namespace CALI.Database.Logic.Data
{
	public partial class MonikerLogic
	{
		//Put your code in a separate file.  This is auto generated.
		/// <summary>
		/// Run Moniker_Insert.
		/// </summary>
		/// <param name="fldText">Value for Text</param>
		/// <param name="fldAliasForMoniker">Value for AliasForMoniker</param>
		/// <param name="fldDateCreated">Value for DateCreated</param>
		public static int? InsertNow(string fldText
, int fldAliasForMoniker
, DateTime fldDateCreated
)
		{
			return (new MonikerLogic()).Insert(fldText
, fldAliasForMoniker
, fldDateCreated
);
		}
		/// <summary>
		/// Run Moniker_Insert.
		/// </summary>
		/// <param name="fldText">Value for Text</param>
		/// <param name="fldAliasForMoniker">Value for AliasForMoniker</param>
		/// <param name="fldDateCreated">Value for DateCreated</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		public static int? InsertNow(string fldText
, int fldAliasForMoniker
, DateTime fldDateCreated
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new MonikerLogic()).Insert(fldText
, fldAliasForMoniker
, fldDateCreated
, connection, transaction);
		}

		/// <summary>
		/// Insert by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertNow(MonikerContract row)
		{
			return (new MonikerLogic()).Insert(row);
		}

		/// <summary>
		/// Insert by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertNow(MonikerContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new MonikerLogic()).Insert(row, connection, transaction);
		}

		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertAllNow(List<MonikerContract> rows)
		{
			return (new MonikerLogic()).InsertAll(rows);
		}

		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertAllNow(List<MonikerContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new MonikerLogic()).InsertAll(rows, connection, transaction);
		}
		/// <summary>
		/// Run Moniker_Update.
		/// </summary>
		/// <param name="fldMonikerId">Value for MonikerId</param>
		/// <param name="fldText">Value for Text</param>
		/// <param name="fldAliasForMoniker">Value for AliasForMoniker</param>
		/// <param name="fldDateCreated">Value for DateCreated</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(int fldMonikerId
, string fldText
, int fldAliasForMoniker
, DateTime fldDateCreated
)
		{
			return (new MonikerLogic()).Update(fldMonikerId
, fldText
, fldAliasForMoniker
, fldDateCreated
);
		}

		/// <summary>
		/// Run Moniker_Update.
		/// </summary>
		/// <param name="fldMonikerId">Value for MonikerId</param>
		/// <param name="fldText">Value for Text</param>
		/// <param name="fldAliasForMoniker">Value for AliasForMoniker</param>
		/// <param name="fldDateCreated">Value for DateCreated</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(int fldMonikerId
, string fldText
, int fldAliasForMoniker
, DateTime fldDateCreated
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new MonikerLogic()).Update(fldMonikerId
, fldText
, fldAliasForMoniker
, fldDateCreated
, connection, transaction);
		}
		/// <summary>
		/// Update by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(MonikerContract row)
		{
			return (new MonikerLogic()).Update(row);
		}

		/// <summary>
		/// Update by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(MonikerContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new MonikerLogic()).Update(row, connection, transaction);
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateAllNow(List<MonikerContract> rows)
		{
			return (new MonikerLogic()).UpdateAll(rows);
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateAllNow(List<MonikerContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new MonikerLogic()).UpdateAll(rows, connection, transaction);
		}
		/// <summary>
		/// Run Moniker_Delete.
		/// </summary>
		/// <param name="fldMonikerId">Value for MonikerId</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(int fldMonikerId
)
		{
			return (new MonikerLogic()).Delete(fldMonikerId
);
		}

		/// <summary>
		/// Run Moniker_Delete.
		/// </summary>
		/// <param name="fldMonikerId">Value for MonikerId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(int fldMonikerId
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new MonikerLogic()).Delete(fldMonikerId
, connection, transaction);
		}
		/// <summary>
		/// Delete by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(MonikerContract row)
		{
			return (new MonikerLogic()).Delete(row);
		}

		/// <summary>
		/// Delete by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(MonikerContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new MonikerLogic()).Delete(row, connection, transaction);
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteAllNow(List<MonikerContract> rows)
		{
			return (new MonikerLogic()).DeleteAll(rows);
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteAllNow(List<MonikerContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new MonikerLogic()).DeleteAll(rows, connection, transaction);
		}
		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldMonikerId">Value for MonikerId</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldMonikerId
)
		{
			return (new MonikerLogic()).Exists(fldMonikerId
);
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldMonikerId">Value for MonikerId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldMonikerId
, SqlConnection connection, SqlTransaction transaction)
		{					
			return (new MonikerLogic()).Exists(fldMonikerId
, connection, transaction);
		}

		/// <summary>
		/// Run Moniker_Search, and return results as a list of MonikerRow.
		/// </summary>
		/// <param name="fldText">Value for Text</param>
		/// <returns>A collection of MonikerRow.</returns>
		public static List<MonikerContract> SearchNow(string fldText
)
		{
			var driver = new MonikerLogic();
			driver.Search(fldText
);
			return driver.Results;
		}

		/// <summary>
		/// Run Moniker_Search, and return results as a list of MonikerRow.
		/// </summary>
		/// <param name="fldText">Value for Text</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of MonikerRow.</returns>
		public static List<MonikerContract> SearchNow(string fldText
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new MonikerLogic();
			driver.Search(fldText
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run Moniker_SelectAll, and return results as a list of MonikerRow.
		/// </summary>

		/// <returns>A collection of MonikerRow.</returns>
		public static List<MonikerContract> SelectAllNow()
		{			
			var driver = new MonikerLogic();
			driver.SelectAll();
			return driver.Results;
		}

		/// <summary>
		/// Run Moniker_SelectAll, and return results as a list of MonikerRow.
		/// </summary>

		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of MonikerRow.</returns>
		public static List<MonikerContract> SelectAllNow(SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new MonikerLogic();
			driver.SelectAll(connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run Moniker_SelectBy_MonikerId, and return results as a list of MonikerRow.
		/// </summary>
		/// <param name="fldMonikerId">Value for MonikerId</param>
		/// <returns>A collection of MonikerRow.</returns>
		public static List<MonikerContract> SelectBy_MonikerIdNow(int fldMonikerId
)
		{
			var driver = new MonikerLogic();
			driver.SelectBy_MonikerId(fldMonikerId
);
			return driver.Results;
		}

		/// <summary>
		/// Run Moniker_SelectBy_MonikerId, and return results as a list of MonikerRow.
		/// </summary>
		/// <param name="fldMonikerId">Value for MonikerId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of MonikerRow.</returns>
		public static List<MonikerContract> SelectBy_MonikerIdNow(int fldMonikerId
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new MonikerLogic();
			driver.SelectBy_MonikerId(fldMonikerId
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run Moniker_SelectBy_Text, and return results as a list of MonikerRow.
		/// </summary>
		/// <param name="fldText">Value for Text</param>
		/// <returns>A collection of MonikerRow.</returns>
		public static List<MonikerContract> SelectBy_TextNow(string fldText
)
		{
			var driver = new MonikerLogic();
			driver.SelectBy_Text(fldText
);
			return driver.Results;
		}

		/// <summary>
		/// Run Moniker_SelectBy_Text, and return results as a list of MonikerRow.
		/// </summary>
		/// <param name="fldText">Value for Text</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of MonikerRow.</returns>
		public static List<MonikerContract> SelectBy_TextNow(string fldText
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new MonikerLogic();
			driver.SelectBy_Text(fldText
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Read all Moniker rows from the provided reader into the list structure of MonikerRows
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>
		/// <returns>A populated MonikerRows or an empty MonikerRows if there are no results.</returns>
		public static List<MonikerContract> ReadAllNow(SqlDataReader reader)
		{
			var driver = new MonikerLogic();

			driver.ReadAll(reader);
			
			return driver.Results;
		}
		/// <summary>");
		/// Advance one, and read values into a Moniker
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>");
		/// <returns>A Moniker or null if there are no results.</returns>
		public static MonikerContract ReadOneNow(SqlDataReader reader)
		{
			var driver = new MonikerLogic();			
		    return driver.ReadOne(reader) ? driver.Results[0] : null;
		}
		/// <summary>
		/// Saves the row, either by inserting (when the identity key is null) or by updating (identity key has value).
		/// </summary>
		/// <param name="row">The data to save</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveNow(MonikerContract row)
		{
			if(row.MonikerId == null)
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
		public static int SaveNow(MonikerContract row, SqlConnection connection, SqlTransaction transaction)
		{
			if(row.MonikerId == null)
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
		public static int SaveAllNow(List<MonikerContract> rows)
		{
			return (new MonikerLogic()).SaveAll(rows);
		}

		/// <summary>
		/// Save the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Save</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveAllNow(List<MonikerContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new MonikerLogic()).SaveAll(rows, connection, transaction);
		}        
	}
}