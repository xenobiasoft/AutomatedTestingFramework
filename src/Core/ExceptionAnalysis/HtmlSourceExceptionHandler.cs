﻿using System;
using System.Linq;
using AutomatedTestingFramework.Core.Drivers;

namespace AutomatedTestingFramework.Core.ExceptionAnalysis
{
	public abstract class HtmlSourceExceptionHandler : IExceptionAnalyzationHandler
	{
		public bool IsApplicable(Exception ex = null, params object[] context)
		{
			var browser = context.OfType<IBrowserService>().FirstOrDefault();

			return browser?.Source != null && browser.Source.Contains(TextToSearchInSource);
		}

		public abstract string TextToSearchInSource { get; }

		public abstract string DetailedIssueExplanation { get; }
	}
}