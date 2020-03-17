using AutomatedTestingFramework.Core.Enums;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace AutomatedTestingFramework.Selenium.New
{
	public class LoggingDriver : DriverDecorator
	{
		public LoggingDriver(Driver driver) : base(driver)
		{
		}

		public override void Start(BrowserType browser)
		{
			Console.WriteLine($"Start browser = {Enum.GetName(typeof(BrowserType), browser)}");
			Driver?.Start(browser);
		}

		public override void Quit()
		{
			Console.WriteLine($"Close browser");
			Driver?.Quit();
		}

		public override void GoToUrl(string url)
		{
			Console.WriteLine($"Go to URL = {url}");
			Driver?.GoToUrl(url);
		}

		public override Element FindElement(By locator)
		{
			Console.WriteLine($"Find Element by = {locator}");
			return Driver?.FindElement(locator);
		}

		public override List<Element> FindElements(By locator)
		{
			Console.WriteLine($"Find elements by = {locator}");
			return Driver?.FindElements(locator);
		}
	}
}
