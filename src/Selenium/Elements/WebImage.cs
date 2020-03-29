using AutomatedTestingFramework.Core.Elements;
using OpenQA.Selenium;
using By = AutomatedTestingFramework.Core.By;

namespace AutomatedTestingFramework.Selenium.Elements
{
	public class WebImage : ContentElement, IWebImage
	{
		public WebImage(IWebDriver driver, IWebElement webElement, By by)
			: base(driver, webElement, by)
		{ }

		public string AltText => Element.GetAttribute("alt");
		public string Src => Element.GetAttribute("src");
	}
}