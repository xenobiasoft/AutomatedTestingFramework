using System;
using AutomatedTestingFramework.Core.Enums;

namespace AutomatedTestingFramework.Selenium.New.BehaviorObserver
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
