using System;
using AutomatedTestingFramework.Core.ExceptionAnalysis;

namespace AutomatedTestingFramework.Core.Driver
{
	public interface INavigationService
	{
		event EventHandler<PageEventArgs> Navigated;

		string Url { get; }
		string Title { get; }
		IExceptionAnalyzer ExceptionAnalyzer { get; set; }

		void Navigate(string url, bool useDecodedUrl = true);
		void WaitForUrl(string url);
		void WaitForPartialUrl(string partialUrl);
		void WaitToLeaveUrl(string absoluteUrl);
		void WaitToLeavePartialUrl(string partialUrl);
	}
}