using System;
using System.Collections.Generic;

namespace AutomatedTestingFramework.Core.ExceptionAnalysis
{
	public class ExceptionAnalyzer : IExceptionAnalyzer
	{
		private readonly List<IExceptionAnalyzationHandler> _ExceptionAnalyzationHandlers;

		public ExceptionAnalyzer(IEnumerable<IExceptionAnalyzationHandler> exceptionAnalyzationHandlers)
		{
			_ExceptionAnalyzationHandlers = new List<IExceptionAnalyzationHandler>();

			foreach (var exceptionAnalyzationHandler in exceptionAnalyzationHandlers)
			{
				_ExceptionAnalyzationHandlers.Add(exceptionAnalyzationHandler);
			}
		}

		public ExceptionAnalyzer() : this(new List<IExceptionAnalyzationHandler>())
		{}

		public void Analyze(Exception ex = null, params object[] context)
		{
			foreach (var exceptionHandler in _ExceptionAnalyzationHandlers)
			{
				if (exceptionHandler.IsApplicable(ex, context))
				{
					throw new AnalyzedTestException(exceptionHandler.DetailedIssueExplanation, ex);
				}
			}
		}

		public void AddExceptionAnalyzationHandler<THandler>(THandler exceptionAnalyzationHandler) where THandler : IExceptionAnalyzationHandler
		{
			_ExceptionAnalyzationHandlers.Insert(0, exceptionAnalyzationHandler);
		}

		public void AddExceptionAnalyzationHandler(string textToSearchInSource, string detailedIssueExplanation)
		{
			AddExceptionAnalyzationHandler(new CustomHtmlExceptionHandler(textToSearchInSource, detailedIssueExplanation));
		}
	}
}