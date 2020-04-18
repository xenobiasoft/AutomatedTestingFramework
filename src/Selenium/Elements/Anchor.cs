using AutomatedTestingFramework.Selenium.Interfaces.Elements;
using OpenQA.Selenium;
using By = AutomatedTestingFramework.Selenium.By;

namespace AutomatedTestingFramework.Selenium.Elements
{
	public class Anchor : ContentElement, IAnchor
	{
		public Anchor(IWebDriver driver, IWebElement webElement, By by)
			: base(driver, webElement, by)
		{ }

		public string Href => Element.GetAttribute("href");
	}
}