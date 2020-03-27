using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Log4net.config", Watch = true)]
namespace RestService
{
    public static class LogHelper
    {

        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");

        public static void Info(string info)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info);
            }
        }

        public static void Error(string info, Exception e)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Error(info + ", Exception:" + e.Message.ToString());
            }
        }
    }
}
