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
	public abstract partial class UserRoleContractBase : logic.ICacheContainerEnabled<int>
	{
		//Put your code in a separate file.  This is auto generated.

             [IgnoreDataMember] public virtual int Cache_Identity { get { return UserRoleId??0; } }
        [IgnoreDataMember] public virtual int Cache_ExpireInMiliseconds { get { return 300; } }


#region Role Extension (Parent)
		[IgnoreDataMember] public virtual Auth.RoleContract Role
		{ get { return RoleList == null || RoleList.Count == 0 ? null : RoleList[0]; } }

		[IgnoreDataMember] public virtual List<Auth.RoleContract> RoleList
		{ get { return _Role ?? (_Role = logic.Auth.RoleLogic.SelectBy_RoleIdNow(RoleId)); } }

		[IgnoreDataMember] protected List<Auth.RoleContract> _Role;
#endregion Role Extension

#region User Extension (Parent)
		[IgnoreDataMember] public virtual Auth.UserContract User
		{ get { return UserList == null || UserList.Count == 0 ? null : UserList[0]; } }

		[IgnoreDataMember] public virtual List<Auth.UserContract> UserList
		{ get { return _User ?? (_User = logic.Auth.UserLogic.SelectBy_UserIdNow(UserId)); } }

		[IgnoreDataMember] protected List<Auth.UserContract> _User;
#endregion User Extension

	}
}