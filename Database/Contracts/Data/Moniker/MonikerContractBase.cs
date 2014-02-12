using System;
using System.Runtime.Serialization; //NOTE:Reference Required for DataContract and DataMember

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This is the container part of the contract class.
// Fields are exposed as properties, override them by
// making a partial class of the front class (MonikerContract).

namespace CALI.Database.Contracts.Data
{
	[DataContract(Namespace = "MonikerContractBase")]
	public abstract partial class MonikerContractBase : ContractBase<MonikerContractBase>
	{
        //Put your code in a separate file.  This is auto generated.
		//int
		[DataMember]
		public virtual int? MonikerId { get; set; }

		//varchar(200)
		[DataMember]
		public virtual string Text { get; set; }

		//int
		[DataMember]
		public virtual int AliasForMoniker { get; set; }

		//datetime
		[DataMember]
		public virtual DateTime DateCreated { get; set; }

	}
}