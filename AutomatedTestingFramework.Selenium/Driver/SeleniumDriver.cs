using System;
using AutomatedTestingFramework.Core.Config;
using AutomatedTestingFramework.Core.Driver;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.Driver
{
	public partial class SeleniumDriver : IDriver
	{
		private readonly IWebDriver _Driver;
		private readonly IAppConfiguration _AppConfiguration;
		private readonly IBrowserDefaults _BrowserDefaults;

		public SeleniumDriver(IBrowserDefaults browserDefaults, IElementFinderService elementFinderService)
			: this(browserDefaults, elementFinderService, new AppConfiguration())
		{}

		public SeleniumDriver(IBrowserDefaults browserDefaults, IElementFinderService elementFinderService, IAppConfiguration appConfiguration)
		{
			_BrowserDefaults = browserDefaults;
			_AppConfiguration = appConfiguration;
			ElementFinderService = elementFinderService;
			_Driver = browserDefaults.DefaultBrowser;
		}

		public void Dispose()
		{
			_Driver.Quit();
			_Driver.Dispose();
		}

		private void TurnOffImplicitWait()
		{
			_Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
		}

		private void TurnOnImplicitWait()
		{
			_Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_BrowserDefaults.PageLoadTimeoutValue);
		}
	}
}