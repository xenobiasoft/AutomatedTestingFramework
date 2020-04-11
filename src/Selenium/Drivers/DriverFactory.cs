using System;
using AutomatedTestingFramework.Core.Configuration;
using AutomatedTestingFramework.Core.Enums;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomatedTestingFramework.Selenium.Drivers
{
	public class DriverFactory : IDriverFactory
	{
		private readonly IOptions<AppSettings> _appSettings;

		public DriverFactory(IOptions<AppSettings> appSettings)
		{
			_appSettings = appSettings;
		}

		public IWebDriver CreateDriver(Browser browser)
		{
			switch (browser)
			{
				case Browser.Chrome:
					new DriverManager().SetUpDriver(new ChromeConfig());
					return new ChromeDriver();
				case Browser.Edge:
					return new EdgeDriver(_appSettings.Value.DriverLocation);
				case Browser.Firefox:
					return new FirefoxDriver(_appSettings.Value.DriverLocation);
				case Browser.InternetExplorer:
					return new InternetExplorerDriver(_appSettings.Value.DriverLocation);
				case Browser.Safari:
					return new SafariDriver(_appSettings.Value.DriverLocation);
				default:
					throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
			}
		}
	}
}
