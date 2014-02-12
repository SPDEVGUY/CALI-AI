using System;
using System.Runtime.Serialization; //NOTE:Reference Required for DataContract and DataMember

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This is the container part of the contract class.
// Fields are exposed as properties, override them by
// making a partial class of the front class (RoleContract).

namespace CALI.Database.Contracts.Auth
{
	[DataContract(Namespace = "RoleContractBase")]
	public abstract partial class RoleContractBase : ContractBase<RoleContractBase>
	{
        //Put your code in a separate file.  This is auto generated.
		//int
		[DataMember]
		public virtual int? RoleId { get; set; }

		//varchar(50)
		[DataMember]
		public virtual string Title { get; set; }

		//varchar(max)
		[DataMember]
		public virtual string Description { get; set; }

		//bit
		[DataMember]
		public virtual bool IsActive { get; set; }

		//bit
		[DataMember]
		public virtual bool ApplyToAnon { get; set; }

		//bit
		[DataMember]
		public virtual bool ApplyToAllUsers { get; set; }

		//bit
		[DataMember]
		public virtual bool PreventAddingUsers { get; set; }

		//(Nullable) varchar(50)
		[DataMember]
		public virtual string WINSID { get; set; }

	}
}