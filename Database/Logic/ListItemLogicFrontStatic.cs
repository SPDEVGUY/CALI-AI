using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CALI.Database.Contracts;

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This is the common logic controller for list queries

namespace CALI.Database.Logic
{
	public partial class ListItemLogic
	{
		//Put your code in a separate file.  This is auto generated.
		
	#region Data Reading Methods

		/// <summary>
		/// Advance one, and read values into a ListItem.
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>
		/// <returns>A ListItemContract or null if end of results.</returns>
		public static ListItemContract ReadOneNow(SqlDataReader reader)
		{
			var driver = new ListItemLogic();
			if (driver.ReadOne(reader))
			{
				return driver.Results[0];
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Read all rows from the provided reader into a list
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>
		/// <returns>A List of ListItemContract or an empty List if there are no results.</returns>
		public static List<ListItemContract> ReadAllNow(SqlDataReader reader)
		{
			var driver = new ListItemLogic();

			driver.ReadAll(reader);

			return driver.Results;
		}

	#endregion Data Reading Methods
	}
}
