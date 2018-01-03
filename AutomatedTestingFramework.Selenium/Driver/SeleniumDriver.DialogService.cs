using System;
using AutomatedTestingFramework.Core.Driver;
using AutomatedTestingFramework.Core.Enums;

namespace AutomatedTestingFramework.Selenium.Driver
{
	public partial class SeleniumDriver : IDialogService
	{
		public void Handle(Action action = null, DialogButton dialogButton = DialogButton.Ok)
		{
		}

		public void Upload(string filePath)
		{
		}
	}
}