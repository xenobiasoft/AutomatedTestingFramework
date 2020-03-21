using System;
using System.Collections.Generic;
using AutomatedTestingFramework.Core.Enums;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.New.Driver
{
	public class LoggingDriver : DriverDecorator
	{
		public LoggingDriver(Driver driver) : base(driver)
		{
		}

		public override void Start(Browser browser)
		{
			Console.WriteLine($"Start browser = {Enum.GetName(typeof(Browser), browser)}");
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

		public override Element.Element FindElement(By locator)
		{
			Console.WriteLine($"Find Element by = {locator}");
			return Driver?.FindElement(locator);
		}

		public override List<Element.Element> FindElements(By locator)
		{
			Console.WriteLine($"Find elements by = {locator}");
			return Driver?.FindElements(locator);
		}

		public override void WaitForPageToLoad()
		{
			Console.WriteLine("Waiting for page to load.");
			Driver?.WaitForPageToLoad();
		}

		public override void WaitForAjax()
		{
			Console.WriteLine("Waiting for ajax.");
			Driver?.WaitForAjax();
		}

		public override void DeleteAllCookies()
		{
			Console.WriteLine("Deleting all cookies.");
		}
	}
}
