using System;
using System.Runtime.Serialization; //NOTE:Reference Required for DataContract and DataMember

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This is the container part of the contract class.
// Fields are exposed as properties, override them by
// making a partial class of the front class (UsersContract).

namespace CALI.Database.Contracts.Client
{
	[DataContract(Namespace = "UsersContractBase")]
	public abstract partial class UsersContractBase : ContractBase<UsersContractBase>
	{
        //Put your code in a separate file.  This is auto generated.
		//int
		[DataMember]
		public virtual int? UserId { get; set; }

		//varchar(50)
		[DataMember]
		public virtual string DisplayName { get; set; }

	}
}