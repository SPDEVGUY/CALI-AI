using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CALI.Database.Contracts;
using CALI.Database.Contracts.Auth;

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This file contains static implementations of the RolePermissionLogic
// Add your own static methods by making a new partial class.
// You cannot override static methods, instead override the methods
// located in RolePermissionLogicBase by making a partial class of RolePermissionLogic
// and overriding the base methods.

namespace CALI.Database.Logic.Auth
{
	public partial class RolePermissionLogic
	{
		//Put your code in a separate file.  This is auto generated.
		/// <summary>
		/// Run RolePermission_Insert.
		/// </summary>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <param name="fldPermissionId">Value for PermissionId</param>
		public static int? InsertNow(int fldRoleId
, int fldPermissionId
)
		{
			return (new RolePermissionLogic()).Insert(fldRoleId
, fldPermissionId
);
		}
		/// <summary>
		/// Run RolePermission_Insert.
		/// </summary>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <param name="fldPermissionId">Value for PermissionId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		public static int? InsertNow(int fldRoleId
, int fldPermissionId
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new RolePermissionLogic()).Insert(fldRoleId
, fldPermissionId
, connection, transaction);
		}

		/// <summary>
		/// Insert by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertNow(RolePermissionContract row)
		{
			return (new RolePermissionLogic()).Insert(row);
		}

		/// <summary>
		/// Insert by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertNow(RolePermissionContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new RolePermissionLogic()).Insert(row, connection, transaction);
		}

		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertAllNow(List<RolePermissionContract> rows)
		{
			return (new RolePermissionLogic()).InsertAll(rows);
		}

		/// <summary>
		/// Insert the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Insert</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int InsertAllNow(List<RolePermissionContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new RolePermissionLogic()).InsertAll(rows, connection, transaction);
		}
		/// <summary>
		/// Run RolePermission_Update.
		/// </summary>
		/// <param name="fldRolePermissionId">Value for RolePermissionId</param>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <param name="fldPermissionId">Value for PermissionId</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(int fldRolePermissionId
, int fldRoleId
, int fldPermissionId
)
		{
			return (new RolePermissionLogic()).Update(fldRolePermissionId
, fldRoleId
, fldPermissionId
);
		}

		/// <summary>
		/// Run RolePermission_Update.
		/// </summary>
		/// <param name="fldRolePermissionId">Value for RolePermissionId</param>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <param name="fldPermissionId">Value for PermissionId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(int fldRolePermissionId
, int fldRoleId
, int fldPermissionId
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new RolePermissionLogic()).Update(fldRolePermissionId
, fldRoleId
, fldPermissionId
, connection, transaction);
		}
		/// <summary>
		/// Update by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(RolePermissionContract row)
		{
			return (new RolePermissionLogic()).Update(row);
		}

		/// <summary>
		/// Update by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateNow(RolePermissionContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new RolePermissionLogic()).Update(row, connection, transaction);
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateAllNow(List<RolePermissionContract> rows)
		{
			return (new RolePermissionLogic()).UpdateAll(rows);
		}

		/// <summary>
		/// Update the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Update</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int UpdateAllNow(List<RolePermissionContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new RolePermissionLogic()).UpdateAll(rows, connection, transaction);
		}
		/// <summary>
		/// Run RolePermission_Delete.
		/// </summary>
		/// <param name="fldRolePermissionId">Value for RolePermissionId</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(int fldRolePermissionId
)
		{
			return (new RolePermissionLogic()).Delete(fldRolePermissionId
);
		}

		/// <summary>
		/// Run RolePermission_Delete.
		/// </summary>
		/// <param name="fldRolePermissionId">Value for RolePermissionId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(int fldRolePermissionId
, SqlConnection connection, SqlTransaction transaction)
		{
			return (new RolePermissionLogic()).Delete(fldRolePermissionId
, connection, transaction);
		}
		/// <summary>
		/// Delete by providing a populated data row container
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(RolePermissionContract row)
		{
			return (new RolePermissionLogic()).Delete(row);
		}

		/// <summary>
		/// Delete by providing a populated data contract
		/// </summary>
		/// <param name="row">The table row data to use</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteNow(RolePermissionContract row, SqlConnection connection, SqlTransaction transaction)
		{
			return (new RolePermissionLogic()).Delete(row, connection, transaction);
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster).
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteAllNow(List<RolePermissionContract> rows)
		{
			return (new RolePermissionLogic()).DeleteAll(rows);
		}

		/// <summary>
		/// Delete the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Delete</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int DeleteAllNow(List<RolePermissionContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new RolePermissionLogic()).DeleteAll(rows, connection, transaction);
		}
		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldRolePermissionId">Value for RolePermissionId</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldRolePermissionId
)
		{
			return (new RolePermissionLogic()).Exists(fldRolePermissionId
);
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldRolePermissionId">Value for RolePermissionId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldRolePermissionId
, SqlConnection connection, SqlTransaction transaction)
		{					
			return (new RolePermissionLogic()).Exists(fldRolePermissionId
, connection, transaction);
		}

		/// <summary>
		/// Run RolePermission_SelectAll, and return results as a list of RolePermissionRow.
		/// </summary>

		/// <returns>A collection of RolePermissionRow.</returns>
		public static List<RolePermissionContract> SelectAllNow()
		{			
			var driver = new RolePermissionLogic();
			driver.SelectAll();
			return driver.Results;
		}

		/// <summary>
		/// Run RolePermission_SelectAll, and return results as a list of RolePermissionRow.
		/// </summary>

		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of RolePermissionRow.</returns>
		public static List<RolePermissionContract> SelectAllNow(SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new RolePermissionLogic();
			driver.SelectAll(connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run RolePermission_SelectBy_RolePermissionId, and return results as a list of RolePermissionRow.
		/// </summary>
		/// <param name="fldRolePermissionId">Value for RolePermissionId</param>
		/// <returns>A collection of RolePermissionRow.</returns>
		public static List<RolePermissionContract> SelectBy_RolePermissionIdNow(int fldRolePermissionId
)
		{
			var driver = new RolePermissionLogic();
			driver.SelectBy_RolePermissionId(fldRolePermissionId
);
			return driver.Results;
		}

		/// <summary>
		/// Run RolePermission_SelectBy_RolePermissionId, and return results as a list of RolePermissionRow.
		/// </summary>
		/// <param name="fldRolePermissionId">Value for RolePermissionId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of RolePermissionRow.</returns>
		public static List<RolePermissionContract> SelectBy_RolePermissionIdNow(int fldRolePermissionId
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new RolePermissionLogic();
			driver.SelectBy_RolePermissionId(fldRolePermissionId
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run RolePermission_SelectBy_RoleId, and return results as a list of RolePermissionRow.
		/// </summary>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <returns>A collection of RolePermissionRow.</returns>
		public static List<RolePermissionContract> SelectBy_RoleIdNow(int fldRoleId
)
		{
			var driver = new RolePermissionLogic();
			driver.SelectBy_RoleId(fldRoleId
);
			return driver.Results;
		}

		/// <summary>
		/// Run RolePermission_SelectBy_RoleId, and return results as a list of RolePermissionRow.
		/// </summary>
		/// <param name="fldRoleId">Value for RoleId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of RolePermissionRow.</returns>
		public static List<RolePermissionContract> SelectBy_RoleIdNow(int fldRoleId
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new RolePermissionLogic();
			driver.SelectBy_RoleId(fldRoleId
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run RolePermission_SelectBy_PermissionId, and return results as a list of RolePermissionRow.
		/// </summary>
		/// <param name="fldPermissionId">Value for PermissionId</param>
		/// <returns>A collection of RolePermissionRow.</returns>
		public static List<RolePermissionContract> SelectBy_PermissionIdNow(int fldPermissionId
)
		{
			var driver = new RolePermissionLogic();
			driver.SelectBy_PermissionId(fldPermissionId
);
			return driver.Results;
		}

		/// <summary>
		/// Run RolePermission_SelectBy_PermissionId, and return results as a list of RolePermissionRow.
		/// </summary>
		/// <param name="fldPermissionId">Value for PermissionId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of RolePermissionRow.</returns>
		public static List<RolePermissionContract> SelectBy_PermissionIdNow(int fldPermissionId
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new RolePermissionLogic();
			driver.SelectBy_PermissionId(fldPermissionId
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Read all RolePermission rows from the provided reader into the list structure of RolePermissionRows
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>
		/// <returns>A populated RolePermissionRows or an empty RolePermissionRows if there are no results.</returns>
		public static List<RolePermissionContract> ReadAllNow(SqlDataReader reader)
		{
			var driver = new RolePermissionLogic();

			driver.ReadAll(reader);
			
			return driver.Results;
		}
		/// <summary>");
		/// Advance one, and read values into a RolePermission
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>");
		/// <returns>A RolePermission or null if there are no results.</returns>
		public static RolePermissionContract ReadOneNow(SqlDataReader reader)
		{
			var driver = new RolePermissionLogic();			
		    return driver.ReadOne(reader) ? driver.Results[0] : null;
		}
		/// <summary>
		/// Saves the row, either by inserting (when the identity key is null) or by updating (identity key has value).
		/// </summary>
		/// <param name="row">The data to save</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveNow(RolePermissionContract row)
		{
			if(row.RolePermissionId == null)
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
		public static int SaveNow(RolePermissionContract row, SqlConnection connection, SqlTransaction transaction)
		{
			if(row.RolePermissionId == null)
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
		public static int SaveAllNow(List<RolePermissionContract> rows)
		{
			return (new RolePermissionLogic()).SaveAll(rows);
		}

		/// <summary>
		/// Save the rows in bulk, uses the same connection (faster), in a provided transaction scrope.
		/// </summary>
		/// <param name="rows">The table rows to Save</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>The number of rows affected.</returns>
		public static int SaveAllNow(List<RolePermissionContract> rows, SqlConnection connection, SqlTransaction transaction)
		{
			return (new RolePermissionLogic()).SaveAll(rows, connection, transaction);
		}        
	}
}