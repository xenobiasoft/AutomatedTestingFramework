using System;

namespace AutomatedTestingFramework.Selenium.ExceptionAnalysis
{
	public class AnalyzedTestException : Exception
	{
		public AnalyzedTestException(string message, Exception ex)
			: base(FormatExceptionMessage(message), ex)
		{}

		private static string FormatExceptionMessage(string message)
		{
			var errorFormatBoundary = new string('#', 40);

			return $"{errorFormatBoundary}{Environment.NewLine}{message}{Environment.NewLine}{errorFormatBoundary}";
		}
	}
}