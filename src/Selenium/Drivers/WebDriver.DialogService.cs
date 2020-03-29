using System;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Core.Enums;

namespace AutomatedTestingFramework.Selenium.Drivers
{
	public partial class WebDriver : BaseDriver, IDialogService
	{
		public override void Handle(Action action = null, DialogButton dialogButton = DialogButton.Ok)
		{
		}

		public override void Upload(string filePath)
		{
		}
	}
}