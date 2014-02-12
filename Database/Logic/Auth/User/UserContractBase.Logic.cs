using System.Collections.Generic;
using logic = CALI.Database.Logic;
using System.Runtime.Serialization;

//////////////////////////////////////////////////////////////
//Do not modify this file. Use a partial class to extend.	//
//Override methods in the logic front class.				//
//Use of this class will require you to have your contracts //
//in the same module (Dll/exe) as the logic.                //
//////////////////////////////////////////////////////////////

namespace CALI.Database.Contracts.Auth
{
	public abstract partial class UserContractBase : logic.ICacheContainerEnabled<int>
	{
		//Put your code in a separate file.  This is auto generated.

             [IgnoreDataMember] public virtual int Cache_Identity { get { return UserId??0; } }
        [IgnoreDataMember] public virtual int Cache_ExpireInMiliseconds { get { return 300; } }


#region UserRole Extension (Child)
		[IgnoreDataMember] public virtual Auth.UserRoleContract UserRole
		{ get { return UserRoleList == null || UserRoleList.Count == 0 ? null : UserRoleList[0]; } }

		[IgnoreDataMember] public virtual List<Auth.UserRoleContract> UserRoleList
		{ get { return _UserRole ?? (_UserRole = logic.Auth.UserRoleLogic.SelectBy_UserIdNow((int)UserId)); } }

		[IgnoreDataMember] protected List<Auth.UserRoleContract> _UserRole;
#endregion UserRole Extension

	}
}