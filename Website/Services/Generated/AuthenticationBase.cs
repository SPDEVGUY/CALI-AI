using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Security.Principal;
using System.ServiceModel.Web;
using System.Web.Configuration;
using CALI.Database.Logic.Auth;
using CALI.Database.Contracts.Auth;

namespace CALI.WebSite.Services
{
    /// <summary>
    /// The set of permissions available
    /// </summary>
    public enum PermissionEnum : int
    {
None,
		Client_Users_SelectByUser_Current,
		Client_Users_SelectByUser_UpdateProfile,
		Client_Users_Exists,
		Client_Users_Search,
		Client_Users_SelectAll
    }

    /// <summary>
    /// The authentication base class provides the logic for handling permissions and authentication
    /// </summary>
    public abstract partial class AuthenticationBase
    {
        protected List<PermissionEnum> _readPermissions = new List<PermissionEnum> 
        {
			PermissionEnum.Client_Users_SelectByUser_Current,
			PermissionEnum.Client_Users_SelectByUser_UpdateProfile,
			PermissionEnum.Client_Users_Exists,
			PermissionEnum.Client_Users_Search,
			PermissionEnum.Client_Users_SelectAll
        };

        public const string AnonymousAuthId = "ANON";
        public const string WindowsAuthId = "_";
        public const string ServiceAuthTokenCookieName = "ServiceAuthToken";
        public const string CreateFail_UserNameExists = "FAIL_USERNAMEEXISTS";
        public const string CreateFail_EmailExists = "FAIL_EMAILEXISTS";
        public const string CreateFail_CantEmail = "FAIL_CANTEMAIL";
        public const string CreateFail_Exception = "FAIL_EXCEPTION";
        public const string CreateSuccess = "SUCCESS";

        /// <summary>
        /// Override this and return false to prevent auto enrollment of windows users
        /// when the Check(.) service call is made.
        /// </summary>
        public virtual bool AutoEnrollWindowsUsersOnCheck { get { return true; } }

        public virtual List<PermissionEnum> ReadPermissions { get { return _readPermissions; } }

        //The following will be implemented by the end coder...
        //Copy and paste from the generated ServiceRegister front class.
        public virtual List<PermissionEnum>  AnonymousPermissions { get { return ReadPermissions; } }

        public Dictionary<string, int> UserIdCache = new Dictionary<string, int>();
        public Dictionary<string, UserContract> UserCache = new Dictionary<string, UserContract>();
        public SpecificCacheContainer<int,List<int>> UserPermissionCache = new SpecificCacheContainer<int, List<int>>();

        
        /// <summary>
        /// This is where you provide a PIPE (|) delimited list of domains for cross script calling.
        /// </summary>
        public virtual string AllowedOrigins
        {
            get { return "*"; } 
        }
        
        /// <summary>
        /// Gets a user by the providing auth id.  AuthID can be the GUID, or "_" for windows auth.
        /// </summary>
        /// <param name="authId">The value of UserToken or "." for windows auth.</param>
        public UserContract GetUser(string authId)
        {
            if(authId == AnonymousAuthId) return null;
            var id = authId;
            if(id == WindowsAuthId) id = GetCurrentWindowsId();
            
            lock(UserCache) if(UserCache.ContainsKey(id)) return UserCache[id];

            var results = (authId) == WindowsAuthId
                ? UserLogic.SelectBy_WINSIDNow(id)
                : UserLogic.SelectBy_UserTokenNow(new Guid(authId));

            if(results.Count == 0) return null;

            var user = results[0];
            lock (UserCache) UserCache[id] = user;
            lock (UserIdCache) UserIdCache[id] = user.UserId ?? 0;

            return user;
        }
        
        /// <summary>
        /// Gets a user id by the providing auth id.  AuthID can be the GUID, or "_" for windows auth.
        /// </summary>
        /// <param name="authId">The value of UserToken or "." for windows auth.</param>
        public int GetUserId(string authId)
        {
            var id = authId;
            if(id == ".") id = GetCurrentWindowsId();
            if(UserIdCache.ContainsKey(id)) return UserIdCache[id];

            var usr = GetUser(authId);
            return usr == null ? 0 : usr.UserId ?? 0;
        }


        /// <summary>
        /// Check if the provided authentication id is valid
        /// This method is called when a service call fails, to double check authorized use.
        /// </summary>
        /// <param name="authId">The authentication id</param>
        /// <returns>True if the auth id is still valid.</returns>
        public virtual bool CheckAuthId(string authId)
        {
            if(authId == AnonymousAuthId) return false;
            var id = authId;
            if(id == WindowsAuthId) id = GetCurrentWindowsId();
            
            var results = 
                authId == WindowsAuthId
                ? UserLogic.SelectBy_WINSIDNow(id)
                : UserLogic.SelectBy_UserTokenNow(new Guid(authId));

            //Auto Enroll windows auth?
            if(AutoEnrollWindowsUsersOnCheck && results.Count == 0 && authId == WindowsAuthId) 
            {
                var user = CreateAccountForCurrentWindowsUser();
                if(user != null) results.Add(user);
            }

            //Fail check if user is not active
            if(results.Count > 0) 
            {
                if(!results[0].IsActive) return false;
            }

            return (results.Count > 0);
        }

        
        /// <summary>
        /// Authenticate the provided username and password, return a unique identifier for the user.
        /// </summary>
        /// <param name="userName">The username</param>
        /// <param name="password">The password, as MD5[GetAuthTokenForHash+PasswordHashHex]</param>
        /// <returns>A unique id for the user, or "NO Auth" for failed auth.</returns>
        public virtual string Authenticate(string userName, string password)
        {
            var success = false;
            var results = UserLogic.SelectBy_UserNameNow(userName);
            if (results.Count == 0) return "NO Auth";
                        
            var user = results[0];
            if (user.IsActive == false) return "NO Auth";

            var newUserToken = Guid.NewGuid();
            var oldToken = user.AuthToken;
            var pwBytes = oldToken + BitConverter.ToString(user.Password).Replace("-", "");
            var pwHashTokenBytes = MD5.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes(pwBytes));
            var pwHashToken = BitConverter.ToString(pwHashTokenBytes).Replace("-","");

            user.FailedLogins += 1; //Increase logon attempts. (note: this is reset to 0 on success below)
            user.AuthToken = Guid.NewGuid(); //Reset auth token.

            if (pwHashToken == password)
            {
                user.UserToken = newUserToken;
                user.FailedLogins = 0;
                success = true;
            }

            UserLogic.UpdateNow(user);

            return success ? newUserToken.ToString() : "NO Auth";
        }
        
        /// <summary>
        /// Generate an auth token that the client will combine and hash with his password before
        /// calling the Authenticate method.
        /// </summary>
        /// <param name="userName">The username</param>
        /// <returns>A generated token to be combined with the password hash client side.</returns>
        public virtual string GetAuthTokenForHash(string userName)
        {
            var newAuthToken = Guid.NewGuid();

            var results = UserLogic.SelectBy_UserNameNow(userName);
            if (results.Count == 0)
            {
                newAuthToken = Guid.Empty;
            }
            else
            {
                var user = results[0];
                user.AuthToken = newAuthToken;
                UserLogic.UpdateNow(user);
            }

            return newAuthToken.ToString();
        }

        
        /// <summary>
        /// Get the username associated with an email
        /// </summary>
        /// <param name="email">The email</param>
        /// <returns>The first username associated with an email.</returns>
        public virtual string GetUserNameForEmail(string email)
        {
            var results = UserLogic.SelectBy_EmailNow(email);
            if (results.Count == 0) return string.Empty;

            return results[0].UserName.ToString();
        }
         
        
        /// <summary>
        /// Gets the permissions for the provided auth id, against the service name.
        /// </summary>
        /// <param name="authorizationId">The unique authorization id</param>
        /// <param name="permissionId">The requested permission id</param>
        /// <returns>True if the user has the requested permission.</returns>
        public virtual bool HasPermissions(string authorizationId, int permissionId)
        {
            var userId = 0;
            if(authorizationId != AnonymousAuthId)
            {
                var user = GetUser(authorizationId);
                if (user != null) 
                {
                    userId = user.UserId ?? 0;
                    if(user.IsActive == false) userId = 0; // Inactive users have anonymous permissions.
                }
            }

            return HasPermissions(userId, permissionId);
        }
        /// <summary>
        /// Checks if the provided user id has the requested permission
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="permissionId">The requested permission id</param>
        /// <returns>True if the user has the requested permission.</returns>
        public virtual bool HasPermissions(int userId, int permissionId)
        {            
            var cached = UserPermissionCache.Get(userId);            
            if (cached != null && cached.Contains(permissionId)) return true;

            var permissionList = PermissionLogic.SelectBy_UserIdNow(userId);
            var permIdList = (from p in permissionList select p.PermissionId??0).ToList();
            
            //Cache results for 10 minutes 10*60*1000
            UserPermissionCache.Cache(userId,permIdList,600000);

            return permIdList.Contains(permissionId);
        }

        /// <summary>
        /// This method is called by the AuthSvc when it receives a request to create a user.
        /// </summary>
        /// <param name="displayName">The display name</param>
        /// <param name="userName">The user name</param>
        /// <param name="passwordHash">The hashed password bytes</param>
        public virtual string CreateNewUserRequest(string displayName, string email, string userName, byte[] passwordHash) 
        {
            var existingUser = UserLogic.SelectBy_UserNameNow(userName);
            if(existingUser.Count > 0) return CreateFail_UserNameExists;
            existingUser = UserLogic.SelectBy_EmailNow(email);
            if(existingUser.Count > 0) return CreateFail_EmailExists;

            
            var user = new UserContract
            {
                DisplayName = displayName,
                UserName = userName,
                Email = email,
                Password = passwordHash,
                AuthToken = Guid.NewGuid(),
                UserToken = Guid.NewGuid(),
                IsActive = true
            };

            var emailSent = SendActivationEmail(user);

            if(emailSent) UserLogic.InsertNow(user);

            return emailSent ? CreateSuccess: CreateFail_CantEmail;
        }

        /// <summary>
        /// Send an activation email to the user to have them activate their account
        /// </summary>
        /// <param name="user">the user to send an email to</param>
        /// <returns>true if there were no errors</returns>
        public virtual bool SendActivationEmail(UserContract user) 
        {
            //TODO: Override this method, and use the code below with your own email message / landing page
            
            //- Send activation link in email, use user.UserToken as the authId
            //- Set user.IsActive = false to prevent account use until activated

            //For now, we don't need activation
            user.IsActive = true;
            return true; //Return false if you fail to send email (error)
        }

        /// <summary>
        /// Activate a user by their provided user token.
        /// </summary>
        /// <param name="userToken">The user token</param>
        public virtual bool ActivateUserByUserToken(string userToken) 
        {
            //TODO: Potentially override this to have your system create 
            //other default data on successful user activation after activating

            var tokenGuid = new Guid(userToken);
            var userResult = UserLogic.SelectBy_UserTokenNow(tokenGuid);
            if(userResult.Count > 0) 
            {
                var user = userResult[0];
                user.IsActive = true;
                UserLogic.SaveNow(user);

                //Update cached entity
                if (UserIdCache.ContainsKey(userToken)) UserIdCache[userToken] = user.UserId??0;
                if (UserCache.ContainsKey(userToken)) UserCache[userToken] = user;
            }

            return (userResult.Count > 0);
        }

        /// <summary>
        /// Creates an account for the current windows/forms auth user
        /// </summary>
        public virtual UserContract CreateAccountForCurrentWindowsUser()
        {
            var currentUserName = GetCurrentUserName();
            var currentDisplayUserName = GetCurrentDisplayName();
            var currentWinSid = GetCurrentWindowsId();
            var currentEmail = GetCurrentEmail();

            if(string.IsNullOrEmpty(currentWinSid)) return null; // Can't enroll anonymous.
            
            var user = new UserContract
            {
                DisplayName = currentDisplayUserName,
                UserName = currentUserName,
                Email = currentEmail,
                WINSID = currentWinSid,
                IsActive = true,
                Password = new byte[16]
            };

            // ensure does not exist before saving new
            var existing = UserLogic.SelectBy_WINSIDNow(currentWinSid);
            if (existing.Count == 0) 
            {
                UserLogic.SaveNow(user);
                return user;
            } 

            return null; //User already exists, we didn't make one.
        }

        /// <summary>
        /// Returns the email address of the current windows user.
        /// </summary>
        /// <returns></returns>
        public virtual string GetCurrentEmail()
        {
            //Note: For sharepoint, override and uncomment the following
            //try
            //{
            //    if (SPContext.Current != null) return SPContext.Current.Web.CurrentUser.Email;
            //}
            //catch { }
            
            return "temp@email.com";
        }
        /// <summary>
        /// Returns the current username of the windows authenticated user
        /// </summary>
        /// <returns>The user name of the windows auth user</returns>
        public virtual string GetCurrentUserName()
        {
            //Note: For sharepoint, override and uncomment the following
            //try
            //{
            //    if (SPContext.Current != null) return SPContext.Current.Web.CurrentUser.LoginName;
            //}
            //catch { }
            var currentIdentity = WindowsIdentity.GetCurrent();

            if (currentIdentity != null)
            {
                if (currentIdentity.IsAnonymous) return string.Empty;
                if (currentIdentity.IsAuthenticated == false) return string.Empty;

                //Go by ID, unless we have a windows id, instead use SID.
                return currentIdentity.Name;
            }
            return string.Empty;
        }
        /// <summary>
        /// This method returns either the user name or the winsid depending on what is available.
        /// Anonymous is returned as an empty string.
        /// </summary>
        /// <returns>Current WINSID of windows auth user</returns>
        public virtual string GetCurrentWindowsId()
        {
            //NOTE: Override and uncomment this for sharepoint
            //try
            //{
            //    if (SPContext.Current != null) return SPContext.Current.Web.CurrentUser.Sid;
            //} catch { }

            var currentIdentity = WindowsIdentity.GetCurrent();
            if (currentIdentity != null)
            {
                if (currentIdentity.IsAnonymous) return string.Empty;
                if (currentIdentity.IsAuthenticated == false) return string.Empty;
                if (currentIdentity.IsGuest) return string.Empty;
                if (currentIdentity.IsSystem) return string.Empty;
                if (currentIdentity.Name.ToLower().Contains("apppool")) return string.Empty;

                //Go by ID, unless we have a windows id, instead use SID.
                return (currentIdentity.User != null) ? currentIdentity.User.Value : currentIdentity.Name;
            }
            return string.Empty;
        }

        /// <summary>
        /// Use this to get the current windows/forms auth context display name
        /// </summary>
        /// <returns>Current display name of windows auth user</returns>
        public virtual string GetCurrentDisplayName()
        {
            //NOTE: Override and uncomment this for sharepoint
            //try
            //{
            //    if(SPContext.Current != null) return SPContext.Current.Web.CurrentUser.Name;
            //} catch { }

            var currentIdentity = WindowsIdentity.GetCurrent();

            if (currentIdentity != null)
            {
                if (currentIdentity.IsAnonymous) return string.Empty;
                if (currentIdentity.IsAuthenticated == false) return string.Empty;

                //Go by ID, unless we have a windows id, instead use SID.
                return currentIdentity.Name;
            }
            return string.Empty;
        }

        /// <summary>
        /// This method is called when a password reset is requested
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public virtual bool RequestPasswordReset(string userName) 
        {
            var users = UserLogic.SelectBy_UserNameNow(userName);
            if(users.Count > 0)
            {
                var user = users[0];
                if(user.UserId != 1) //Protect admin account
                {
                    return SendPasswordResetEmail(user);
                }
            }
            return false;
        }

        /// <summary>
        /// Send a password reset email to the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>true if the email was sent</returns>
        public virtual bool SendPasswordResetEmail(UserContract user) 
        {
            var bodyHtmlPath =
                System.Web.HttpContext.Current.Server.MapPath("/Scripts/Views/ResetEmailTemplate.html");
            if (!File.Exists(bodyHtmlPath)) bodyHtmlPath =
                 System.Web.HttpContext.Current.Server.MapPath("/Scripts/Views/gen/ResetEmailTemplate.html");
            if (!File.Exists(bodyHtmlPath))
            {
                throw new Exception("/Scripts/Views/gen/ResetEmailTemplate.html or /Scripts/Views/ResetEmailTemplate.html not found.");
            }

            var serverRootUrl = "";
            if (WebOperationContext.Current != null)
            {
                var uri = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.RequestUri;
                serverRootUrl = uri.OriginalString.Substring(0, uri.OriginalString.Length - uri.PathAndQuery.Length);
            }

            var mailFromEmail = WebConfigurationManager.AppSettings["MailFromEmail"];
            var mailServer = WebConfigurationManager.AppSettings["MailServer"];
            var mailFromName = WebConfigurationManager.AppSettings["MailFromName"];

            if (string.IsNullOrEmpty(mailFromEmail))
            {
                throw new Exception("Cannot send reset password email.  Missing <configuration><appSettings><add key=\"MailFromEmail\" value=\"noreply@CALI.com\"/></appSettings></confiuration> in web.config");
            }
            if (string.IsNullOrEmpty(mailServer))
            {
                throw new Exception("Cannot send reset password email.  Missing <configuration><appSettings><add key=\"MailServer\" value=\"smtp.CALI.com\"/></appSettings></confiuration> in web.config");
            }
            if (string.IsNullOrEmpty(mailFromName))
            {
                throw new Exception("Cannot send reset password email.  Missing <configuration><appSettings><add key=\"MailFromName\" value=\"CALI Password Reset\"/></appSettings></confiuration> in web.config");
            }


            var bodyHtml = File.ReadAllText(bodyHtmlPath);
            bodyHtml = bodyHtml
                .Replace("{UserToken}", string.Format("{0:D}", user.UserToken))
                .Replace("{DisplayName}", user.DisplayName)
                .Replace("{ServerRootUrl}", serverRootUrl);

            var from = new MailAddress(mailFromEmail, mailFromName, System.Text.Encoding.UTF8);
            var to = new MailAddress(user.Email);
            // Specify the message content.
            using (var client = new SmtpClient(mailServer))
            {
                using (var message = new MailMessage(from, to))
                {
                    message.Subject = "CALI Password Reset";
                    message.ReplyToList.Add(new MailAddress(mailFromEmail));

                    message.Body = bodyHtml;
                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.SubjectEncoding = System.Text.Encoding.UTF8;
                    message.IsBodyHtml = true;
                    var htmlView = AlternateView.CreateAlternateViewFromString(bodyHtml, new ContentType("text/html"));
                    message.AlternateViews.Add(htmlView);

                    try
                    {
                        client.Send(message);
                    }
                    catch (Exception ex)
                    {
                        var realException = string.Format(
                            "Failed to send PW reset email.  <{0}>" + Environment.NewLine
                            + "TO: {1}" + Environment.NewLine
                            + "FROM: {2}" + Environment.NewLine
                            + "SERVER: {3}" + Environment.NewLine
                            + "Exception detail:" + Environment.NewLine + " {4}",
                            ex.Message,
                            user.Email,
                            mailFromEmail,
                            mailServer,
                            ex
                            );

                        throw new Exception(realException,ex);
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Use this method to change the user's password by their auth id to a new password
        /// </summary>
        /// <param name="authId"></param>
        /// <param name="newPasswordHash"></param>
        /// <returns></returns>
        public virtual bool ChangePassword(string authId, byte[] newPasswordHash) 
        {
            var user = GetUser(authId);
            if(user != null) 
            {
                user.Password = newPasswordHash;
                UserLogic.SaveNow(user);
            }
            return user != null;
        }
    }
}