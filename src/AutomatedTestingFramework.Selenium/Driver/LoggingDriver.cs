using System;
using System.Collections.Generic;
using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Controls;
using AutomatedTestingFramework.Core.Driver;
using AutomatedTestingFramework.Core.Enums;
using AutomatedTestingFramework.Core.ExceptionAnalysis;

namespace AutomatedTestingFramework.Selenium.Driver
{
	public class LoggingDriver : DriverDecorator
	{
		public LoggingDriver(BaseDriver driver) : base(driver)
		{
		}

		public override void Start(Browser browser)
		{
			Console.WriteLine($"Start browser = {Enum.GetName(typeof(Browser), browser)}");
			Driver?.Start(browser);
		}

		public override void Quit()
		{
			Console.WriteLine("Browser Quit().");
			Driver?.Quit();
		}

		public override void AddCookie(string cookieName, string cookieValue, string host)
		{
			Console.WriteLine($"Add Cookie with name: {cookieName}, value: {cookieValue}, host: {host}");
			Driver?.AddCookie(cookieName, cookieValue, host);
		}

		public override void ClearAllCookies()
		{
			Console.WriteLine("Clear all cookies");
			Driver?.ClearAllCookies();
		}

		public override void ClickBackButton()
		{
			Console.WriteLine("Clicked back button");
			Driver?.ClickBackButton();
		}

		public override void ClickForwardButton()
		{
			Console.WriteLine("Clicked forward button");
			Driver?.ClickForwardButton();
		}

		public override void ClickRefresh()
		{
			Console.WriteLine("Clicked refresh button");
			Driver?.ClickRefresh();
		}

		public override void DeleteCookie(string cookieName)
		{
			Console.WriteLine($"Delete cookie: {cookieName}");
			Driver?.DeleteCookie(cookieName);
		}

		public override TElement Find<TElement>(By by)
		{
			Console.WriteLine($"Find element by: {by}");
			return Driver?.Find<TElement>(by);
		}

		public override IEnumerable<TElement> FindAll<TElement>(By by)
		{
			Console.WriteLine($"Find all elements by: {by}");
			return Driver?.FindAll<TElement>(by);
		}

		public override string GetCookie(string host, string cookieName)
		{
			Console.WriteLine($"Get cookie: {cookieName}, host: {host}");
			return Driver?.GetCookie(host, cookieName);
		}

		public override IFrame GetFrame(string frameName)
		{
			Console.WriteLine($"Get frame: {frameName}");
			return Driver?.GetFrame(frameName);
		}

		public override void Handle(Action action = null, DialogButton dialogButton = DialogButton.Ok)
		{
			Console.WriteLine($"Handle action: {action}, dialogButton: {dialogButton}");
			Driver?.Handle(action, dialogButton);
		}

		public override TType InvokeScript<TType>(string script)
		{
			Console.WriteLine($"Invoke script: {script}");
			return Driver.InvokeScript<TType>(script);
		}

		public override bool IsElementPresent(By by)
		{
			Console.WriteLine($"Is element present by: {by}");
			return Driver.IsElementPresent(by);
		}

		public override void MaximizeBrowserWindow()
		{
			Console.WriteLine("Maximizing browser window");
			Driver?.MaximizeBrowserWindow();
		}

		public override void GoToUrl(string url)
		{
			Console.WriteLine($"Go to URL: {url}");
			Driver?.GoToUrl(url);
		}

		public override void SwitchToDefault()
		{
			Console.WriteLine("Switching to default frame");
			Driver?.SwitchToDefault();
		}

		public override void SwitchToFrame(IFrame frame)
		{
			Console.WriteLine($"Switching to frame: {frame}");
			Driver?.SwitchToFrame(frame);
		}

		public override void TakeScreenShot()
		{
			Console.WriteLine("Taking screen shot");
			Driver?.TakeScreenShot();
		}

		public override void Upload(string filePath)
		{
			Console.WriteLine($"Uploading from file path: {filePath}");
			Driver?.Upload(filePath);
		}

		public override void WaitForAjax()
		{
			Console.WriteLine("Waiting for ajax");
			Driver?.WaitForAjax();
		}

		public override void WaitForPageToLoad()
		{
			Console.WriteLine("Waiting for page to load");
			Driver?.WaitForPageToLoad();
		}

		public override string Source
		{
			get
			{
				Console.WriteLine($"Returning page source");
				return Driver?.Source;
			}
		}

		public override string Title
		{
			get
			{
				Console.WriteLine("Returning page title");
				return Driver?.Title;
			}
		}

		public override string Url
		{
			get
			{
				Console.WriteLine("Returning page URL");
				return Driver?.Url;
			}
		}

		public override IExceptionAnalyzer ExceptionAnalyzer
		{
			get
			{
				Console.WriteLine("Returning exception analyzers");
				return Driver?.ExceptionAnalyzer;
			}
			set
			{
				Console.WriteLine("Setting exception analyzers");
				Driver.ExceptionAnalyzer = value;
			}
		}

		public override event EventHandler<PageEventArgs> Navigated
		{
			add => base.Navigated += value;
			remove => base.Navigated -= value;
		}
	}
}
