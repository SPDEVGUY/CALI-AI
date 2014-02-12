using System.ServiceModel.Activation;
using System.Web.Routing;

namespace CALI.WebSite.Services
{
    //TODO: Perform the following tasks:
    //  - Modify the web config and add the auto generated connection string to it (from the database logic folder).
    //  - Modify the web config and add the code located at the bottom of this file to the <configuration> tag.

    public partial class ServiceRegister : ServiceRegisterBase
    {
        
        public readonly static Authentication AuthenticationProvider = new Authentication();

        /// <summary>
        /// This method registers the auto generated services
        /// Add a call to this in the Application_Start method in Global.asax.cs
        /// For sharepoint usage, refer to the .SVC file generated in the web project
        /// </summary>
        public static void RegisterGeneratedServiceRoutes()
        {
			RouteTable.Routes.Add(new ServiceRoute("Client/Users", new WebServiceHostFactory(), typeof(Client.UsersService)));
            RouteTable.Routes.Add(new ServiceRoute("Auth", new WebServiceHostFactory(), typeof(AuthSvc)));
        } //TODO: Edit Global.asax.cs, in the Application_Start method add this line: ServiceRegister.RegisterGeneratedServiceRoutes();
    }
}

/*

<configuration>
  <system.webServer>
    <security>
      <authentication>
        <!-- 
          If you get an error about section cannot be used at this path, see this:
          http://www.methodicmadness.com/2009/01/http-error-50019-this-configuration.html
          
          Modify %SystemRoot%/system32/inetserv/config/applicationHost.config
          Find <section name="anonymousAuthentication" overrideModeDefault="Deny" />
          Set to Allow
          
          This property is used to prevent the app account from being used for windows auth.
        -->
        <anonymousAuthentication userName="" />
      </authentication>
    </security>
    <httpProtocol>
      <customHeaders>        
        <!-- note: internet explorer doesnt like wildcards -->
        <!-- Uncomment these if you want to allow cross domain access -->
        <add name="Access-Control-Allow-Origin" value="*"/> 
		<add name="Access-Control-Allow-Headers" value="Content-Type, *"/>
		<add name="Access-Control-Allow-Methods" value="GET, POST, OPTIONS"/>
		<add name="Access-Control-Allow-Credentials" value="true"/>
      </customHeaders>
    </httpProtocol>

    <modules runAllManagedModulesForAllRequests="true">
      <add name="UrlRoutingModule" type="System.Web.Routing.UrlRoutingModule, System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
    </modules>
  </system.webServer>

  <system.serviceModel>
    <serviceHostingEnvironment aspNetCompatibilityEnabled="true" multipleSiteBindingsEnabled="true"/>
    <standardEndpoints>
      <webHttpEndpoint>
        <!-- 
            Configure the WCF REST service base address via the global.asax.cs file and the default endpoint 
            via the attributes on the <standardEndpoint> element below
        -->
        <standardEndpoint name="" helpEnabled="true" automaticFormatSelectionEnabled="true"
                          maxBufferPoolSize="2147483647" maxReceivedMessageSize="2147483647" transferMode="Streamed"
                          >
          <readerQuotas 
            maxArrayLength="2147483647"
            maxBytesPerRead="2147483647"
            maxDepth="2147483647"
            maxStringContentLength="2147483647"
            maxNameTableCharCount="2147483647"
                        />
        </standardEndpoint>
      </webHttpEndpoint>
    </standardEndpoints>
  </system.serviceModel>
 
 <!-- UNCOMMENT THIS TO USE WCF TRACING ( C:\Program Files\Microsoft SDKs\Windows\v6.0A\Bin\SvcTraceViewer.exe )
  <system.diagnostics>
    <trace autoflush="true"/>
    <sources>
      <source name="System.ServiceModel"
              switchValue="Information, ActivityTracing"
              propagateActivity="true"
              >
        <listeners>
          <add name="sdt" type="System.Diagnostics.XmlWriterTraceListener"
               initializeData="WCFTraceLog.svclog"/>
            
        </listeners>
      </source>
    </sources>
  </system.diagnostics>
 -->
 
  <system.web>
    <compilation debug="true"/>
    <httpRuntime maxRequestLength="2097150"/>
  </system.web>
 </configuration>
*/