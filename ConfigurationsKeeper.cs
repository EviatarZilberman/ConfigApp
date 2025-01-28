//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConfigApp
//{
//    public static class ConfigurationsKeeper
//    {
//        private static Dictionary<string, string> Data = new Dictionary<string, string>();
//        private static Configuration? Config { get; set; } = null;
//        //public ConfigurationsKeeper()
//        //{
//        //    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

//        //    foreach (string key in config.AppSettings.Settings.AllKeys)
//        //    {
//        //        this.Data.Add(key, config.AppSettings.Settings[key].Value);
//        //    }
//        //}
//        public static void Init()
//        {
//            if (Config == null)
//            {
//                lock (Data)
//                {
//                    Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

//                    foreach (string key in Config.AppSettings.Settings.AllKeys)
//                    {
//                        Data.Add(key, Config.AppSettings.Settings[key].Value);
//                    }
//                }
//            }
//        }

//        public static string GetValue(string key)
//        {
//            try
//            {
//                if (Config != null)
//                {
//                    lock (Data)
//                    {
//                        return Config.AppSettings.Settings[key].Value;
//                    }
//                }
//                else
//                {
//                    return string.Empty;
//                }
//            }
//            catch
//            {
//                return string.Empty;
//            }
//        }
//    }


//}

using System;
using System.Collections.Generic;
using System.Configuration;

namespace ConfigApp
{
    public sealed class ConfigurationsKeeper
    {
        // Singleton instance created lazily
        private static readonly Lazy<ConfigurationsKeeper> _instance =
            new Lazy<ConfigurationsKeeper>(() => new ConfigurationsKeeper());

        // Thread-safe dictionary to store configuration
        private readonly Dictionary<string, string> _data = new Dictionary<string, string>();
        private readonly Configuration _config;

        // Private constructor to prevent instantiation
        private ConfigurationsKeeper()
        {
            _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Populate the dictionary with configuration values
            foreach (string key in _config.AppSettings.Settings.AllKeys)
            {
                _data[key] = _config.AppSettings.Settings[key].Value;
            }
        }

        // Public static property to access the singleton instance
        public static ConfigurationsKeeper Instance => _instance.Value;

        // Method to get a configuration value
        public string GetValue(string key)
        {
            if (_data.TryGetValue(key, out var value))
            {
                return value;
            }
            return string.Empty;
        }
    }
}
