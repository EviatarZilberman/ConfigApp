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
        public static ConfigurationsKeeper Instance() => _instance.Value;

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
