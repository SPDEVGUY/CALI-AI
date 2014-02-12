using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Serialization;
using CALI.Database.Contracts;

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This is the common logic controller for list queries

namespace CALI.Database.Logic
{
	[Serializable]
	public partial class ListItemLogicBase : LogicBase<ListItemLogicBase>
	{	
		//Put your code in a separate file.  This is auto generated.

		[XmlArray] public List<ListItemContract> Results;

		public ListItemLogicBase()
		{
			Results = new List<ListItemContract>();
		}

	#region Data Reading Methods

		/// <summary>
		/// Read one item into Results
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>
		public bool ReadOne(SqlDataReader reader)
		{
			if (reader.Read())
			{
				Results.Add(
					new ListItemContract
					{
						ListKey = reader.GetValue(0).ToString(),
						ListLabel = reader.GetString(1),
					});
				return true;
			}
			return false;
		}

		/// <summary>
		/// Read all items into this collection
		/// </summary>
		/// <param name="reader">The result of running a sql command.</param>
		public bool ReadAll(SqlDataReader reader)
		{
			var result = ReadOne(reader);
			while (result)
			{
				result = ReadOne(reader);
			}
			return result;
		}

	#endregion Data Reading Methods
	}
}
