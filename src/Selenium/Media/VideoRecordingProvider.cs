using System;
using System.IO;
using AutomatedTestingFramework.Selenium.Configuration;
using AutomatedTestingFramework.Selenium.Interfaces;

namespace AutomatedTestingFramework.Selenium.Media
{
	public class VideoRecordingProvider : IVideoRecordingProvider
	{
		private readonly AppSettings _appSettings;

		public VideoRecordingProvider(AppSettings appSettings)
		{
			_appSettings = appSettings;
		}

		public string GetOutputFolder()
		{
			var outputDir = _appSettings.VideoRecording.MediaFolderPath;

			try
			{
				if (!Directory.Exists(outputDir))
				{
					Directory.CreateDirectory(outputDir);
				}
			}
			catch (Exception ex)
			{
				throw new ArgumentException($"A problem occurred trying to create the directory {outputDir}", ex);
			}

			return outputDir;
		}

		public string GetUniqueFileName(string testName) => string.Concat(testName, Guid.NewGuid().ToString());

		public bool VideoRecordingEnabled => _appSettings.VideoRecording.EnableVideoRecording;

		public void DeleteRecording(string filePath)
		{
			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}
		}
	}
}
