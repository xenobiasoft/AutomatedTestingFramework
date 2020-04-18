using System;
using AutomatedTestingFramework.Selenium.Enums;

namespace AutomatedTestingFramework.Selenium.Attributes
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class ExecutionBrowserAttribute : Attribute
	{
		public ExecutionBrowserAttribute(Browser browser, BrowserBehavior browserBehavior)
		{
			BrowserConfiguration = new BrowserConfiguration(browser, browserBehavior);
		}

		public BrowserConfiguration BrowserConfiguration { get; }
	}
}
