﻿using AutomatedTestingFramework.Core.Enums;

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
		void Start(Browser browser);
	}
}