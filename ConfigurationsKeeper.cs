using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigApp
{
    public class ConfigurationsKeeper
    {
        public Dictionary<string, string> Data = new Dictionary<string, string>();

        public ConfigurationsKeeper()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                this.Data.Add(key, config.AppSettings.Settings[key].Value);
            }
        }
    }

}