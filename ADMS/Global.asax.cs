using System.Configuration;
using System.DirectoryServices;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ADMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            App_Start.UnityWebActivator.Start();

            //var virtualPath = HttpRuntime.AppDomainAppPath;// HttpRuntime.AppDomainAppVirtualPath;

            //if (Directory.Exists(virtualPath + "Uploads\\"))
            //    Directory.CreateDirectory(virtualPath + "Uploads\\");
                     

        }
    }
}
