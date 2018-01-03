using System;

namespace AutomatedTestingFramework.Media.VideoRecorder
{
	public interface IVideoRecorder : IDisposable
	{
		VideoRecordingStatus Status { get; }
		void StartCapture();
		void SaveVideo(string testName);
	}
}