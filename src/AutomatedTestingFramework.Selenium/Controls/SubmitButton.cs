using AutomatedTestingFramework.Core.Controls;
using OpenQA.Selenium;
using By = AutomatedTestingFramework.Core.By;

namespace AutomatedTestingFramework.Selenium.Controls
{
	public class SubmitButton : ContentElement, ISubmitButton
	{
		public SubmitButton(IWebDriver driver, IWebElement webElement, By by)
			: base(driver, webElement, by)
		{ }
	}
}