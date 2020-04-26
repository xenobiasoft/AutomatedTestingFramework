using System;
using System.IO;
using AutomatedTestingFramework.Selenium.Configuration;
using AutomatedTestingFramework.Selenium.Interfaces;

namespace AutomatedTestingFramework.Selenium.BehaviorObserver
{
	public class VideoRecorderOutputProvider : IVideoRecorderOutputProvider
	{
		private readonly AppSettings _appSettings;

		public VideoRecorderOutputProvider(AppSettings appSettings)
		{
			_appSettings = appSettings;
		}

		public string GetOutputFolder()
		{
			var outputDir = _appSettings.VideoRecording.MediaFolderPath;

			if (!Directory.Exists(outputDir))
			{
				Directory.CreateDirectory(outputDir);
			}

			return outputDir;
		}

		public string GetUniqueFileName(string testName) => string.Concat(testName, Guid.NewGuid().ToString());

		public bool VideoRecordingEnabled => _appSettings.VideoRecording.EnableVideoRecording;
	}
}
