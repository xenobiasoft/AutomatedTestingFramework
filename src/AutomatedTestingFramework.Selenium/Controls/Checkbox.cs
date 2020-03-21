using AutomatedTestingFramework.Core.Controls;
using OpenQA.Selenium;
using By = AutomatedTestingFramework.Core.By;

namespace AutomatedTestingFramework.Selenium.Controls
{
	public class Checkbox : ContentElement, ICheckbox
	{
		public Checkbox(IWebDriver driver, IWebElement webElement, By by)
			: base(driver, webElement, by)
		{ }

		public bool IsChecked => WebElement.Selected;

		public void Check()
		{
			if (!WebElement.Selected)
			{
				WebElement.Click();
			}
		}

		public void Uncheck()
		{
			if (WebElement.Selected)
			{
				WebElement.Click();
			}
		}
	}
}