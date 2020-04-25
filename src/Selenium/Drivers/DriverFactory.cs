using System;
using AutomatedTestingFramework.Selenium.Configuration;
using AutomatedTestingFramework.Selenium.Enums;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;
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
	internal class DriverFactory : IDriverFactory
	{
		private readonly AppSettings _appSettings;

		public DriverFactory(AppSettings appSettings) => _appSettings = appSettings;

		public IWebDriver CreateDriver(Browser browser)
		{
			if (_appSettings.EnableAutoBrowserConfiguration)
			{
				var driverManager = new DriverManager();

				switch (browser)
				{
					case Browser.Chrome:
						driverManager.SetUpDriver(new ChromeConfig());
						return new ChromeDriver();
					case Browser.Edge:
						driverManager.SetUpDriver(new EdgeConfig());
						return new EdgeDriver();
					case Browser.Firefox:
						driverManager.SetUpDriver(new FirefoxConfig());
						return new FirefoxDriver();
					case Browser.InternetExplorer:
						driverManager.SetUpDriver(new InternetExplorerConfig());
						return new InternetExplorerDriver();
					case Browser.Safari:
						throw new ApplicationException("Safari cannot be auto-configured");
					default:
						throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
				}
			}

			switch (browser)
			{
				case Browser.Chrome:
					return new ChromeDriver(_appSettings.DriverPath);
				case Browser.Edge:
					return new EdgeDriver(_appSettings.DriverPath);
				case Browser.Firefox:
					return new FirefoxDriver(_appSettings.DriverPath);
				case Browser.InternetExplorer:
					return new InternetExplorerDriver(_appSettings.DriverPath);
				case Browser.Safari:
					return new SafariDriver(_appSettings.DriverPath);
				default:
					throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
			}
		}
	}
}
