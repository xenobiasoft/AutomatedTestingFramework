using AutomatedTestingFramework.Selenium.Interfaces.Elements;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.Elements
{
	public class Anchor : WebElement, IAnchor
	{
		public Anchor(IWebDriver driver, IWebElement webElement, By by)
			: base(driver, webElement, by)
		{ }

		public string Href => Element.GetAttribute("href");
	}
}