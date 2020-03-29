using AutomatedTestingFramework.Core.Enums;

namespace AutomatedTestingFramework.Core.Attributes
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
