using System;
using System.ComponentModel;
using AutomatedTestingFramework.Core.Config;
using AutomatedTestingFramework.Core.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTestingFramework.Selenium.Driver
{
	public class BrowserDefaults : IBrowserDefaults
	{
		private readonly IBrowserSettingsConfiguration _BrowserSettingsConfiguration;

		public BrowserDefaults(IBrowserSettingsConfiguration browserSettingsConfiguration)
		{
			_BrowserSettingsConfiguration = browserSettingsConfiguration;
			InitializeDefaultDriver();
		}

		private void InitializeDefaultDriver()
		{
			switch (_BrowserSettingsConfiguration.DefaultBrowser)
			{
				case BrowserType.Chrome:
					DefaultBrowser = new ChromeDriver(_BrowserSettingsConfiguration.DriverLocation);
					break;

				case BrowserType.Edge:
					DefaultBrowser = new EdgeDriver(_BrowserSettingsConfiguration.DriverLocation);
					break;

				case BrowserType.Firefox:
					DefaultBrowser = new FirefoxDriver();
					break;

				case BrowserType.InternetExplorer:
					DefaultBrowser = new InternetExplorerDriver(_BrowserSettingsConfiguration.DriverLocation);
					break;

				case BrowserType.PhantomJs:
					DefaultBrowser = new PhantomJSDriver(_BrowserSettingsConfiguration.DriverLocation);
					break;

				case BrowserType.Safari:
					DefaultBrowser = new SafariDriver(_BrowserSettingsConfiguration.DriverLocation);
					break;

				default:
					throw new InvalidEnumArgumentException($"Browser type : {_BrowserSettingsConfiguration.DefaultBrowser} is invalid.");
			}

			SetDefaultImplicitWait();
		}

		private void SetDefaultImplicitWait()
		{
			DefaultBrowser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_BrowserSettingsConfiguration.ImplicitWaitTimeout);
		}

		public IWebDriver DefaultBrowser { get; private set; }

		public int ImplicitTimeoutValue => _BrowserSettingsConfiguration.ImplicitWaitTimeout;

		public int ScriptTimeoutValue => _BrowserSettingsConfiguration.ScriptTimeout;

		public int PageLoadTimeoutValue => _BrowserSettingsConfiguration.PageLoadTimeout;

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