﻿using System;
using System.Collections.Generic;
using AutomatedTestingFramework.Selenium.Interfaces;

namespace AutomatedTestingFramework.Selenium.ExceptionAnalysis
{
	public class ExceptionAnalyzer : IExceptionAnalyzer
	{
		private readonly List<IExceptionAnalyzationHandler> _exceptionAnalyzationHandlers;

		public ExceptionAnalyzer(IEnumerable<IExceptionAnalyzationHandler> exceptionAnalyzationHandlers)
		{
			_exceptionAnalyzationHandlers = new List<IExceptionAnalyzationHandler>();

			foreach (var exceptionAnalyzationHandler in exceptionAnalyzationHandlers)
			{
				_exceptionAnalyzationHandlers.Add(exceptionAnalyzationHandler);
			}
		}

		public ExceptionAnalyzer() : this(new List<IExceptionAnalyzationHandler>())
		{}

		public void Analyze(Exception ex = null, params object[] context)
		{
			foreach (var exceptionHandler in _exceptionAnalyzationHandlers)
			{
				if (exceptionHandler.IsApplicable(ex, context))
				{
					throw new AnalyzedTestException(exceptionHandler.DetailedIssueExplanation, ex);
				}
			}
		}

		public void AddExceptionAnalyzationHandler<THandler>(THandler exceptionAnalyzationHandler) where THandler : IExceptionAnalyzationHandler
		{
			_exceptionAnalyzationHandlers.Insert(0, exceptionAnalyzationHandler);
		}

		public void AddExceptionAnalyzationHandler(string textToSearchInSource, string detailedIssueExplanation)
		{
			AddExceptionAnalyzationHandler(new CustomHtmlExceptionHandler(textToSearchInSource, detailedIssueExplanation));
		}
	}
}