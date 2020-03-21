using System.Collections.Generic;
using AutomatedTestingFramework.Core.Enums;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.New.Driver
{
	public abstract class Driver
	{
		public abstract void Start(Browser browser);
		public abstract void Quit();
		public abstract void GoToUrl(string url);
		public abstract Element.Element FindElement(By locator);
		public abstract List<Element.Element> FindElements(By locator);
		public abstract void WaitForAjax();
		public abstract void WaitForPageToLoad();
		public abstract void DeleteAllCookies();
	}
}
