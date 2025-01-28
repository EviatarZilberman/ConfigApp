using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigApp
{
    public static class ConfigurationsKeeper
    {
        private static Dictionary<string, string> Data = new Dictionary<string, string>();
        private static Configuration? Config { get; set; } = null;
        //public ConfigurationsKeeper()
        //{
        //    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        //    foreach (string key in config.AppSettings.Settings.AllKeys)
        //    {
        //        this.Data.Add(key, config.AppSettings.Settings[key].Value);
        //    }
        //}
        public static void Init()
        {
            if (Config == null)
            {
                Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                foreach (string key in Config.AppSettings.Settings.AllKeys)
                {
                    Data.Add(key, Config.AppSettings.Settings[key].Value);
                }
            }
        }

        public static string GetValue(string key)
        {
            try
            {
                if (Config != null)
                {
                    return Config.AppSettings.Settings[key].Value;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch 
            {
                return string.Empty;
            }
        }
    }


    }