using System.Web;
using CALI.Database.Contracts.Auth;

namespace CALI.WebSite.Services
{
    //TODO: Perform the following tasks:
    //  - Create a second class called Authentication and implement the commented code below if needed
    //  - Modify the web config and add the auto generated connection string to it (from the database logic folder).

    public partial class Authentication : AuthenticationBase
    {
        /********************************************************
        ***  Copy the following code to a separate partial class
        *** and then implement the logic within it.  Do not use
         ** this file as it is automatically generated, and overwritten.
         ********************************************************
       * 
    using __LogicNameSpace.Auth;
    public partial class Authentication
    {
        public override List<PermissionEnum> AnonymousPermissions
        {
            get { return ReadPermissions; } //TODO: Determine anon access rights.
        }
        
        public override string AllowedOrigins
        {
            get { return "*"; } //TODO: Determine Allowed origins
        }
       
        public override string Authenticate(string userName, string password)
        {
            //TODO: Implement other authentication if you want?
            return base.Authenticate(userName, password);
        }         
        
        public override bool CheckAuthId(string authId)
        {
            //TODO: Implement other authentication?
            return base.CheckAuthId(authId);
        }                
         
        public override string GetAuthTokenForHash(string userName)
        {
            //TODO: Implement other authentication?
            return base.GetAuthTokenForHash(userName);
        }

        public override bool HasPermissions(string authorizationId, int permission)
        {
            //TODO: Lookup permission for the provided service, given the provided authorization id
            return AnonymousPermissions.Contains((PermissionEnum)permission); //Otherwise, return anon permissions.
        }
         
    } 
          
         
         */

        

        public static UserContract GetCurrentUser()
        {
            var cookie = HttpContext.Current.Request.Cookies["ServiceAuthToken"];
            if (cookie == null) return null;
            var authToken = cookie.Value;

            return ServiceRegister.AuthenticationProvider.GetUser(authToken);
        }
    }
}