using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using AutomatedTestingFramework.Selenium.Configuration;
using AutomatedTestingFramework.Selenium.Interfaces;

namespace AutomatedTestingFramework.Selenium.Media
{
	public class MpegVideoRecorder : IVideoRecorder
	{
		private Process _recorderProcess;
		private bool _isRunning;
		private readonly AppSettings _appSettings;

		public MpegVideoRecorder(AppSettings appSettings)
		{
			_appSettings = appSettings;
		}

		public string Record(string filePath, string fileName)
		{
			var videoPath = Path.Combine(filePath, fileName);
			var videoPathWithExtension = GetFilePathWithExtensionByOS(videoPath);

			if (!_isRunning)
			{
				var startInfo = GetProcessStartInfoByOS(videoPathWithExtension);
				_recorderProcess = Process.Start(startInfo);
				_isRunning = true;
			}

			return videoPathWithExtension;
		}

		public void Stop() => Dispose();

		public void Dispose()
		{
			if (!_isRunning) return;

			Thread.Sleep(1000);

			if (!_recorderProcess.HasExited)
			{
				_recorderProcess.Kill();
				_recorderProcess.WaitForExit();
			}

			_isRunning = false;
		}

		private string GetFFMPegPath() => Path.Combine(_appSettings.VideoRecording.FFMpegPath, "ffmpeg.exe");

		private ProcessStartInfo GetProcessStartInfoByOS(string filePath)
		{
			var startInfo = new ProcessStartInfo
			{
				FileName = GetFFMPegPath(),
				RedirectStandardInput = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = false,
			};

			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				startInfo.Arguments = $"-f gdigrab -framerate 30 -i desktop {filePath}";
			}
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			{
				startInfo.Arguments = $"-f avfoundation -framerate 30 -i default {filePath}";
			}
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			{
				startInfo.Arguments = $"-f x11grab -framerate 30 -i :0.0+100,200 {filePath}";
			}
			else
			{
				throw new NotSupportedException("The OS is not supported by FFmpeg video recorder. Currently supported OS are Windows, MacOS, Linux.");
			}

			return startInfo;
		}

		private string GetFilePathWithExtensionByOS(string filePath)
		{
			string pathWithExtension;

			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				pathWithExtension = $"{filePath}.mpg";
			}
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			{
				pathWithExtension = $"{filePath}.mov";
			}
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			{
				pathWithExtension = $"{filePath}.mp4";
			}
			else
			{
				throw new NotSupportedException("The OS is not supported by FFmpeg video recorder. Currently supported OS are Windows, MacOS, Linux.");
			}

			return pathWithExtension;
		}
	}
}
