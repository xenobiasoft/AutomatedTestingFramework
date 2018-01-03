using System;
using AutomatedTestingFramework.Core.Config;
using AutomatedTestingFramework.Core.Driver;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.Driver
{
	public partial class SeleniumDriver : IDriver
	{
		private readonly IWebDriver _driver;
		private readonly IAppConfiguration _appConfiguration;
		private readonly IBrowserDefaults _browserDefaults;

		public SeleniumDriver(IBrowserDefaults browserDefaults, IElementFinderService elementFinderService)
			: this(browserDefaults, elementFinderService, new AppConfiguration())
		{}

		public SeleniumDriver(IBrowserDefaults browserDefaults, IElementFinderService elementFinderService, IAppConfiguration appConfiguration)
		{
			_browserDefaults = browserDefaults;
			_appConfiguration = appConfiguration;
			ElementFinderService = elementFinderService;
			_driver = browserDefaults.DefaultBrowser;
		}

		public void Dispose()
		{
			_driver.Quit();
			_driver.Dispose();
		}

		private void TurnOffImplicitWait()
		{
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
		}

		private void TurnOnImplicitWait()
		{
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_browserDefaults.PageLoadTimeoutValue);
		}
	}
}