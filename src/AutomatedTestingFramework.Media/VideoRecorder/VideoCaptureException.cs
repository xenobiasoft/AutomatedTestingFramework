using System;

namespace AutomatedTestingFramework.Media.VideoRecorder
{
	public class VideoCaptureException : Exception
	{
		public VideoCaptureException(string message) : base(message)
		{
		}
	}
}