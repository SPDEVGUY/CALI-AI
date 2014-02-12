using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CALI.Database.Contracts;
using CALI.Database.Contracts.Client;

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This file contains static implementations of the UsersLogic
// Add your own static methods by making a new partial class.
// You cannot override static methods, instead override the methods
// located in UsersLogicBase by making a partial class of UsersLogic
// and overriding the base methods.

namespace CALI.Database.Logic.Client
{
	public partial class UsersLogic
	{
		//Put your code in a separate file.  This is auto generated.
		/// <summary>
		/// Run Users_SelectByUser_Current, and return results as a list of UsersRow.
		/// </summary>
		/// <param name="fldAuthUserId">Value for AuthUserId</param>
		/// <returns>A collection of UsersRow.</returns>
		public static List<UsersContract> SelectByUser_CurrentNow(int fldAuthUserId
)
		{
			var driver = new UsersLogic();
			driver.SelectByUser_Current(fldAuthUserId
);
			return driver.Results;
		}

		/// <summary>
		/// Run Users_SelectByUser_Current, and return results as a list of UsersRow.
		/// </summary>
		/// <param name="fldAuthUserId">Value for AuthUserId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UsersRow.</returns>
		public static List<UsersContract> SelectByUser_CurrentNow(int fldAuthUserId
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new UsersLogic();
			driver.SelectByUser_Current(fldAuthUserId
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run Users_SelectByUser_UpdateProfile, and return results as a list of UsersRow.
		/// </summary>
		/// <param name="fldAuthUserId">Value for AuthUserId</param>
		/// <param name="fldDisplayName">Value for DisplayName</param>
		/// <param name="fldEmail">Value for Email</param>
		/// <returns>A collection of UsersRow.</returns>
		public static List<UsersContract> SelectByUser_UpdateProfileNow(int fldAuthUserId
, string fldDisplayName
, string fldEmail
)
		{
			var driver = new UsersLogic();
			driver.SelectByUser_UpdateProfile(fldAuthUserId
, fldDisplayName
, fldEmail
);
			return driver.Results;
		}

		/// <summary>
		/// Run Users_SelectByUser_UpdateProfile, and return results as a list of UsersRow.
		/// </summary>
		/// <param name="fldAuthUserId">Value for AuthUserId</param>
		/// <param name="fldDisplayName">Value for DisplayName</param>
		/// <param name="fldEmail">Value for Email</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UsersRow.</returns>
		public static List<UsersContract> SelectByUser_UpdateProfileNow(int fldAuthUserId
, string fldDisplayName
, string fldEmail
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new UsersLogic();
			driver.SelectByUser_UpdateProfile(fldAuthUserId
, fldDisplayName
, fldEmail
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldUserId
)
		{
			return (new UsersLogic()).Exists(fldUserId
);
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>True, if the values exist, or false.</returns>
		public static bool ExistsNow(int fldUserId
, SqlConnection connection, SqlTransaction transaction)
		{					
			return (new UsersLogic()).Exists(fldUserId
, connection, transaction);
		}

		/// <summary>
		/// Run Users_Search, and return results as a list of UsersRow.
		/// </summary>
		/// <param name="fldDisplayName">Value for DisplayName</param>
		/// <returns>A collection of UsersRow.</returns>
		public static List<UsersContract> SearchNow(string fldDisplayName
)
		{
			var driver = new UsersLogic();
			driver.Search(fldDisplayName
);
			return driver.Results;
		}

		/// <summary>
		/// Run Users_Search, and return results as a list of UsersRow.
		/// </summary>
		/// <param name="fldDisplayName">Value for DisplayName</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UsersRow.</returns>
		public static List<UsersContract> SearchNow(string fldDisplayName
, SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new UsersLogic();
			driver.Search(fldDisplayName
, connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Run Users_SelectAll, and return results as a list of UsersRow.
		/// </summary>

		/// <returns>A collection of UsersRow.</returns>
		public static List<UsersContract> SelectAllNow()
		{			
			var driver = new UsersLogic();
			driver.SelectAll();
			return driver.Results;
		}

		/// <summary>
		/// Run Users_SelectAll, and return results as a list of UsersRow.
		/// </summary>

		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UsersRow.</returns>
		public static List<UsersContract> SelectAllNow(SqlConnection connection, SqlTransaction transaction)
		{
			var driver = new UsersLogic();
			driver.SelectAll(connection, transaction);

			return driver.Results;
		}

		/// <summary>
		/// Read all Users rows from the provided reader into the list structure of UsersRows
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>
		/// <returns>A populated UsersRows or an empty UsersRows if there are no results.</returns>
		public static List<UsersContract> ReadAllNow(SqlDataReader reader)
		{
			var driver = new UsersLogic();

			driver.ReadAll(reader);
			
			return driver.Results;
		}
		/// <summary>");
		/// Advance one, and read values into a Users
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>");
		/// <returns>A Users or null if there are no results.</returns>
		public static UsersContract ReadOneNow(SqlDataReader reader)
		{
			var driver = new UsersLogic();			
		    return driver.ReadOne(reader) ? driver.Results[0] : null;
		}        
	}
}