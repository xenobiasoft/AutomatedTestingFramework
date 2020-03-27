using AutomatedTestingFramework.Core.Controls;
using AutomatedTestingFramework.Core.Driver;
using AutomatedTestingFramework.Core.Enums;
using AutomatedTestingFramework.Media;
using AutomatedTestingFramework.Selenium.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace AutomatedTestingFramework.Selenium.Driver
{
	public partial class WebDriver : BaseDriver, IBrowser
	{
		public override string Source => _driver.PageSource;

		public override void ClickBackButton()
		{
			_driver.Navigate().Back();
		}

		public override void ClickForwardButton()
		{
			_driver.Navigate().Forward();
		}

		public override void ClickRefresh()
		{
			_driver.Navigate().Refresh();
		}

		public override IFrame GetFrame(string frameName)
		{
			return new Frame(frameName);
		}

		public override void MaximizeBrowserWindow()
		{
			_driver.Manage().Window.Maximize();
		}

		public override void Start(Browser browser)
		{

		}

		public override void Quit()
		{
			_driver.Quit();
		}

		public override void SwitchToFrame(IFrame frame)
		{
			_driver.SwitchTo().Frame(frame.Name);
		}

		public override void SwitchToDefault()
		{
			_driver.SwitchTo().DefaultContent();
		}

		public override void TakeScreenShot()
		{
			var screenshot = _driver.TakeScreenshot();
			var screenshotFilename = MediaFileUtil.GetDateFormattedFilenameWithPath("Screenshot", MediaFileType.Png);

			screenshot.SaveAsFile(screenshotFilename, ScreenshotImageFormat.Png);
		}

		public override void WaitForAjax()
		{
			var js = (IJavaScriptExecutor)_driver;

			_webDriverWait.Until(x => js.ExecuteScript("return jQuery.active").ToString() == "0");
		}

		public override void WaitForPageToLoad()
		{
			var js = (IJavaScriptExecutor)_driver;

			_webDriverWait.Until(x => js.ExecuteScript("return document.readyState").ToString() == "complete");
		}
	}
}