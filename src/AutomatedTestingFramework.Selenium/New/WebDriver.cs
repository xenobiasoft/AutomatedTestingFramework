using AutomatedTestingFramework.Core.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomatedTestingFramework.Selenium.New
{
	public class WebDriver : Driver
	{
		private readonly IWebDriver _webDriver;
		private readonly WebDriverWait _webDriverWait;

		public WebDriver(BrowserType browser)
		{
			switch (browser)
			{
				case BrowserType.Chrome:
					_webDriver = new ChromeDriver(Environment.CurrentDirectory);
					break;
				case BrowserType.Edge:
					_webDriver = new EdgeDriver(Environment.CurrentDirectory);
					break;
				case BrowserType.Firefox:
					_webDriver = new FirefoxDriver(Environment.CurrentDirectory);
					break;
				case BrowserType.InternetExplorer:
					_webDriver = new InternetExplorerDriver(Environment.CurrentDirectory);
					break;
				case BrowserType.Safari:
					_webDriver = new SafariDriver(Environment.CurrentDirectory);
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
			}

			_webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
		}

		public override void Start(BrowserType browser)
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

		public override Element FindElement(By locator)
		{
			var nativeWebElement = _webDriverWait.Until(ExpectedConditions.ElementExists(locator));
			var element = new WebElement(_webDriver, nativeWebElement, locator);
			var logElement = new LogElement(element);

			return logElement;
		}

		public override List<Element> FindElements(By locator)
		{
			IReadOnlyCollection<IWebElement> nativeWebElements =
				_webDriverWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
			var elements = nativeWebElements
				.ToList()
				.Select(nativeWebElement => new WebElement(_webDriver, nativeWebElement, locator) as Element)
				.ToList();

			return elements;
		}
	}
}
