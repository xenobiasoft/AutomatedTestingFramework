using AutomatedTestingFramework.Core.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using By = AutomatedTestingFramework.Core.By;

namespace AutomatedTestingFramework.Selenium.Controls
{
	public class DropDown : ContentElement, IDropDown
	{
		public DropDown(IWebDriver driver, IWebElement webElement, By by)
			: base(driver, webElement, by)
		{ }

		public string SelectedValue
		{
			get
			{
				var select = new SelectElement(WebElement);

				return select.SelectedOption.Text;
			}
		}

		public void SelectValue(string value)
		{
			var select = new SelectElement(WebElement);

			select.SelectByValue(value);
		}

		public void SelectText(string text)
		{
			var select = new SelectElement(WebElement);

			select.SelectByText(text);
		}
	}
}