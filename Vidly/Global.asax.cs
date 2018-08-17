using System.Web;
using System.Web.Http;
using System.Web.Management;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Vidly.App_Start;

namespace Vidly
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
