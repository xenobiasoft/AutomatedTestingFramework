namespace AutomatedTestingFramework.Core.Config
{
	public interface IAppConfiguration
	{
		string BaseUrl { get; }
		string DriverLocation { get; }
		string MediaFolderPath { get; }
		bool AllowVideoRecording { get; }
		int VideoRecordingFrameRate { get; }
		int VideoRecordingQuality { get; }
		bool IsTestMode { get; }
	}
}