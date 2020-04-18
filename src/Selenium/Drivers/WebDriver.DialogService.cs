using System;
using AutomatedTestingFramework.Selenium.Enums;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;

namespace AutomatedTestingFramework.Selenium.Drivers
{
	public partial class WebDriver : Driver, IDialogService
	{
		public override void Handle(Action action = null, DialogButton dialogButton = DialogButton.Ok)
		{
		}

		public override void Upload(string filePath)
		{
		}
	}
}