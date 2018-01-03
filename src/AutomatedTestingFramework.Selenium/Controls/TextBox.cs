using AutomatedTestingFramework.Core.Controls;
using AutomatedTestingFramework.Selenium.Driver;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.Controls
{
	public class TextBox : ContentElement, ITextBox
	{
		public TextBox(IWebDriver driver, IWebElement webElement, IElementFinderService elementFinderService) 
			: base(driver, webElement, elementFinderService)
		{}

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