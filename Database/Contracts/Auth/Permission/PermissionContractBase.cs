using System;
using System.Runtime.Serialization; //NOTE:Reference Required for DataContract and DataMember

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This is the container part of the contract class.
// Fields are exposed as properties, override them by
// making a partial class of the front class (PermissionContract).

namespace CALI.Database.Contracts.Auth
{
	[DataContract(Namespace = "PermissionContractBase")]
	public abstract partial class PermissionContractBase : ContractBase<PermissionContractBase>
	{
        //Put your code in a separate file.  This is auto generated.
		//int
		[DataMember]
		public virtual int? PermissionId { get; set; }

		//varchar(100)
		[DataMember]
		public virtual string PermissionName { get; set; }

		//varchar(150)
		[DataMember]
		public virtual string Title { get; set; }

		//bit
		[DataMember]
		public virtual bool IsRead { get; set; }

	}
}