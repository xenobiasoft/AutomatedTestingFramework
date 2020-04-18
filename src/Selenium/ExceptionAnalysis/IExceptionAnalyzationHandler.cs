using System;

namespace AutomatedTestingFramework.Selenium.ExceptionAnalysis
{
	public interface IExceptionAnalyzationHandler
	{
		bool IsApplicable(Exception ex = null, params object[] context);
		string DetailedIssueExplanation { get; }
	}
}