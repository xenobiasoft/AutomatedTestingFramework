using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using By = AutomatedTestingFramework.Core.By;

namespace AutomatedTestingFramework.Selenium.Controls
{
	public class WebElement : Element
	{
		protected readonly IWebElement Element;
		protected readonly IWebDriver Driver;

		public WebElement(IWebDriver driver, IWebElement webElement, By by)
		{
			By = by;
			Driver = driver;
			Element = webElement;
		}

		public override By By { get; }
		public override string CssClass => Element?.GetAttribute("className");
		public override bool? Displayed => Element?.Displayed;
		public override bool? Enabled => Element?.Enabled;
		public override int? Height => Element?.Size.Height;
		public override string Text => Element?.Text;
		public override int? Width => Element?.Size.Width;

		public override void Click()
		{
			WaitToByClickable();
			Element?.Click();
		}

		public override string GetAttribute(string attributeName) => Element?.GetAttribute(attributeName);

		public override void TypeText(string text)
		{
			Element?.Clear();
			Element?.SendKeys(text);
		}

		private void WaitToByClickable()
		{
			var webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));

			webDriverWait.Until(ExpectedConditions.ElementToBeClickable(By.ToSeleniumBy()));
		}
	}
}