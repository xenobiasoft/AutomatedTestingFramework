using System;
using AutomatedTestingFramework.Selenium.Enums;
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
		private static readonly string DriverLocation = Environment.CurrentDirectory;

		public IWebDriver CreateDriver(Browser browser)
		{
			switch (browser)
			{
				case Browser.Chrome:
					new DriverManager().SetUpDriver(new ChromeConfig());
					return new ChromeDriver();
				case Browser.Edge:
					return new EdgeDriver(DriverLocation);
				case Browser.Firefox:
					return new FirefoxDriver(DriverLocation);
				case Browser.InternetExplorer:
					return new InternetExplorerDriver(DriverLocation);
				case Browser.Safari:
					return new SafariDriver(DriverLocation);
				default:
					throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
			}
		}
	}
}
