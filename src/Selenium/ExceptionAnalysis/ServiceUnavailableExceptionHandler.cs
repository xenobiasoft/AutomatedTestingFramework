namespace AutomatedTestingFramework.Selenium.ExceptionAnalysis
{
	public class ServiceUnavailableExceptionHandler : HtmlSourceExceptionHandler
	{
		public override string DetailedIssueExplanation => "It is not a test problem. The service is unavailable.";
		public override string TextToSearchInSource => "HTTP Error 503. The service is unavailable.";
	}
}