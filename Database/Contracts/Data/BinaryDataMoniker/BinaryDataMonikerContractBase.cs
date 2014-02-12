using System;
using System.Runtime.Serialization; //NOTE:Reference Required for DataContract and DataMember

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This is the container part of the contract class.
// Fields are exposed as properties, override them by
// making a partial class of the front class (BinaryDataMonikerContract).

namespace CALI.Database.Contracts.Data
{
	[DataContract(Namespace = "BinaryDataMonikerContractBase")]
	public abstract partial class BinaryDataMonikerContractBase : ContractBase<BinaryDataMonikerContractBase>
	{
        //Put your code in a separate file.  This is auto generated.
		//int
		[DataMember]
		public virtual int? BinaryDataMonikerId { get; set; }

		//int
		[DataMember]
		public virtual int BinaryDataId { get; set; }

		//int
		[DataMember]
		public virtual int MonikerId { get; set; }

	}
}