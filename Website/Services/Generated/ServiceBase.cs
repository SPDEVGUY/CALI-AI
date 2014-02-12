using System;
using System.Net;
using System.Web;
using System.ServiceModel.Web;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CALI.WebSite.Services
{
    /// <summary>
    /// The service base class is inherited by all generated services, to provide common logic.
    /// </summary>
    public abstract partial class ServiceBase
    {
        /// <summary>
        /// This method is used to check if the provided auth token has the right permissions
        /// </summary>
        /// <param name="authId">The unique auth token provided from the Auth service</param>
        /// <param name="permissionId">The permission needed.</param>
        /// <returns>True if user has permission</returns>
        protected virtual bool Can(string authId, int permissionId)
        {
            //SetupCrossDomainAccess();
            HttpContext.Current.Response.CacheControl = "no-cache";

            var canDo = ServiceRegister.AuthenticationProvider.HasPermissions(authId, permissionId);
            if (!canDo)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = "Not authorized to use this method.";
            }
            return canDo;
        }
        //protected virtual void SetupCrossDomainAccess() 
        //{
        //    WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", ServiceRegister.AuthenticationProvider.AllowedOrigins);            
        //    WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Headers", "*");
        //    WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Credentials", "true");
        //    WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
        //}

        /// <summary>
        /// This method is used to make string parameters optional by replacing known values
        /// </summary>
        /// <param name="param">-NILL = empty, -NULL = null</param>
        /// <returns></returns>
        protected  virtual string Optional(string param)
        {
            return param == "-NILL" ? string.Empty : param == "-NULL" ? null : param;
        }

        /// <summary>
        /// Method takes in a series of hex bytes, and converts byte array
        /// </summary>
        /// <param name="hexString">the hex value</param>
        /// <returns>Byte array from string</returns>
        protected byte[] GetBytes(string hexString)
        {
            var length = (hexString.Length + 1) / 2;
            var result = new byte[length];
            for (var i = 0; i < length; i++)
                result[i] = Convert.ToByte(hexString.Substring(2 * i, 2), 16);
            return result;
        }
    }
    
    [DataContract]
    public class NameValuePair
    {
        [DataMember] public string name { get; set; }
        [DataMember] public string value { get; set; }
    }

    [CollectionDataContract(Namespace = "")]
    public class NameValuePairs : List<NameValuePair> { public string i(int index) { return this[index].value; } };

    /* For POST later...
     * 
     * This code works with contract above
     
     
        [WebInvoke(UriTemplate = "{authId}/SearchPost()")]
        List<ActiveRolesContract> SearchPost(string authId, NameValuePairs body);
      
     $.ajax({
        type: "POST",
        url: "http://localhost:13375/QT/ActiveRoles/SearchPost()",
        data: JSON.stringify([ {'name':'title','value':'test'} , { 'name':'description', 'value':'desc' } ]),
        contentType: "application/json;cjarset=Utf-8",  
        dataType:"json",
        success: function(x) { alert(x); }
    });
     * 
     * http://ednortonengineeringsociety.blogspot.com/2010/10/passing-json-array-to-wcf-service.html
     */

}
