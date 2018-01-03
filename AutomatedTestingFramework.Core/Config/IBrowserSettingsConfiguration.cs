﻿using AutomatedTestingFramework.Core.Enums;

namespace AutomatedTestingFramework.Core.Config
{
	public interface IBrowserSettingsConfiguration
	{
		BrowserType DefaultBrowser { get; }
		string DriverLocation { get; }
		int ImplicitWaitTimeout { get; }
		int PageLoadTimeout { get; }
		int ScriptTimeout { get; }
	}
}