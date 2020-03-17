using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTestingFramework.Selenium.New
{
	public class WebElement : Element
	{
		private readonly IWebDriver _webDriver;
		private readonly IWebElement _webElement;

		public WebElement(IWebDriver webDriver, IWebElement webElement, By by)
		{
			By = by;
			_webElement = webElement;
			_webDriver = webDriver;
		}

		public override By By { get; }

		public override bool? Displayed => _webElement?.Displayed;

		public override bool? Enabled => _webElement?.Enabled;

		public override string Text => _webElement?.Text;

		public override void Click()
		{
			WaitToByClickable();
			_webElement?.Click();
		}

		public override string GetAttribute(string attributeName) => _webElement?.GetAttribute(attributeName);

		public override void TypeText(string text)
		{
			_webElement?.Clear();
			_webElement?.SendKeys(text);
		}

		private void WaitToByClickable()
		{
			var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));

			webDriverWait.Until(ExpectedConditions.ElementToBeClickable(By));
		}
	}
}
