using System;
using System.Runtime.Serialization; //NOTE:Reference Required for DataContract and DataMember

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This is the container part of the contract class.
// Fields are exposed as properties, override them by
// making a partial class of the front class (UserContract).

namespace CALI.Database.Contracts.Auth
{
	[DataContract(Namespace = "UserContractBase")]
	public abstract partial class UserContractBase : ContractBase<UserContractBase>
	{
        //Put your code in a separate file.  This is auto generated.
		//int
		[DataMember]
		public virtual int? UserId { get; set; }

		//varchar(50)
		[DataMember]
		public virtual string UserName { get; set; }

		//binary(16)
		[DataMember]
		public virtual byte[] Password { get; set; }

		//varchar(50)
		[DataMember]
		public virtual string DisplayName { get; set; }

		//varchar(100)
		[DataMember]
		public virtual string Email { get; set; }

		//uniqueidentifier
		[DataMember]
		public virtual Guid AuthToken { get; set; }

		//uniqueidentifier
		[DataMember]
		public virtual Guid UserToken { get; set; }

		//int
		[DataMember]
		public virtual int FailedLogins { get; set; }

		//bit
		[DataMember]
		public virtual bool IsActive { get; set; }

		//(Nullable) varchar(50)
		[DataMember]
		public virtual string WINSID { get; set; }

	}
}