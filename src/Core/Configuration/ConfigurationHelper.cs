using Microsoft.Extensions.Configuration;

namespace AutomatedTestingFramework.Core.Configuration
{
	public class ConfigurationHelper
	{
		public static IConfigurationRoot GetConfigurationRoot(string outputPath)
		{
			return new ConfigurationBuilder()
				.SetBasePath(outputPath)
				.AddJsonFile("appsettings.json", optional: true)
				.Build();
		}

		public static AppSettings GetAppSettings(string outputPath)
		{
			var appSettings = new AppSettings();

			GetConfigurationRoot(outputPath)
				.GetSection("appsettings")
				.Bind(appSettings);

			return appSettings;
		}
	}
}
