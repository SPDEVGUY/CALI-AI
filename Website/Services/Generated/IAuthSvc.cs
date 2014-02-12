using System.ServiceModel;
using System.ServiceModel.Web;

namespace CALI.WebSite.Services
{
    // The Authentication service is used to provide soe plumbing for authentication on rest services.
    // http://<machine_name>:<port>/Auth/help
    [ServiceContract]
    public partial interface IAuthSvc
    {
        [WebGet(UriTemplate = "{userName}/{password}")]
        string Auth(string userName, string password);
        
        [WebGet(UriTemplate = "Check({authId})")]
        bool Check(string authId);

        [WebGet(UriTemplate = "{userName}")]
        string GetToken(string userName);

        [WebGet(UriTemplate = "User({email})")]
        string GetUserName(string email);
        
        [WebGet(UriTemplate = "Create({displayName},{email},{userName},{password})")]
        string CreateUserRequest(string displayName, string email, string userName, string password);
                
        [WebGet(UriTemplate = "Activate({authId})")]
        bool ActivateUser(string authId);
                
        [WebGet(UriTemplate = "Reset({userName})")]
        bool RequestPasswordReset(string userName);
                
        [WebGet(UriTemplate = "Change({authId},{password})")]
        bool ChangePassword(string authId, string password);
    }
}
