using System;
using AutomatedTestingFramework.Selenium.ExceptionAnalysis;

namespace AutomatedTestingFramework.Selenium.Interfaces.Drivers
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