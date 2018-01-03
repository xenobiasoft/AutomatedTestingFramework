using System;

namespace AutomatedTestingFramework.Core.ExceptionAnalysis
{
	public interface IExceptionAnalyzer
	{
		void Analyze(Exception ex = null, params object[] context);
		void AddExceptionAnalyzationHandler<THandler>(THandler exceptionAnalyzationHandler) where THandler : IExceptionAnalyzationHandler;
		void AddExceptionAnalyzationHandler(string textToSearchInSource, string detailedIssueExplanation);
	}
}