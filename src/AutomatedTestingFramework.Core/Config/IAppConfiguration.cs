namespace AutomatedTestingFramework.Core.Config
{
	public interface IAppConfiguration
	{
		string BaseUrl { get; }
		string DefaultTestUsername { get; }
		string DefaultTestPassword { get; }
		string MediaFolderPath { get; }
		bool AllowVideoRecording { get; }
	}
}