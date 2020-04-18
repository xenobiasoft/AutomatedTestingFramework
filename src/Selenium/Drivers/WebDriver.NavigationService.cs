using System;
using AutomatedTestingFramework.Selenium.ExceptionAnalysis;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;

namespace AutomatedTestingFramework.Selenium.Drivers
{
	public partial class WebDriver : Driver, INavigationService
	{
		public override event EventHandler<PageEventArgs> Navigated;

		public override void GoToUrl(string url)
		{
			try
			{
				_driver.Navigate().GoToUrl(url);
			}
			catch (Exception ex)
			{
				ExceptionAnalyzer.Analyze(ex, this);
				throw;
			}
		}

		private void RaiseNavigated(string url)
		{
			Navigated?.Invoke(this, new PageEventArgs(url));
		}

		public override string Url => _driver.Url;
		public override string Title => _driver.Title;
		public override IExceptionAnalyzer ExceptionAnalyzer { get; set; }
	}
}