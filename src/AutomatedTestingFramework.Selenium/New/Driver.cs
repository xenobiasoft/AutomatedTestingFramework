using AutomatedTestingFramework.Core.Enums;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace AutomatedTestingFramework.Selenium.New
{
	public abstract class Driver
	{
		public abstract void Start(BrowserType browser);
		public abstract void Quit();
		public abstract void GoToUrl(string url);
		public abstract Element FindElement(By locator);
		public abstract List<Element> FindElements(By locator);
	}
}
