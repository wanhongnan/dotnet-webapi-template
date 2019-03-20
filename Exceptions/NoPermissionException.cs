using Commission.Server.Models;
using System;

namespace Commission.Server.Exceptions
{
    public class NoPermissionException : Exception
    {
        EPermission[] _permissions;

        public NoPermissionException(EPermission[] permissions, string msg) 
            : base(msg)
        {
            _permissions = permissions;
        }

        public EPermission[] Permissions { get => _permissions; private set => _permissions = value; }
    }
}