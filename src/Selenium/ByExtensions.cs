using System;
using AutomatedTestingFramework.Selenium.Enums;

namespace AutomatedTestingFramework.Selenium
{
	public static class ByExtensions
	{
		public static OpenQA.Selenium.By ToSeleniumBy(this By by)
		{
			switch (by.Type)
			{
				case SearchType.CssClass:
					return OpenQA.Selenium.By.ClassName(by.Value);

				case SearchType.CssClassContaining:
					return OpenQA.Selenium.By.CssSelector($"[class*='{by.Value}']");

				case SearchType.CssSelector:
					return OpenQA.Selenium.By.CssSelector(by.Value);

				case SearchType.Id:
					return OpenQA.Selenium.By.Id(by.Value);

				case SearchType.IdContaining:
					return OpenQA.Selenium.By.CssSelector($"[id*='{by.Value}']");

				case SearchType.InnerTextContaining:
					return OpenQA.Selenium.By.XPath($"//*[contains(text(), '{by.Value}']");

				case SearchType.LinkText:
					return OpenQA.Selenium.By.LinkText(by.Value);

				case SearchType.Name:
					return OpenQA.Selenium.By.Name(by.Value);

				case SearchType.Tag:
					return OpenQA.Selenium.By.TagName(by.Value);

				case SearchType.XPath:
					return OpenQA.Selenium.By.XPath(by.Value);

				default:
					throw new ArgumentOutOfRangeException($"Unknown search type : {by.Type}.");
			}
		}
	}
}