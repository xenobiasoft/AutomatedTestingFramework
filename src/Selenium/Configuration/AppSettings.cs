namespace AutomatedTestingFramework.Selenium.Configuration
{
	public class AppSettings
	{
		public virtual string BaseUrl { get; set; }
		public virtual string DriverPath { get; set; }
		public virtual int ElementWaitTime { get; set; }
		public virtual bool EnableAutoBrowserConfiguration { get; set; }
		public virtual VideoRecordingSettings VideoRecording { get; set; }
		public virtual BrowserSettings Chrome { get; set; }
		public virtual BrowserSettings Firefox { get; set; }
		public virtual BrowserSettings Edge { get; set; }
		public virtual BrowserSettings InternetExplorer { get; set; }
		public virtual BrowserSettings Safari { get; set; }
	}
}
