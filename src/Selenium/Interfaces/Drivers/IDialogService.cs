using System;
using AutomatedTestingFramework.Selenium.Enums;

namespace AutomatedTestingFramework.Selenium.Interfaces.Drivers
{
	public interface IDialogService
	{
		void Handle(Action action = null, DialogButton dialogButton = DialogButton.Ok);
		void Upload(string filePath);
	}
}