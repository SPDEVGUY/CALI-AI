using System;
using System.Runtime.Serialization; //NOTE:Reference Required for DataContract and DataMember

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// This is the container part of the contract class.
// Fields are exposed as properties, override them by
// making a partial class of the front class (LogContract).

namespace CALI.Database.Contracts.Data
{
	[DataContract(Namespace = "LogContractBase")]
	public abstract partial class LogContractBase : ContractBase<LogContractBase>
	{
        //Put your code in a separate file.  This is auto generated.
		//int
		[DataMember]
		public virtual int? LogId { get; set; }

		//varchar(50)
		[DataMember]
		public virtual string RunOnMachineName { get; set; }

		//varchar(max)
		[DataMember]
		public virtual string LogContents { get; set; }

		//datetime
		[DataMember]
		public virtual DateTime RunTime { get; set; }

	}
}