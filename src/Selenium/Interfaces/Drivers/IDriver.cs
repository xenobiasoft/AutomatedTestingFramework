namespace AutomatedTestingFramework.Selenium.Interfaces.Drivers
{
	public interface IDriver :
		IElementFinder,
		INavigationService,
		ICookieService,
		IDialogService,
		IJavascriptInvoker,
		IBrowserService,
		IElementWaitService
	{
		IExceptionAnalyzer ExceptionAnalyzer { get; set; }
	}
}