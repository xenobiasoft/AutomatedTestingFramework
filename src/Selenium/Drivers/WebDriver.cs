using System;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Core.Enums;
using AutomatedTestingFramework.Selenium.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTestingFramework.Selenium.Drivers
{
	public partial class WebDriver : BaseDriver
	{
		private readonly IWebDriver _driver;
		private readonly WebDriverWait _webDriverWait;

		public WebDriver(Browser browser, IElementFinderService elementFinderService, IDriverFactory driverFactory)
		{
			ElementFinderService = elementFinderService;

			_driver = driverFactory.CreateDriver(browser);

			_webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
		}
	}
}