using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Commission.Server.Exceptions
{
    public class ParameterException : Exception
    {
        public ParameterException(string msg)
            : base(msg)
        {
        }
    }
}

