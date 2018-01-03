using System.Configuration;

namespace AutomatedTestingFramework.Core.Config
{
	public class BrowserSettingsConfigurationProvider : ConfigurationSection
	{
		private static readonly BrowserSettingsConfiguration BrowserSettingsConfiguration;

		static BrowserSettingsConfigurationProvider()
		{
			try
			{
				BrowserSettingsConfiguration = (BrowserSettingsConfiguration) ConfigurationManager.GetSection("browserSettings");
			}
			catch (ConfigurationErrorsException ex)
			{
				throw new ConfigurationErrorsException("Please configure the BrowserSettings configuration.", ex);
			}
		}

		public static BrowserSettingsConfiguration GetSettings()
		{
			return BrowserSettingsConfiguration;
		}
	}
}