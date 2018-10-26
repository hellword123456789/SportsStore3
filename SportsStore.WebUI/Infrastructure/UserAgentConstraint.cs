using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace SportsStore.WebUI.Infrastructure
{
    public class UserAgentConstraint:IRouteConstraint
    {
        private string requiredUserAgent;
        
        public UserAgentConstraint(string agentParam)
        {
            requiredUserAgent = agentParam;
        }

        public bool Match(HttpContextBase httpContext,Route route,string parameterName,RouteValueDictionary values,RouteDirection direction)
        {
            return httpContext.Request.UserAgent != null && httpContext.Request.UserAgent.Contains(requiredUserAgent);
        }
    }
}