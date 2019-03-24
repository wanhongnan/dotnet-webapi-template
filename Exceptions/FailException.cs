using Commission.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commission.Server.Exceptions
{
    public class FailException : Exception
    {
        ECode code;
        string msg;
        object data = null;

        public FailException(ECode code, string msg, object data = null)
            : base(msg)
        {
            this.code = code;
            this.msg = msg;
            this.data = data;
        }

        public ECode Code { get { return code; } }
        public string Msg { get { return msg; } }
        public object RetData => data;
    }
}

