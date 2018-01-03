using System;
using AutomatedTestingFramework.Core.Controls;
using AutomatedTestingFramework.Core.Driver;
using AutomatedTestingFramework.Media;
using AutomatedTestingFramework.Selenium.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTestingFramework.Selenium.Driver
{
	public partial class SeleniumDriver : IBrowser
	{
		public string Source => _driver.PageSource;

		public void ClickBackButton()
		{
			_driver.Navigate().Back();
		}

		public void ClickForwardButton()
		{
			_driver.Navigate().Forward();
		}

		public void ClickRefresh()
		{
			_driver.Navigate().Refresh();
		}

		public IFrame GetFrame(string frameName)
		{
			return new Frame(frameName);
		}

		public void MaximizeBrowserWindow()
		{
			_driver.Manage().Window.Maximize();
		}

		public void Quit()
		{
			_driver.Quit();
		}

		public void SwitchToFrame(IFrame frame)
		{
			_driver.SwitchTo().Frame(frame.Name);
		}

		public void SwitchToDefault()
		{
			_driver.SwitchTo().DefaultContent();
		}

		public void TakeScreenshot()
		{
			var screenshot = _driver.TakeScreenshot();
			var screenshotFilename = MediaFileUtil.GetDateFormattedFilenameWithPath("Screenshot", MediaFileType.Png);

			screenshot.SaveAsFile(screenshotFilename, ScreenshotImageFormat.Png);
		}

		public void WaitForAjax()
		{
			WaitUntil(_browserDefaults.ScriptWait, x => InvokeScript<bool>("return (jQuery.ajax.active || jQuery.active || 0) === 0"));
		}

		public void WaitForElement(IElement element)
		{
			WaitUntil(_browserDefaults.DocumentWait, x => element.IsVisible);
		}

		public void WaitUntilReady()
		{
			WaitUntil(_browserDefaults.ScriptWait, x => InvokeScript<bool>("return (document.readyState === 'complete')"));
		}

		protected void WaitUntil(WebDriverWait wait, Func<IWebDriver, bool> condition)
		{
			try
			{
				TurnOffImplicitWait();
				wait.Until(condition);
			}
			catch (Exception ex)
			{
				ExceptionAnalyzer.Analyze(ex, this);
				throw;
			}
			finally
			{
				TurnOnImplicitWait();
			}
		}
	}
}