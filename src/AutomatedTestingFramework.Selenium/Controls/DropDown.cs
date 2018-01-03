using AutomatedTestingFramework.Core.Controls;
using AutomatedTestingFramework.Selenium.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTestingFramework.Selenium.Controls
{
	public class DropDown : ContentElement, IDropDown
	{
		public DropDown(IWebDriver driver, IWebElement webElement, IElementFinderService elementFinderService) 
			: base(driver, webElement, elementFinderService)
		{}

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
	}
}