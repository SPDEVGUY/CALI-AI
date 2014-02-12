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
	public abstract partial class RolePermissionContractBase : logic.ICacheContainerEnabled<int>
	{
		//Put your code in a separate file.  This is auto generated.

             [IgnoreDataMember] public virtual int Cache_Identity { get { return RolePermissionId??0; } }
        [IgnoreDataMember] public virtual int Cache_ExpireInMiliseconds { get { return 300; } }


#region Permission Extension (Parent)
		[IgnoreDataMember] public virtual Auth.PermissionContract Permission
		{ get { return PermissionList == null || PermissionList.Count == 0 ? null : PermissionList[0]; } }

		[IgnoreDataMember] public virtual List<Auth.PermissionContract> PermissionList
		{ get { return _Permission ?? (_Permission = logic.Auth.PermissionLogic.SelectBy_PermissionIdNow(PermissionId)); } }

		[IgnoreDataMember] protected List<Auth.PermissionContract> _Permission;
#endregion Permission Extension

#region Role Extension (Parent)
		[IgnoreDataMember] public virtual Auth.RoleContract Role
		{ get { return RoleList == null || RoleList.Count == 0 ? null : RoleList[0]; } }

		[IgnoreDataMember] public virtual List<Auth.RoleContract> RoleList
		{ get { return _Role ?? (_Role = logic.Auth.RoleLogic.SelectBy_RoleIdNow(RoleId)); } }

		[IgnoreDataMember] protected List<Auth.RoleContract> _Role;
#endregion Role Extension

	}
}