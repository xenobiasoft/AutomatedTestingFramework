using AutomatedTestingFramework.Core.Controls;
using OpenQA.Selenium;
using By = AutomatedTestingFramework.Core.By;

namespace AutomatedTestingFramework.Selenium.Controls
{
	public class TextBox : ContentElement, ITextBox
	{
		public TextBox(IWebDriver driver, IWebElement webElement, By by)
			: base(driver, webElement, by)
		{ }

		public string Text
		{
			get => WebElement.GetAttribute("value");
			set
			{
				WebElement.Clear();
				WebElement.SendKeys(value);
			}
		}
	}
}