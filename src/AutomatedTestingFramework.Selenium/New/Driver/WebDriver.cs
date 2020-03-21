using System;
using System.Collections.Generic;
using System.Linq;
using AutomatedTestingFramework.Core.Enums;
using AutomatedTestingFramework.Selenium.New.Element;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTestingFramework.Selenium.New.Driver
{
	public class WebDriver : Driver
	{
		private readonly IWebDriver _webDriver;
		private readonly WebDriverWait _webDriverWait;

		public WebDriver(Browser browser)
		{
			switch (browser)
			{
				case Browser.Chrome:
					_webDriver = new ChromeDriver(Environment.CurrentDirectory);
					break;
				case Browser.Edge:
					_webDriver = new EdgeDriver(Environment.CurrentDirectory);
					break;
				case Browser.Firefox:
					_webDriver = new FirefoxDriver(Environment.CurrentDirectory);
					break;
				case Browser.InternetExplorer:
					_webDriver = new InternetExplorerDriver(Environment.CurrentDirectory);
					break;
				case Browser.Safari:
					_webDriver = new SafariDriver(Environment.CurrentDirectory);
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
			}

			_webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
		}

		public override void Start(Browser browser)
		{
			throw new NotImplementedException();
		}

		public override void Quit()
		{
			_webDriver.Quit();
		}

		public override void GoToUrl(string url)
		{
			_webDriver.Navigate().GoToUrl(url);
		}

		public override Element.Element FindElement(By locator)
		{
			var nativeWebElement = _webDriverWait.Until(ExpectedConditions.ElementExists(locator));
			var element = new WebElement(_webDriver, nativeWebElement, locator);
			var logElement = new LogElement(element);

			return logElement;
		}

		public override List<Element.Element> FindElements(By locator)
		{
			IReadOnlyCollection<IWebElement> nativeWebElements =
				_webDriverWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
			var elements = nativeWebElements
				.ToList()
				.Select(nativeWebElement => new WebElement(_webDriver, nativeWebElement, locator) as Element.Element)
				.ToList();

			return elements;
		}

		public override void WaitForAjax()
		{
			var js = (IJavaScriptExecutor)_webDriver;

			_webDriverWait.Until(x => js.ExecuteScript("return jQuery.active").ToString() == "0");
		}

		public override void WaitForPageToLoad()
		{
			var js = (IJavaScriptExecutor)_webDriver;

			_webDriverWait.Until(x => js.ExecuteScript("return document.readyState").ToString() == "complete");
		}

		public override void DeleteAllCookies()
		{
			_webDriver.Manage().Cookies.DeleteAllCookies();
		}
	}
}
