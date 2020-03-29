using AutomatedTestingFramework.Core.Elements;
using OpenQA.Selenium;
using By = AutomatedTestingFramework.Core.By;

namespace AutomatedTestingFramework.Selenium.Elements
{
	public class TextBox : ContentElement, ITextBox
	{
		public TextBox(IWebDriver driver, IWebElement webElement, By by)
			: base(driver, webElement, by)
		{ }

		public string Text
		{
			get => Element.GetAttribute("value");
			set
			{
				Element.Clear();
				Element.SendKeys(value);
			}
		}
	}
}