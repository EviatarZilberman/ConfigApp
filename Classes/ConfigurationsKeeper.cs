using ConfigApp.Interfaces;
using System.Configuration;

namespace ConfigApp.Classes
{
    public sealed class ConfigurationsKeeper : IConfig
    {
        // Singleton instance created lazily
        private static readonly Lazy<ConfigurationsKeeper> SingletonInstance =
            new Lazy<ConfigurationsKeeper>(() => new ConfigurationsKeeper());

        // Thread-safe dictionary to store configuration
        private readonly Dictionary<string, string> Data = new Dictionary<string, string>();
        private readonly Configuration Config;

        // Private constructor to prevent instantiation
        private ConfigurationsKeeper()
        {
            Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Populate the dictionary with configuration values
            foreach (string key in Config.AppSettings.Settings.AllKeys)
            {
                Data[key] = Config.AppSettings.Settings[key].Value;
            }
        }

        // Public static property to access the singleton instance
        public static ConfigurationsKeeper Instance() => SingletonInstance.Value;

        // Method to get a configuration value
        public string GetValue(string key)
        {
            if (Data.TryGetValue(key, out var value))
            {
                return value;
            }
            return string.Empty;
        }
    }
}
