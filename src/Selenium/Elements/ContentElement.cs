using AutomatedTestingFramework.Selenium.Interfaces.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using By = AutomatedTestingFramework.Selenium.By;

namespace AutomatedTestingFramework.Selenium.Elements
{
	public class ContentElement : WebElement, IContentElement
	{
		public ContentElement(IWebDriver driver, IWebElement webElement, By by)
			: base(driver, webElement, by)
		{ }

		public bool IsEnabled => Element.Enabled;

		public void Focus()
		{
			var action = new Actions(Driver);

			action.MoveToElement(Element).Perform();
		}

		public void Hover()
		{
			var action = new Actions(Driver);

			action.MoveToElement(Element).Perform();
		}
	}
}