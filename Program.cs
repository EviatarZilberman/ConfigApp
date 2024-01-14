using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;


Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

/*// Update or add a setting
//config.AppSettings.Settings["a"].Value = "AAA";
// Save the changes to the configuration file
config.Save(ConfigurationSaveMode.Modified);

// Force a reload of the updated configuration file
//System.Configuration.ConfigurationManager.RefreshSection("appSettings");*/
var a = config.AppSettings.Settings["last"].Value;
Console.WriteLine(a);



