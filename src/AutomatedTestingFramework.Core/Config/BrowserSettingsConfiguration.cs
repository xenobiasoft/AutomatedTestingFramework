using System.Configuration;
using AutomatedTestingFramework.Core.Enums;

namespace AutomatedTestingFramework.Core.Config
{
	public class BrowserSettingsConfiguration : ConfigurationSection, IBrowserSettingsConfiguration
	{
		[ConfigurationProperty("driverLocation", IsRequired = true)]
		public string DriverLocation => (string) this["driverLocation"];

		[ConfigurationProperty("defaultBrowser", IsRequired = true)]
		public BrowserType DefaultBrowser => (BrowserType) this["defaultBrowser"];

		[ConfigurationProperty("scriptTimeout", DefaultValue = 30, IsRequired = true)]
		public int ScriptTimeout => (int) this["scriptTimeout"];

		[ConfigurationProperty("pageLoadTimeout", DefaultValue = 30, IsRequired = true)]
		public int PageLoadTimeout => (int) this["pageLoadTimeout"];

		[ConfigurationProperty("implicitWaitTimeout", DefaultValue = 30, IsRequired = true)]
		public int ImplicitWaitTimeout => (int) this["implicitWaitTimeout"];
	}
}