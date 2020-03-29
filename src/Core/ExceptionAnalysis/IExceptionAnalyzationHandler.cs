using System;

namespace AutomatedTestingFramework.Core.ExceptionAnalysis
{
	public interface IExceptionAnalyzationHandler
	{
		bool IsApplicable(Exception ex = null, params object[] context);
		string DetailedIssueExplanation { get; }
	}
}