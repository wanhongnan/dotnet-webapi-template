using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Utils
{
    public class Log
    {
        static ILoggerRepository repository;
        public static ILog Logger(string name)
        {
            if (repository == null)
            {
                repository = LogManager.CreateRepository("LogRepository");
                XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));

                // 默认简单配置，输出至控制台
                BasicConfigurator.Configure(repository);
            }
            return LogManager.GetLogger(repository.Name, name);
        }
    }
}

