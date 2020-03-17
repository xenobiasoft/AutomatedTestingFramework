using AutomatedTestingFramework.Core.Config;
using AutomatedTestingFramework.Core.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using System;
using System.ComponentModel;

namespace AutomatedTestingFramework.Selenium.Driver
{
	public class BrowserDefaults : IBrowserDefaults
	{
		private readonly IBrowserSettingsConfiguration _browserSettingsConfiguration;

		public BrowserDefaults(IBrowserSettingsConfiguration browserSettingsConfiguration)
		{
			_browserSettingsConfiguration = browserSettingsConfiguration;
			InitializeDefaultDriver();
		}

		private void InitializeDefaultDriver()
		{
			switch (_browserSettingsConfiguration.DefaultBrowser)
			{
				case BrowserType.Chrome:
					DefaultBrowser = new ChromeDriver(_browserSettingsConfiguration.DriverLocation);
					break;

				case BrowserType.Edge:
					DefaultBrowser = new EdgeDriver(_browserSettingsConfiguration.DriverLocation);
					break;

				case BrowserType.Firefox:
					DefaultBrowser = new FirefoxDriver();
					break;

				case BrowserType.HeadlessFirefox:
					break;

				case BrowserType.InternetExplorer:
					DefaultBrowser = new InternetExplorerDriver(_browserSettingsConfiguration.DriverLocation);
					break;

				case BrowserType.Safari:
					DefaultBrowser = new SafariDriver(_browserSettingsConfiguration.DriverLocation);
					break;

				default:
					throw new InvalidEnumArgumentException($"Browser type : {_browserSettingsConfiguration.DefaultBrowser} is invalid.");
			}

			SetDefaultImplicitWait();
		}

		private void SetDefaultImplicitWait()
		{
			DefaultBrowser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_browserSettingsConfiguration.ImplicitWaitTimeout);
		}

		public IWebDriver DefaultBrowser { get; private set; }

		public int ImplicitTimeoutValue => _browserSettingsConfiguration.ImplicitWaitTimeout;

		public int ScriptTimeoutValue => _browserSettingsConfiguration.ScriptTimeout;

		public int PageLoadTimeoutValue => _browserSettingsConfiguration.PageLoadTimeout;

		public WebDriverWait ScriptWait
			=> new WebDriverWait(DefaultBrowser, TimeSpan.FromSeconds(ScriptTimeoutValue))
			{
				PollingInterval = TimeSpan.FromMilliseconds(800)
			};

		public WebDriverWait DocumentWait
			=> new WebDriverWait(DefaultBrowser, TimeSpan.FromSeconds(PageLoadTimeoutValue))
			{
				PollingInterval = TimeSpan.FromMilliseconds(800)
			};
	}
}