using Commission.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;


namespace Commission.Server
{
    public class AgentValidateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var identity = new AgentIdentity(10001, "honan");
            SetPrincipal(context, new AgentPrincipal(identity));
        }

        public static void SetPrincipal(ActionExecutingContext context, ClaimsPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (context.HttpContext.User != null)
                context.HttpContext.User = principal;
        }
    }
}

