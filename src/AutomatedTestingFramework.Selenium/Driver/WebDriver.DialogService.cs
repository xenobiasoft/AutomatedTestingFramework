using System;
using AutomatedTestingFramework.Core.Driver;
using AutomatedTestingFramework.Core.Enums;

namespace AutomatedTestingFramework.Selenium.Driver
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