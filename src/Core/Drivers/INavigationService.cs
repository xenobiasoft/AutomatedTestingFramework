using System;
using AutomatedTestingFramework.Core.ExceptionAnalysis;

namespace AutomatedTestingFramework.Core.Drivers
{
	public interface INavigationService
	{
		event EventHandler<PageEventArgs> Navigated;

		string Url { get; }
		string Title { get; }
		IExceptionAnalyzer ExceptionAnalyzer { get; set; }

		void GoToUrl(string url);
	}
}