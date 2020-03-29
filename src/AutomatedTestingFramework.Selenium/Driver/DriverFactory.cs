using System;
using AutomatedTestingFramework.Core.Config;
using AutomatedTestingFramework.Core.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;

namespace AutomatedTestingFramework.Selenium.Driver
{
	public class DriverFactory : IDriverFactory
	{
		private readonly IAppConfiguration _appConfiguration;

		public DriverFactory(IAppConfiguration appConfiguration)
		{
			_appConfiguration = appConfiguration;
		}

		public IWebDriver CreateDriver(Browser browser)
		{
			switch (browser)
			{
				case Browser.Chrome:
					return new ChromeDriver(_appConfiguration.DriverLocation);
				case Browser.Edge:
					return new EdgeDriver(_appConfiguration.DriverLocation);
				case Browser.Firefox:
					return new FirefoxDriver(_appConfiguration.DriverLocation);
				case Browser.InternetExplorer:
					return new InternetExplorerDriver(_appConfiguration.DriverLocation);
				case Browser.Safari:
					return new SafariDriver(_appConfiguration.DriverLocation);
				default:
					throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
			}
		}
	}
}
