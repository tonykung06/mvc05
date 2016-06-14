using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;

namespace mvc05
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //could also be configured in Web.config
            //HtmlHelper.ClientValidationEnabled = false;
            //HtmlHelper.UnobtrusiveJavaScriptEnabled = false;

            //register custom display mode for different mobile browers
            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("WP")
            {
                ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf("Windows Phone OS", StringComparison.OrdinalIgnoreCase) >= 0)
            });

            DisplayModeProvider.Instance.Modes.Insert(1, new DefaultDisplayMode("iPhone")
            {
                ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf("iPhone", StringComparison.OrdinalIgnoreCase) >= 0)
            });

            DisplayModeProvider.Instance.Modes.Insert(2, new DefaultDisplayMode("Android")
            {
                ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf("Android", StringComparison.OrdinalIgnoreCase) >= 0)
            });
        }
    }
}
