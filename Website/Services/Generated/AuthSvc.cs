using System.ServiceModel;
using System.ServiceModel.Activation;

namespace CALI.WebSite.Services
{
    // http://<machine_name>:<port>/Auth/help to view the service's generated help page
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.PerCall
#if DEBUG
        ,IncludeExceptionDetailInFaults = true
#endif
    )]
    public partial class AuthSvc : AuthSvcBase, IAuthSvc { }
}
