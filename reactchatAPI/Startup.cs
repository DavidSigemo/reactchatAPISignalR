﻿using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(reactchatAPISignalR.Startup))]
namespace reactchatAPISignalR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR(new HubConfiguration { EnableJSONP = true, EnableDetailedErrors = true });
        }
    }
}