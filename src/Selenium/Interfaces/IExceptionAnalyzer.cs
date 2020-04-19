using System;

namespace AutomatedTestingFramework.Selenium.Interfaces
{
	public interface IExceptionAnalyzer
	{
		void Analyze(Exception ex = null, params object[] context);
		void AddExceptionAnalyzationHandler<THandler>(THandler exceptionAnalyzationHandler) where THandler : IExceptionAnalyzationHandler;
		void AddExceptionAnalyzationHandler(string textToSearchInSource, string detailedIssueExplanation);
	}
}