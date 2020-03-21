using System;
using AutomatedTestingFramework.Core.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using By = AutomatedTestingFramework.Core.By;

namespace AutomatedTestingFramework.Selenium.Controls
{
	public class Element : IElement
	{
		protected readonly IWebElement WebElement;
		protected readonly IWebDriver Driver;

		public Element(IWebDriver driver, IWebElement webElement, By by)
		{
			By = by;
			Driver = driver;
			WebElement = webElement;
		}

		public By By { get; }
		public string CssClass => WebElement?.GetAttribute("className");
		public bool? Displayed => WebElement?.Displayed;
		public bool? Enabled => WebElement?.Enabled;
		public int? Height => WebElement?.Size.Height;
		public virtual string Text => WebElement?.Text;
		public int? Width => WebElement?.Size.Width;

		public void Click()
		{
			WaitToByClickable();
			WebElement?.Click();
		}

		public string GetAttribute(string attributeName) => WebElement?.GetAttribute(attributeName);

		public void TypeText(string text)
		{
			WebElement?.Clear();
			WebElement?.SendKeys(text);
		}

		private void WaitToByClickable()
		{
			var webDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));

			webDriverWait.Until(ExpectedConditions.ElementToBeClickable(By.ToSeleniumBy()));
		}
	}
}