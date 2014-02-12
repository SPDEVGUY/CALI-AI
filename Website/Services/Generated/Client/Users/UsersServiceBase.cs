using System;
using System.Collections.Generic;
using System.Diagnostics;
using CALI.Database.Contracts;
using System.Runtime.Serialization;
using CALI.Database.Contracts.Client;
using CALI.Database.Logic.Client;


namespace CALI.WebSite.Services.Client
{    
    ///////////////////////////////////////////////////////////
    //Do not modify this file. Use a partial class to extend.//
    ///////////////////////////////////////////////////////////

    public abstract partial class UsersServiceBase : ServiceBase
    {
		
		public virtual List<UsersContract> SelectByUser_Current(string authId)
		{
			try {
				return
					Can(authId, (int)PermissionEnum.Client_Users_SelectByUser_Current)
					? UsersLogic.SelectByUser_CurrentNow(ServiceRegister.AuthenticationProvider.GetUserId(authId))
					: null;//cant
			} catch(Exception ex) {
			#if DEBUG
				Debug.WriteLine("------------------------------");
                Debug.WriteLine("------ UsersServiceBase.SelectByUser_Current ERROR ------");
                Debug.WriteLine("------------------------------");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.ToString());
                Debug.WriteLine("------------------------------");
			#endif
				throw;
			}
		}
		
		[DataContract(Name = "SelectByUser_UpdateProfilePx", Namespace = "SelectByUser_UpdateProfilePx")]
		public class SelectByUser_UpdateProfilePx
		{
			[DataMember] public string DisplayName;
			[DataMember] public string Email;
		}
		public virtual List<UsersContract> SelectByUser_UpdateProfile(string authId, SelectByUser_UpdateProfilePx px)
		{
			try {
				return
					Can(authId, (int)PermissionEnum.Client_Users_SelectByUser_UpdateProfile)
					? UsersLogic.SelectByUser_UpdateProfileNow(ServiceRegister.AuthenticationProvider.GetUserId(authId), px.DisplayName, px.Email)
					: null;//cant
			} catch(Exception ex) {
			#if DEBUG
				Debug.WriteLine("------------------------------");
                Debug.WriteLine("------ UsersServiceBase.SelectByUser_UpdateProfile ERROR ------");
                Debug.WriteLine("------------------------------");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.ToString());
                Debug.WriteLine("------------------------------");
			#endif
				throw;
			}
		}
        public virtual bool Exists(string authId, string fldUserId)
        {
			try {
				return 
					Can(authId, (int)PermissionEnum.Client_Users_Exists)
					? UsersLogic.ExistsNow((int)Convert.ChangeType(fldUserId,typeof(int)))
					: false; //cant
			} catch(Exception ex) {
			#if DEBUG
				Debug.WriteLine("------------------------------");
                Debug.WriteLine("------ UsersServiceBase.Exists ERROR ------");
                Debug.WriteLine("------------------------------");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.ToString());
                Debug.WriteLine("------------------------------");
			#endif
				throw;
			}
        }
		
		[DataContract(Name = "SearchPx", Namespace = "SearchPx")]
		public class SearchPx
		{
			[DataMember] public string DisplayName;
		}
		public virtual List<UsersContract> Search(string authId, SearchPx px)
		{
			try {
				return
					Can(authId, (int)PermissionEnum.Client_Users_Search)
					? UsersLogic.SearchNow(px.DisplayName)
					: null;//cant
			} catch(Exception ex) {
			#if DEBUG
				Debug.WriteLine("------------------------------");
                Debug.WriteLine("------ UsersServiceBase.Search ERROR ------");
                Debug.WriteLine("------------------------------");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.ToString());
                Debug.WriteLine("------------------------------");
			#endif
				throw;
			}
		}
		
		public virtual List<UsersContract> SelectAll(string authId)
		{
			try {
				return
					Can(authId, (int)PermissionEnum.Client_Users_SelectAll)
					? UsersLogic.SelectAllNow()
					: null;//cant
			} catch(Exception ex) {
			#if DEBUG
				Debug.WriteLine("------------------------------");
                Debug.WriteLine("------ UsersServiceBase.SelectAll ERROR ------");
                Debug.WriteLine("------------------------------");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.ToString());
                Debug.WriteLine("------------------------------");
			#endif
				throw;
			}
		}
    }
}
