using System;
using System.IO;
using AutomatedTestingFramework.Core.Config;

namespace AutomatedTestingFramework.Media
{
	public static class MediaFileUtil
	{
		private const string FileNameDateFormat = "yyyyMMddHHmmssfff";
		
		private static readonly string _TempMediaFolderPath;

		static MediaFileUtil()
		{
			_TempMediaFolderPath = Path.GetTempPath();
		}

		public static string GetTempFilenameWithPath(MediaFileType fileType)
		{
			var filename = GetFilenameWithExtension(Guid.NewGuid().ToString(), fileType);

			return Path.Combine(_TempMediaFolderPath, filename);
		}

		public static string GetFinalFilenameWithPath(string name, MediaFileType fileType)
		{
			var filename = GetFilenameWithExtension(name, fileType);

			return Path.Combine(MediaFolderPath, filename);
		}

		public static string GetDateFormattedFilenameWithPath(string name, MediaFileType fileType)
		{
			var filenameWithoutExtension = string.Concat(name, "_", DateTime.Now.ToString(FileNameDateFormat));
			var filename = GetFilenameWithExtension(filenameWithoutExtension, fileType);

			return Path.Combine(MediaFolderPath, filename);
		}

		public static bool MediaFolderExists()
		{
			return Directory.Exists(MediaFolderPath);
		}

		private static string GetFilenameWithExtension(string filename, MediaFileType fileType)
		{
			return $"{filename}{GetExtension(fileType)}";
		}

		private static string GetExtension(MediaFileType fileType)
		{
			return $".{fileType.ToString().ToLower()}";
		}

		public static string MediaFolderPath => new AppConfiguration().MediaFolderPath;
	}
}