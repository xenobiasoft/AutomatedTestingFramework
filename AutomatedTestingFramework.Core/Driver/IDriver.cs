using System;

namespace AutomatedTestingFramework.Core.Driver
{
	public interface IDriver : 
		IElementFinder, 
		INavigationService, 
		ICookieService, 
		IDialogService, 
		IJavascriptInvoker, 
		IBrowser,
		IDisposable
	{
	}
}