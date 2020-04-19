using AutomatedTestingFramework.Selenium.Interfaces.Elements;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.Elements
{
	public class Label : WebElement, ILabel
	{
		public Label(IWebDriver driver, IWebElement webElement, By by)
			: base(driver, webElement, by)
		{
		}

		public string Text => Element.Text;
	}
}