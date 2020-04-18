using System;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Core.Enums;
using AutomatedTestingFramework.Selenium.Drivers;

namespace Bellatrix
{
	public class App : IDisposable
	{
		private readonly IDriver _driver;
		private bool _disposed = false;

		public App(Browser browser = Browser.Chrome)
		{
			_driver = LoggingDriver.Instance;
			_driver.Start(browser);
			BrowserService = _driver;
			CookieService = _driver;
			DialogService = _driver;
		}

		public IBrowserService BrowserService { get; }
		public ICookieService CookieService { get; }
		public IDialogService DialogService { get; }

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public virtual void Dispose(bool disposing)
		{
			if (_disposed)
			{
				return;
			}

			if (disposing)
			{
				_driver.Quit();
			}

			_disposed = true;
		}
	}
}
