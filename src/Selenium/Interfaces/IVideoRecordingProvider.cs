namespace AutomatedTestingFramework.Selenium.Interfaces
{
	public interface IVideoRecordingProvider
	{
		string GetOutputFolder();
		string GetUniqueFileName(string testName);
		bool VideoRecordingEnabled { get; }
		void DeleteRecording(string filePath);
	}
}