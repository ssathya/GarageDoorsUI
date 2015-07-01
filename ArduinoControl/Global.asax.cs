using ArduinoControl.Rules;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ArduinoControl
{
    public class MvcApplication : System.Web.HttpApplication
    {
        #region Protected Methods

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Start();
        }

        #endregion Protected Methods
    }
}