using AutomatedTestingFramework.Core.Controls;
using OpenQA.Selenium;
using By = AutomatedTestingFramework.Core.By;

namespace AutomatedTestingFramework.Selenium.Controls
{
	public class Button : ContentElement, IButton
	{
		public Button(IWebDriver driver, IWebElement webElement, By by)
			: base(driver, webElement, by)
		{ }
	}
}