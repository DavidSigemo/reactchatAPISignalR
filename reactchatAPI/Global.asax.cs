using ReactChat.Models;
using reactchatAPI.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace reactchatAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteTable.Routes.MapHttpRoute(
                        name: "DefaultApi",
                        routeTemplate: "api/{controller}/{id}",
                        defaults: new { id = System.Web.Http.RouteParameter.Optional }
                        );
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["ChatStore"] = new ChatStore();
            MessageManager chatManager = new MessageManager(Session["ChatStore"] as ChatStore);
            GlobalConfiguration.Configuration.DependencyResolver = new WebApiDependencyResolver(chatManager);
        }
    }
}
