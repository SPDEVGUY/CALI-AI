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
	public abstract partial class MonikerContractBase : logic.ICacheContainerEnabled<int>
	{
		//Put your code in a separate file.  This is auto generated.

             [IgnoreDataMember] public virtual int Cache_Identity { get { return MonikerId??0; } }
        [IgnoreDataMember] public virtual int Cache_ExpireInMiliseconds { get { return 300; } }


#region BinaryDataMoniker Extension (Child)
		[IgnoreDataMember] public virtual Data.BinaryDataMonikerContract BinaryDataMoniker
		{ get { return BinaryDataMonikerList == null || BinaryDataMonikerList.Count == 0 ? null : BinaryDataMonikerList[0]; } }

		[IgnoreDataMember] public virtual List<Data.BinaryDataMonikerContract> BinaryDataMonikerList
		{ get { return _BinaryDataMoniker ?? (_BinaryDataMoniker = logic.Data.BinaryDataMonikerLogic.SelectBy_MonikerIdNow((int)MonikerId)); } }

		[IgnoreDataMember] protected List<Data.BinaryDataMonikerContract> _BinaryDataMoniker;
#endregion BinaryDataMoniker Extension

	}
}