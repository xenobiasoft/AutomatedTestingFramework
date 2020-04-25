using System;
using AutomatedTestingFramework.Selenium.Enums;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;

namespace Bellatrix
{
	public class App : IDisposable
	{
		private readonly IDriver _driver;
		private bool _disposed;

		public App(IDriver driver, Browser browser = Browser.Chrome)
		{
			_driver = driver;
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
