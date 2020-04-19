using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace AutomatedTestingFramework.Selenium.Configuration
{
	public class ConfigurationService
	{
		private static ConfigurationService _instance;

		public ConfigurationService() => Root = InitializeConfiguration();

		public static ConfigurationService Instance => _instance ??= new ConfigurationService();

		public IConfigurationRoot Root { get; set; }

		public TSettings GetSettings<TSettings>(string settingsName) where TSettings : class, new()
		{
			var result = Instance.Root.GetSection(settingsName).Get<TSettings>();

			if (result == null)
			{
				throw new ConfigurationNotFoundException(typeof(TSettings).ToString());
			}

			return result;
		}

		private IConfigurationRoot InitializeConfiguration()
		{
			var filesInExecutionDirectory =
				Directory.GetFiles(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location));
			var settingsFile = filesInExecutionDirectory
				.FirstOrDefault(x => x.Contains("frameworkSettings") && x.EndsWith(".json"));
			var builder = new ConfigurationBuilder();

			if (settingsFile != null)
			{
				builder.AddJsonFile(settingsFile, true, true);
			}

			return builder.Build();
		}
	}
}
