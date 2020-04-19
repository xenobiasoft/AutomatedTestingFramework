using AutomatedTestingFramework.Selenium.Interfaces.Elements;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.Elements
{
	public class WebImage : WebElement, IWebImage
	{
		public WebImage(IWebDriver driver, IWebElement webElement, By by)
			: base(driver, webElement, by)
		{ }

		public string AltText => Element.GetAttribute("alt");
		public string Src => Element.GetAttribute("src");
	}
}