using AutomatedTestingFramework.Selenium.Interfaces.Elements;
using OpenQA.Selenium;
using By = AutomatedTestingFramework.Selenium.By;

namespace AutomatedTestingFramework.Selenium.Elements
{
	public class Button : ContentElement, IButton
	{
		public Button(IWebDriver driver, IWebElement webElement, By by)
			: base(driver, webElement, by)
		{ }
	}
}