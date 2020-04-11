namespace AutomatedTestingFramework.Core.Configuration
{
	public class AppSettings
	{
		public AppSettings()
		{
			MediaSettings = new MediaSettings();
		}

		public string DriverLocation { get; set; }
		public MediaSettings MediaSettings { get; set; }
	}
}
