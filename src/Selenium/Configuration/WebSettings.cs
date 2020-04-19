namespace AutomatedTestingFramework.Selenium.Configuration
{
	public class WebSettings
	{
		public string BaseUrl { get; set; }
		public int ElementWaitTime { get; set; }
		public BrowserSettings Chrome { get; set; }
		public BrowserSettings Firefox { get; set; }
		public BrowserSettings Edge { get; set; }
		public BrowserSettings InternetExplorer { get; set; }
		public BrowserSettings Safari { get; set; }
	}
}
