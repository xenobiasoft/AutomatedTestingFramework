namespace AutomatedTestingFramework.Selenium.ExceptionAnalysis
{
	public class FileNotFoundExceptionHandler : HtmlSourceExceptionHandler
	{
		public override string DetailedIssueExplanation => "It is not a test problem. The page does not exist.";
		public override string TextToSearchInSource => "404 - File or directory not found.";
	}
}