namespace CALI.WebSite.Services
{
    /////////////////////////////////////////////////////////////////////////
    // This class provides some functionality for authentication providing
    // If you want to override any logic, I recommend providing your
    // custom logic in the ServiceRegister.Authenticate method instead
    // Otherwise, make a partial class of the front class and override any base logic there.

    public abstract partial class AuthSvcBase : ServiceBase
    {
        /// <summary>
        /// Attempt to authenticate, given the username and password.
        /// </summary>
        /// <param name="userName">The username</param>
        /// <param name="password">The password</param>
        /// <returns>A unique id or "NO Auth" to indicate authentication failure.</returns>
        public virtual string Auth(string userName, string password)
        {
            //SetupCrossDomainAccess();
            return ServiceRegister.AuthenticationProvider.Authenticate(userName, password);
        }

        /// <summary>
        /// Check if the provided authentication id is valid
        /// </summary>
        /// <param name="authId">The authentication id</param>
        /// <returns>True if the auth id is still valid.</returns>
        public virtual bool Check(string authId)
        {
            //SetupCrossDomainAccess();
            return ServiceRegister.AuthenticationProvider.CheckAuthId(authId);
        }

        /// <summary>
        /// Generate an auth token for the client to combine with his password hash before he calls Auth
        /// </summary>
        /// <param name="userName">The username</param>
        /// <returns>A unique id that will be hashed with the password's hash before authenticating.</returns>
        public virtual string GetToken(string userName)
        {
            //SetupCrossDomainAccess();
            return ServiceRegister.AuthenticationProvider.GetAuthTokenForHash(userName);
        }
        /// <summary>
        /// Return a username associated with an email, if there is one.
        /// </summary>
        /// <param name="email">The email</param>
        /// <returns>The first user name matching an email.</returns>
        public virtual string GetUserName(string email)
        {
            //SetupCrossDomainAccess();
            return ServiceRegister.AuthenticationProvider.GetUserNameForEmail(email);
        }

        /// <summary>
        /// A request to create a new user account has come in from the service
        /// </summary>
        /// <param name="displayName">The display name</param>
        /// <param name="userName">The user name</param>
        /// <param name="password">A password</param>
        public virtual string CreateUserRequest(string displayName, string email, string userName, string password) 
        {
            //SetupCrossDomainAccess();
            return ServiceRegister.AuthenticationProvider.CreateNewUserRequest(
                Optional(displayName), Optional(email), Optional(userName), GetBytes(Optional(password)??string.Empty));
        }

        /// <summary>
        /// A response to activation, activate user by their usertoken
        /// </summary>
        /// <param name="authId">The provided auth id</param>
        public virtual bool ActivateUser(string authId) 
        {
            //SetupCrossDomainAccess();
            return ServiceRegister.AuthenticationProvider.ActivateUserByUserToken(Optional(authId));
        }

        /// <summary>
        /// A user is requesting to have their password reset.
        /// </summary>
        /// <param name="userName">The username requesting reset</param>
        public virtual bool RequestPasswordReset(string userName) 
        {
            //SetupCrossDomainAccess();
            return ServiceRegister.AuthenticationProvider.RequestPasswordReset(Optional(userName));
        }

        /// <summary>
        /// A user is requesting to change their password.
        /// </summary>
        /// <param name="authId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public virtual bool ChangePassword(string authId, string password) 
        {
            //SetupCrossDomainAccess();
            return ServiceRegister.AuthenticationProvider.ChangePassword(
                Optional(authId),
                GetBytes(Optional(password)??string.Empty)
                );
        }
    }
}
