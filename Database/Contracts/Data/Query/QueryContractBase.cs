using System;
using System.Runtime.Serialization; //NOTE:Reference Required for DataContract and DataMember

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This is the container part of the contract class.
// Fields are exposed as properties, override them by
// making a partial class of the front class (QueryContract).

namespace CALI.Database.Contracts.Data
{
	[DataContract(Namespace = "QueryContractBase")]
	public abstract partial class QueryContractBase : ContractBase<QueryContractBase>
	{
        //Put your code in a separate file.  This is auto generated.
		//int
		[DataMember]
		public virtual int? QueryId { get; set; }

		//varchar(max)
		[DataMember]
		public virtual string Text { get; set; }

		//(Nullable) varchar(max)
		[DataMember]
		public virtual string PoviderSource { get; set; }

		//(Nullable) varchar(max)
		[DataMember]
		public virtual string ProcessorUsed { get; set; }

		//(Nullable) varchar(max)
		[DataMember]
		public virtual string Exceptions { get; set; }

		//bit
		[DataMember]
		public virtual bool IsSuccess { get; set; }

	}
}