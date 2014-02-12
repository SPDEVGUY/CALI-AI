using System;
using System.Runtime.Serialization; //NOTE:Reference Required for DataContract and DataMember

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This is the container part of the contract class.
// Fields are exposed as properties, override them by
// making a partial class of the front class (RolePermissionContract).

namespace CALI.Database.Contracts.Auth
{
	[DataContract(Namespace = "RolePermissionContractBase")]
	public abstract partial class RolePermissionContractBase : ContractBase<RolePermissionContractBase>
	{
        //Put your code in a separate file.  This is auto generated.
		//int
		[DataMember]
		public virtual int? RolePermissionId { get; set; }

		//int
		[DataMember]
		public virtual int RoleId { get; set; }

		//int
		[DataMember]
		public virtual int PermissionId { get; set; }

	}
}