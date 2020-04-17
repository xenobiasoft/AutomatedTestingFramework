using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Core.Elements;
using AutomatedTestingFramework.Core.Enums;
using AutomatedTestingFramework.Selenium.Elements;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using By = AutomatedTestingFramework.Core.By;

namespace AutomatedTestingFramework.Selenium.Drivers
{
	public partial class WebDriver : Driver, IBrowser
	{
		public override string Source => _driver?.PageSource;

		public override void ClickBackButton()
		{
			_driver?.Navigate().Back();
		}

		public override void ClickForwardButton()
		{
			_driver?.Navigate().Forward();
		}

		public override void ClickRefresh()
		{
			_driver?.Navigate().Refresh();
		}

		public override IFrame GetFrame(string frameName)
		{
			return new Frame(frameName);
		}

		public override void MaximizeBrowserWindow()
		{
			_driver?.Manage().Window.Maximize();
		}

		public override void Start(Browser browser)
		{
			_driver = _driverFactory.CreateDriver(browser);
		}

		public override void Quit()
		{
			_driver?.Quit();
		}

		public override void SwitchToFrame(IFrame frame)
		{
			_driver?.SwitchTo().Frame(frame.Name);
		}

		public override void SwitchToDefault()
		{
			_driver?.SwitchTo().DefaultContent();
		}

		public override void WaitForAjax()
		{
			var js = (IJavaScriptExecutor)_driver;

			Wait.Until(x => js.ExecuteScript("return jQuery.active").ToString() == "0");
		}

		public override void WaitForPageToLoad()
		{
			var js = (IJavaScriptExecutor)_driver;

			Wait.Until(x => js.ExecuteScript("return document.readyState").ToString() == "complete");
		}

		public override void WaitForElementToBeClickable(By by)
		{
			Wait.Until(ExpectedConditions.ElementToBeClickable(by.ToSeleniumBy()));
		}

		public override void WaitForElementToExist(By by)
		{
			Wait.Until(ExpectedConditions.ElementExists(by.ToSeleniumBy()));
		}
	}
}