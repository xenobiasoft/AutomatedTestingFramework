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
	}
}