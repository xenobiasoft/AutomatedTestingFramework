using System;

namespace AutomatedTestingFramework.Selenium.Interfaces
{
	public interface IExceptionAnalyzationHandler
	{
		bool IsApplicable(Exception ex = null, params object[] context);
		string DetailedIssueExplanation { get; }
	}
}