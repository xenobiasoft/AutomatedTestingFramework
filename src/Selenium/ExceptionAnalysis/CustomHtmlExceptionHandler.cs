namespace AutomatedTestingFramework.Selenium.ExceptionAnalysis
{
	public class CustomHtmlExceptionHandler : HtmlSourceExceptionHandler
	{
		public CustomHtmlExceptionHandler(string textToSearchInSource, string detailedIssueExplanation)
		{
			TextToSearchInSource = textToSearchInSource;
			DetailedIssueExplanation = detailedIssueExplanation;
		}

		public CustomHtmlExceptionHandler()
		{}

		public override string DetailedIssueExplanation { get; }

		public override string TextToSearchInSource { get; }
	}
}