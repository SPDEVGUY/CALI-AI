using System;
using System.Runtime.Serialization; //NOTE:Reference Required for DataContract and DataMember

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This is the container part of the contract class.
// Fields are exposed as properties, override them by
// making a partial class of the front class (UserRoleContract).

namespace CALI.Database.Contracts.Auth
{
	[DataContract(Namespace = "UserRoleContractBase")]
	public abstract partial class UserRoleContractBase : ContractBase<UserRoleContractBase>
	{
        //Put your code in a separate file.  This is auto generated.
		//int
		[DataMember]
		public virtual int? UserRoleId { get; set; }

		//int
		[DataMember]
		public virtual int UserId { get; set; }

		//int
		[DataMember]
		public virtual int RoleId { get; set; }

	}
}