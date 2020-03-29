using AutomatedTestingFramework.Core.Elements;
using OpenQA.Selenium;
using By = AutomatedTestingFramework.Core.By;

namespace AutomatedTestingFramework.Selenium.Elements
{
	public class Anchor : ContentElement, IAnchor
	{
		public Anchor(IWebDriver driver, IWebElement webElement, By by)
			: base(driver, webElement, by)
		{ }

		public string Url => Element.GetAttribute("href");
	}
}