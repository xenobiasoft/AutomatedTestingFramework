using AutomatedTestingFramework.Core.Enums;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace AutomatedTestingFramework.Selenium.New
{
	public abstract class DriverDecorator : Driver
	{
		protected readonly Driver Driver;

		protected DriverDecorator(Driver driver)
		{
			Driver = driver;
		}

		public override void Start(BrowserType browser)
		{
			Driver?.Start(browser);
		}

		public override void Quit()
		{
			Driver?.Quit();
		}

		public override void GoToUrl(string url)
		{
			Driver?.GoToUrl(url);
		}

		public override Element FindElement(By locator)
		{
			return Driver?.FindElement(locator);
		}

		public override List<Element> FindElements(By locator)
		{
			return Driver?.FindElements(locator);
		}
	}
}
