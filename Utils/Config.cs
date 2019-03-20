using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Utils
{
    public class Config
    {
        static IConfiguration _Ins = null;
        public static IConfiguration Ins
        {
            get
            {
                if (_Ins == null)
                {
                    var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                            .AddEnvironmentVariables();
                    _Ins = builder.Build();
                }
                return _Ins;
            }
        }

        private Config() { }
    }
}
