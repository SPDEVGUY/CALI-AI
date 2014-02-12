using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using CALI.Database.Contracts;
using CALI.Database.Contracts.Client;


namespace CALI.WebSite.Services.Client
{
    // http://<machine_name>:<port>/Users/help to view the service's generated help page
    [ServiceContract]
    public partial interface UsersServiceInterface
    {        
        [OperationContract] [WebInvoke(Method = "POST", UriTemplate = "{authId}/SelectByUser_Current()")]
        List<UsersContract> SelectByUser_Current(string authId);


        [OperationContract] [WebInvoke(Method = "POST", UriTemplate = "{authId}/SelectByUser_UpdateProfile()")]
        List<UsersContract> SelectByUser_UpdateProfile(string authId, UsersServiceBase.SelectByUser_UpdateProfilePx px);


        [OperationContract] [WebGet(UriTemplate = "{authId}/Exists({fldUserId})")]
        bool Exists(string authId, string fldUserId);


        [OperationContract] [WebInvoke(Method = "POST", UriTemplate = "{authId}/Search()")]
        List<UsersContract> Search(string authId, UsersServiceBase.SearchPx px);


        [OperationContract] [WebGet(UriTemplate = "{authId}/")]
        List<UsersContract> SelectAll(string authId);

    }
}
