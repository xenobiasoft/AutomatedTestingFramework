using AutomatedTestingFramework.Core.Controls;
using AutomatedTestingFramework.Selenium.Driver;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.Controls
{
	public class WebImage : ContentElement, IWebImage
	{
		public WebImage(IWebDriver driver, IWebElement webElement, IElementFinderService elementFinderService) 
			: base(driver, webElement, elementFinderService)
		{}

		public string AltText => WebElement.GetAttribute("alt");
		public string Src => WebElement.GetAttribute("src");
	}
}