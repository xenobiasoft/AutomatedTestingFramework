using AutomatedTestingFramework.Selenium.Enums;

namespace AutomatedTestingFramework.Selenium.Attributes
{
	public class BrowserConfiguration
	{
		public BrowserConfiguration()
		{
		}

		public BrowserConfiguration(Browser browser, BrowserBehavior browserBehavior)
		{
			Browser = browser;
			BrowserBehavior = browserBehavior;
		}

		public Browser Browser { get; }

		public BrowserBehavior BrowserBehavior { get; }
	}
}
