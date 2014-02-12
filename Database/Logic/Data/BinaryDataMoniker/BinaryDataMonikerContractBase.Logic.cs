using System.Collections.Generic;
using logic = CALI.Database.Logic;
using System.Runtime.Serialization;

//////////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.	//
//Override methods in the logic front class.				//
//Use of this class will require you to have your contracts //
//in the same module (Dll/exe) as the logic.                //
//////////////////////////////////////////////////////////////

namespace CALI.Database.Contracts.Data
{
	public abstract partial class BinaryDataMonikerContractBase : logic.ICacheContainerEnabled<int>
	{
		//Put your code in a separate file.  This is auto generated.

             [IgnoreDataMember] public virtual int Cache_Identity { get { return BinaryDataMonikerId??0; } }
        [IgnoreDataMember] public virtual int Cache_ExpireInMiliseconds { get { return 300; } }


#region BinaryData Extension (Parent)
		[IgnoreDataMember] public virtual Data.BinaryDataContract BinaryData
		{ get { return BinaryDataList == null || BinaryDataList.Count == 0 ? null : BinaryDataList[0]; } }

		[IgnoreDataMember] public virtual List<Data.BinaryDataContract> BinaryDataList
		{ get { return _BinaryData ?? (_BinaryData = logic.Data.BinaryDataLogic.SelectBy_BinaryDataIdNow(BinaryDataId)); } }

		[IgnoreDataMember] protected List<Data.BinaryDataContract> _BinaryData;
#endregion BinaryData Extension

#region Moniker Extension (Parent)
		[IgnoreDataMember] public virtual Data.MonikerContract Moniker
		{ get { return MonikerList == null || MonikerList.Count == 0 ? null : MonikerList[0]; } }

		[IgnoreDataMember] public virtual List<Data.MonikerContract> MonikerList
		{ get { return _Moniker ?? (_Moniker = logic.Data.MonikerLogic.SelectBy_MonikerIdNow(MonikerId)); } }

		[IgnoreDataMember] protected List<Data.MonikerContract> _Moniker;
#endregion Moniker Extension

	}
}