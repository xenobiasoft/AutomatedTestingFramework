using System;
using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Driver;
using AutomatedTestingFramework.Core.ExceptionAnalysis;

namespace AutomatedTestingFramework.Selenium.Driver
{
	public partial class WebDriver : BaseDriver, INavigationService
	{
		public override event EventHandler<PageEventArgs> Navigated;

		public override void GoToUrl(string url)
		{
			try
			{
				var urlToNavigateTo = url.StartsWith("http") ? url : GetAbsoluteUrlFromRelativeUrl(url);

				_driver.Navigate().GoToUrl(urlToNavigateTo);
			}
			catch (Exception ex)
			{
				ExceptionAnalyzer.Analyze(ex, this);
				throw;
			}
		}

		private string GetAbsoluteUrlFromRelativeUrl(string relativeUrl)
		{
			return _appConfiguration.BaseUrl + relativeUrl;
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