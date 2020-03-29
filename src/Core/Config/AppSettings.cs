namespace AutomatedTestingFramework.Core.Config
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
