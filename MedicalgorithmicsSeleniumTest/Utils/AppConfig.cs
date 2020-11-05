using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalgorithmicsSeleniumTest.Utils
{
    public static class AppConfig
    {
        public static string Url
        {
            get
            {
                return ConfigurationManager.AppSettings["Url"];
            }
        }

        public static string DownloadPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["DownloadPath"];
            }
        }

        public static int Timeout
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["Timeout"]); 
            }
        }
    }
}
