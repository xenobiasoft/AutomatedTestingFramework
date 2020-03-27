using System;
using AutomatedTestingFramework.Core.Config;
using AutomatedTestingFramework.Core.Driver;
using AutomatedTestingFramework.Core.Enums;
using AutomatedTestingFramework.Selenium.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTestingFramework.Selenium.Driver
{
	public partial class WebDriver : BaseDriver
	{
		private readonly IWebDriver _driver;
		private readonly WebDriverWait _webDriverWait;
		private readonly IAppConfiguration _appConfiguration;

		public WebDriver(Browser browser, IElementFinderService elementFinderService, IAppConfiguration appConfiguration)
		{
			_appConfiguration = appConfiguration;
			ElementFinderService = elementFinderService;

			switch (browser)
			{
				case Browser.Chrome:
					_driver = new ChromeDriver(Environment.CurrentDirectory);
					break;
				case Browser.Edge:
					_driver = new EdgeDriver(Environment.CurrentDirectory);
					break;
				case Browser.Firefox:
					_driver = new FirefoxDriver(Environment.CurrentDirectory);
					break;
				case Browser.InternetExplorer:
					_driver = new InternetExplorerDriver(Environment.CurrentDirectory);
					break;
				case Browser.Safari:
					_driver = new SafariDriver(Environment.CurrentDirectory);
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
			}

			_webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
		}
	}
}