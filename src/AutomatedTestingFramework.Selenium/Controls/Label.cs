using AutomatedTestingFramework.Core.Controls;
using OpenQA.Selenium;
using By = AutomatedTestingFramework.Core.By;

namespace AutomatedTestingFramework.Selenium.Controls
{
	public class Label : ContentElement, ILabel
	{
		public Label(IWebDriver driver, IWebElement webElement, By by)
			: base(driver, webElement, by)
		{
		}

		public string Text => WebElement.Text;
	}
}