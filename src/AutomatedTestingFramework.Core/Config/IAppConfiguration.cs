namespace AutomatedTestingFramework.Core.Config
{
	public interface IAppConfiguration
	{
		string BaseUrl { get; }
		string MediaFolderPath { get; }
		bool AllowVideoRecording { get; }
	}
}