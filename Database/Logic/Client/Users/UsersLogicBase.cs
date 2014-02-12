using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Serialization;
using CALI.Database.Contracts;
using CALI.Database.Contracts.Client;

//////////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.	//
//Override methods in the logic front class.				//
//////////////////////////////////////////////////////////////

namespace CALI.Database.Logic.Client
{
	[Serializable]
	public abstract partial class UsersLogicBase : LogicBase<UsersLogicBase>
	{
		//Put your code in a separate file.  This is auto generated.
    
		[XmlArray] public List<UsersContract> Results;

		public UsersLogicBase()
		{
			Results =  new List<UsersContract>();
		}

		/// <summary>
		/// Run Users_SelectByUser_Current, and return results as a list of UsersRow.
		/// </summary>
		/// <param name="fldAuthUserId">Value for AuthUserId</param>
		/// <returns>A collection of UsersRow.</returns>
		public virtual bool SelectByUser_Current(int fldAuthUserId
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Client].[Users_SelectByUser_Current]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@AuthUserId", fldAuthUserId)

					});

					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
		}

		/// <summary>
		/// Run Users_SelectByUser_Current, and return results as a list of UsersRow.
		/// </summary>
		/// <param name="fldAuthUserId">Value for AuthUserId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UsersRow.</returns>
		public virtual bool SelectByUser_Current(int fldAuthUserId
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Client].[Users_SelectByUser_Current]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@AuthUserId", fldAuthUserId)

					});

				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run Users_SelectByUser_UpdateProfile, and return results as a list of UsersRow.
		/// </summary>
		/// <param name="fldAuthUserId">Value for AuthUserId</param>
		/// <param name="fldDisplayName">Value for DisplayName</param>
		/// <param name="fldEmail">Value for Email</param>
		/// <returns>A collection of UsersRow.</returns>
		public virtual bool SelectByUser_UpdateProfile(int fldAuthUserId
, string fldDisplayName
, string fldEmail
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Client].[Users_SelectByUser_UpdateProfile]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@AuthUserId", fldAuthUserId)
,
						new SqlParameter("@DisplayName", fldDisplayName)
,
						new SqlParameter("@Email", fldEmail)

					});

					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
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
		public virtual bool SelectByUser_UpdateProfile(int fldAuthUserId
, string fldDisplayName
, string fldEmail
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Client].[Users_SelectByUser_UpdateProfile]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@AuthUserId", fldAuthUserId)
,
						new SqlParameter("@DisplayName", fldDisplayName)
,
						new SqlParameter("@Email", fldEmail)

					});

				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <returns>True, if the values exist, or false.</returns>
		public virtual bool Exists(int fldUserId
)
		{
			bool result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Client].[Users_Exists]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserId", fldUserId)

					});

					result = (bool)cmd.ExecuteScalar();
				}
			});

			return result;
		}

		/// <summary>
		/// Determine if the table contains a row with the existing values
		/// </summary>
		/// <param name="fldUserId">Value for UserId</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>True, if the values exist, or false.</returns>
		public virtual bool Exists(int fldUserId
, SqlConnection connection, SqlTransaction transaction)
		{					
			using (
				var cmd = new SqlCommand("[Client].[Users_Exists]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@UserId", fldUserId)

					});

					return (bool)cmd.ExecuteScalar();
			}
		}

		/// <summary>
		/// Run Users_Search, and return results as a list of UsersRow.
		/// </summary>
		/// <param name="fldDisplayName">Value for DisplayName</param>
		/// <returns>A collection of UsersRow.</returns>
		public virtual bool Search(string fldDisplayName
)
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Client].[Users_Search]", x)
					{
						CommandType = CommandType.StoredProcedure,
						CommandTimeout = DefaultCommandTimeout
					})
				{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@DisplayName", fldDisplayName)

					});

					using(var r = cmd.ExecuteReader()) result = ReadAll(r);
				}
			});

			return result;
		}

		/// <summary>
		/// Run Users_Search, and return results as a list of UsersRow.
		/// </summary>
		/// <param name="fldDisplayName">Value for DisplayName</param>
		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UsersRow.</returns>
		public virtual bool Search(string fldDisplayName
, SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Client].[Users_Search]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
					cmd.Parameters.AddRange(new[] {
						new SqlParameter("@DisplayName", fldDisplayName)

					});

				using(var r = cmd.ExecuteReader()) return ReadAll(r);
			}
		}

		/// <summary>
		/// Run Users_SelectAll, and return results as a list of UsersRow.
		/// </summary>

		/// <returns>A collection of UsersRow.</returns>
		public virtual bool SelectAll()
		{
			var result = false;

			CALIDb.ConnectThen(x =>
			{
				using (
					var cmd = new SqlCommand("[Client].[Users_SelectAll]", x)
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
		/// Run Users_SelectAll, and return results as a list of UsersRow.
		/// </summary>

		/// <param name="connection">The SqlConnection to use</param>
		/// <param name="transaction">The SqlTransaction to use</param>
		/// <returns>A collection of UsersRow.</returns>
		public virtual bool SelectAll(SqlConnection connection, SqlTransaction transaction)
		{
			using (
				var cmd = new SqlCommand("[Client].[Users_SelectAll]", connection)
				{CommandType = CommandType.StoredProcedure,Transaction = transaction})
			{
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
					new UsersContract
					{
					UserId = reader.GetInt32(0),
					DisplayName = reader.GetString(1),

					});
				return true;
			}
			return false;
		}
	}
}