using System;
using System.Collections.Generic;
using AutomatedTestingFramework.Selenium.Interfaces;

namespace AutomatedTestingFramework.Selenium.ExceptionAnalysis
{
	public class ExceptionAnalyzer : IExceptionAnalyzer
	{
		private readonly List<IExceptionAnalyzationHandler> _exceptionHandlers;

		public ExceptionAnalyzer(IEnumerable<IExceptionAnalyzationHandler> exceptionHandlers)
		{
			_exceptionHandlers = new List<IExceptionAnalyzationHandler>();

			foreach (var exceptionHandler in exceptionHandlers)
			{
				_exceptionHandlers.Add(exceptionHandler);
			}
		}

		public ExceptionAnalyzer() : this(new List<IExceptionAnalyzationHandler>())
		{ }

		public void Analyze(Exception ex = null, params object[] context)
		{
			foreach (var exceptionHandler in _exceptionHandlers)
			{
				if (exceptionHandler.IsApplicable(ex, context))
				{
					throw new AnalyzedTestException(exceptionHandler.DetailedIssueExplanation, ex);
				}
			}
		}

		public void AddExceptionAnalyzationHandler<THandler>(THandler exceptionAnalyzationHandler) where THandler : IExceptionAnalyzationHandler
		{
			_exceptionHandlers.Insert(0, exceptionAnalyzationHandler);
		}

		public void AddExceptionAnalyzationHandler(string textToSearchInSource, string detailedIssueExplanation)
		{
			AddExceptionAnalyzationHandler(new CustomHtmlExceptionHandler(textToSearchInSource, detailedIssueExplanation));
		}
	}
}