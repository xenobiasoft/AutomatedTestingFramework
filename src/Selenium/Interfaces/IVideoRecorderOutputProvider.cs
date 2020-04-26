namespace AutomatedTestingFramework.Selenium.Interfaces
{
	public interface IVideoRecorderOutputProvider
	{
		string GetOutputFolder();
		string GetUniqueFileName(string testName);
		bool VideoRecordingEnabled { get; }
	}
}