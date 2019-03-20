using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Commission.Server.Models
{
    public class AgentPrincipal : ClaimsPrincipal
    {
        AgentIdentity _AgentIdentity;    //用户标识
        List<EPermission> _PermissionList;       //权限列表

        public override IIdentity Identity => _AgentIdentity;
        public List<EPermission> PermissionList {get { return _PermissionList; }}


        public override bool IsInRole(string role)
        {
            return true;
        }

        public AgentPrincipal(AgentIdentity agentIdentity) {
            _AgentIdentity = agentIdentity;
            _PermissionList = new List<EPermission>();
        }

        /// <summary>
        /// 判断用户是否拥有某权限
        /// </summary>
        /// <param name="permissionid">权限编号</param>
        /// <returns>是否拥有某权限</returns>
        public bool IsPermission(EPermission permissionid)
        {
            if (permissionid == EPermission.Any)
                return true;
            return _PermissionList.Contains(permissionid);
        }
    }
}

