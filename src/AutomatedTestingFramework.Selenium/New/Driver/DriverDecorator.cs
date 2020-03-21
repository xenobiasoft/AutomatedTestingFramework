using System.Collections.Generic;
using AutomatedTestingFramework.Core.Enums;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.New.Driver
{
	public abstract class DriverDecorator : Driver
	{
		protected readonly Driver Driver;

		protected DriverDecorator(Driver driver)
		{
			Driver = driver;
		}

		public override void Start(Browser browser)
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

		public override Element.Element FindElement(By locator)
		{
			return Driver?.FindElement(locator);
		}

		public override List<Element.Element> FindElements(By locator)
		{
			return Driver?.FindElements(locator);
		}
	}
}
