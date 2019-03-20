using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Commission.Server.Models
{
    public class AgentIdentity : IIdentity
    {
        public string Name { get; set; }

        public string AuthenticationType { get; set; }

        public bool IsAuthenticated { get; set; }

        public long AgentId { get; set; }
        public AgentIdentity(long agentId, string name)
        {
            Name = name;
            IsAuthenticated = true;
            AuthenticationType = "";
            AgentId = agentId;
        }
    }
}

