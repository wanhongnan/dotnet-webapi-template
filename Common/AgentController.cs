using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using Utils;
using Microsoft.Extensions.Configuration;
using Commission.Server.Models;

namespace Commission.Server
{
    public abstract class AgentController : Controller
    {

        public static string PlatformConnectionString
        {
            get
            {
                var ret = Config.Ins.GetConnectionString("PlatformConnection");
                return ret;
            }
        }

        public static IDatabase Redis {
            get {
                return RedisHelper.Db();
            }
        }

        public AgentPrincipal Principal
        {
            get
            {
                return HttpContext.User as AgentPrincipal;
            }
        }

        public AgentIdentity Identity
        {
            get
            {
                return Principal.Identity as AgentIdentity;
            }
        }

        public long AgentId {
            get {
                return Identity.AgentId;
            }
        }
    }
}

