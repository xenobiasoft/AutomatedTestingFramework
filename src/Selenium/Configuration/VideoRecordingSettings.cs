namespace AutomatedTestingFramework.Selenium.Configuration
{
	public class VideoRecordingSettings
	{
		public virtual bool EnableVideoRecording { get; set; }
		public virtual string MediaFolderPath { get; set; }
		public virtual string FFMpegPath { get; set; }
	}
}
