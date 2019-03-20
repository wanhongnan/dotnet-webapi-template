using Commission.Server.Exceptions;
using Commission.Server.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Commission.Server
{
    public class PermissionAttribute : ActionFilterAttribute
    {
        public PermissionAttribute(params EPermission[] permissions)
        {
            Permissions = permissions;
        }
        public EPermission[] Permissions { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var agentPrincipal = context.HttpContext.User as AgentPrincipal;
            var agentIdentity = agentPrincipal.Identity as AgentIdentity;

            var allow = Permissions.Any(f => agentPrincipal.IsPermission(f));
            if (!allow) throw new NoPermissionException(Permissions, "没有权限");

            base.OnActionExecuting(context);
        }
    }
}


