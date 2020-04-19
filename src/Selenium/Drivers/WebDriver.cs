using System;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTestingFramework.Selenium.Drivers
{
	public partial class WebDriver : Driver
	{
		private IWebDriver _driver;
		private WebDriverWait _webDriverWait;
		private readonly IDriverFactory _driverFactory;

		public WebDriver(IElementFinderService elementFinderService, IDriverFactory driverFactory)
		{
			_driverFactory = driverFactory;
			ElementFinderService = elementFinderService;
		}

		public WebDriverWait Wait => _webDriverWait ??= new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
	}
}