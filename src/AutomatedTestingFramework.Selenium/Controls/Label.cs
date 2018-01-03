using AutomatedTestingFramework.Core.Controls;
using AutomatedTestingFramework.Selenium.Driver;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.Controls
{
	public class Label : ContentElement, ILabel
	{
		public Label(IWebDriver driver, IWebElement webElement, IElementFinderService elementFinderService) 
			: base(driver, webElement, elementFinderService)
		{
		}

		public string Text => WebElement.Text;
	}
}