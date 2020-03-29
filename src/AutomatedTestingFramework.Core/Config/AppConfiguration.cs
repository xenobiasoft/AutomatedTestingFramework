using System;
using System.Configuration;

namespace AutomatedTestingFramework.Core.Config
{
	public class AppConfiguration : IAppConfiguration
	{
		public string BaseUrl => TryGetValue("BaseUrl", string.Empty);

		public string DriverLocation => TryGetValue("DriverLocation", Environment.CurrentDirectory);

		public string MediaFolderPath => TryGetValue("MediaFolderPath", string.Empty);

		public bool AllowVideoRecording => TryGetValue("AllowVideoRecording", false);

		public int VideoRecordingFrameRate => TryGetValue("VideoRecordingFrameRate", 5);

		public int VideoRecordingQuality => TryGetValue("VideoRecordingQuality", 10);

		public bool IsTestMode => TryGetValue("IsTestMode", true);

		private T TryGetValue<T>(string key, T defaultValue)
		{
			var strValue = ConfigurationManager.AppSettings[key];

			return strValue == null ? defaultValue : (T)Convert.ChangeType(strValue, typeof(T));
		}
	}
}