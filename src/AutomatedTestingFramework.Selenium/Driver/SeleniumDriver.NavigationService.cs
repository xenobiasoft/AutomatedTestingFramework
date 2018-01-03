using System;
using System.Web;
using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Driver;
using AutomatedTestingFramework.Core.ExceptionAnalysis;

namespace AutomatedTestingFramework.Selenium.Driver
{
	public partial class SeleniumDriver : INavigationService
	{
		public event EventHandler<PageEventArgs> Navigated;

		public void Navigate(string url, bool useDecodedUrl = true)
		{
			try
			{
				var urlToNavigateTo = url.StartsWith("http") ? url : GetAbsoluteUrlFromRelativeUrl(url);

				if (useDecodedUrl)
				{
					urlToNavigateTo = HttpUtility.UrlDecode(urlToNavigateTo);
				}

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

		public void WaitForUrl(string url)
		{
			WaitUntil(_browserDefaults.DocumentWait, x => string.Compare(x.Url, url, StringComparison.InvariantCultureIgnoreCase) == 0);
		}

		private void RaiseNavigated(string url)
		{
			Navigated?.Invoke(this, new PageEventArgs(url));
		}

		public void WaitForPartialUrl(string partialUrl)
		{
			var absoluteUrl = GetAbsoluteUrlFromRelativeUrl(partialUrl);

			WaitForUrl(absoluteUrl);
		}

		public void WaitToLeaveUrl(string absoluteUrl)
		{
			WaitUntil(_browserDefaults.DocumentWait, x => string.Compare(x.Url, absoluteUrl, StringComparison.InvariantCultureIgnoreCase) != 0);
		}

		public void WaitToLeavePartialUrl(string partialUrl)
		{
			var absoluteUrl = GetAbsoluteUrlFromRelativeUrl(partialUrl);

			WaitToLeaveUrl(absoluteUrl);
		}

		public string Url => _driver.Url;
		public string Title => _driver.Title;
		public IExceptionAnalyzer ExceptionAnalyzer { get; set; }
	}
}