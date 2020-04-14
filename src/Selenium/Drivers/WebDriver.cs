using System;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Selenium.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTestingFramework.Selenium.Drivers
{
	public partial class WebDriver : BaseDriver
	{
		private IWebDriver _driver;
		private WebDriverWait _webDriverWait;
		private readonly IDriverFactory _driverFactory;

		public WebDriver(IElementFinderService elementFinderService, IDriverFactory driverFactory)
		{
			_driverFactory = driverFactory;
			ElementFinderService = elementFinderService;
		}

		protected WebDriverWait DriverWait => _webDriverWait ??= new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
	}
}