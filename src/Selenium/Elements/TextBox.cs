using AutomatedTestingFramework.Selenium.Interfaces.Elements;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.Elements
{
	public class TextBox : WebElement, ITextBox
	{
		public TextBox(IWebDriver driver, IWebElement webElement, By by)
			: base(driver, webElement, by)
		{ }

		public string Text => Element.GetAttribute("value");

		public void TypeText(string textToType)
		{
			Element?.Clear();
			Element?.SendKeys(textToType);
		}
	}
}