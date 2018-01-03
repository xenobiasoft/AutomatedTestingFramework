using AutomatedTestingFramework.Core.Controls;
using AutomatedTestingFramework.Selenium.Driver;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.Controls
{
	public class Checkbox : ContentElement, ICheckbox
	{
		public Checkbox(IWebDriver driver, IWebElement webElement, IElementFinderService elementFinderService) 
			: base(driver, webElement, elementFinderService)
		{}

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