using System;
using System.Runtime.Serialization; //Reference Required for DataContract and DataMember

///////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.//
///////////////////////////////////////////////////////////
// List queries return a known structure of key and label.

namespace CALI.Database.Contracts
{
	[DataContract(Namespace = "ListItemContractBase")]
	public partial class ListItemContractBase : ContractBase<ListItemContract>
	{
        //Put your code in a separate file.  This is auto generated.
		[DataMember]     public virtual string ListKey { get; set; }
		[DataMember]     public virtual string ListLabel { get; set; }
	}
}
