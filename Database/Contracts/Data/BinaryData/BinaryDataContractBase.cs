using System;
using System.Runtime.Serialization; //NOTE:Reference Required for DataContract and DataMember

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This is the container part of the contract class.
// Fields are exposed as properties, override them by
// making a partial class of the front class (BinaryDataContract).

namespace CALI.Database.Contracts.Data
{
	[DataContract(Namespace = "BinaryDataContractBase")]
	public abstract partial class BinaryDataContractBase : ContractBase<BinaryDataContractBase>
	{
        //Put your code in a separate file.  This is auto generated.
		//int
		[DataMember]
		public virtual int? BinaryDataId { get; set; }

		//varchar(50)
		[DataMember]
		public virtual string DataType { get; set; }

		//(Nullable) varchar(64)
		[DataMember]
		public virtual string Hash { get; set; }

		//varbinary(max)
		[DataMember]
		public virtual byte[] Data { get; set; }

		//datetime
		[DataMember]
		public virtual DateTime DateCreated { get; set; }

	}
}