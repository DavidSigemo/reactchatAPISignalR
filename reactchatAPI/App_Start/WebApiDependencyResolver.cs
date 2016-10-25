using reactchatAPI.ApiControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace reactchatAPI.App_Start
{
    public class WebApiDependencyResolver : IDependencyResolver
    {
        private MessageManager _manager;

        public WebApiDependencyResolver(MessageManager chatManager)
        {
            _manager = chatManager;
        }


        public Object GetService(Type serviceType)
        {
            return serviceType == typeof(MessageController) ? new MessageController(_manager) : null;
        }

        public IEnumerable<Object> GetServices(Type serviceType)
        {
            return new List<Object>();
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {

        }
    }
}