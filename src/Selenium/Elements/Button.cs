using AutomatedTestingFramework.Selenium.Interfaces.Elements;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.Elements
{
	public class Button : WebElement, IButton
	{
		public Button(IWebDriver driver, IWebElement webElement, By by)
			: base(driver, webElement, by)
		{ }
	}
}