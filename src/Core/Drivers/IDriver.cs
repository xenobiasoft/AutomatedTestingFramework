namespace AutomatedTestingFramework.Core.Drivers
{
	public interface IDriver :
		IElementFinder,
		INavigationService,
		ICookieService,
		IDialogService,
		IJavascriptInvoker,
		IBrowser
	{
	}
}