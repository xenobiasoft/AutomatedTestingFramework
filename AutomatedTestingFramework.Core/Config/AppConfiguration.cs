using System;
using System.Configuration;

namespace AutomatedTestingFramework.Core.Config
{
	public class AppConfiguration : IAppConfiguration
	{
		public string BaseUrl => TryGetValue("BaseUrl", string.Empty);

		public string DefaultTestUsername => TryGetValue("DefaultTestUsername", string.Empty);

		public string DefaultTestPassword => TryGetValue("DefaultTestPassword", string.Empty);

		public string MediaFolderPath => TryGetValue("MediaFolderPath", string.Empty);

		public bool AllowVideoRecording => TryGetValue("AllowVideoRecording", false);

		public bool IsTestMode => TryGetValue("IsTestMode", true);

		private T TryGetValue<T>(string key, T defaultValue)
		{
			var strValue = ConfigurationManager.AppSettings[key];

			return strValue == null ? defaultValue : (T)Convert.ChangeType(strValue, typeof(T));
		}
	}
}