using AutomatedTestingFramework.Core.Controls;
using AutomatedTestingFramework.Selenium.Driver;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.Controls
{
	public class Anchor : ContentElement, IAnchor
	{
		public Anchor(IWebDriver driver, IWebElement webElement, IElementFinderService elementFinderService) 
			: base(driver, webElement, elementFinderService)
		{}

		public string Url => WebElement.GetAttribute("href");
	}
}