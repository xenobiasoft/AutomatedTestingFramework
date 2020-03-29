using System;
using AutomatedTestingFramework.Core.Enums;

namespace AutomatedTestingFramework.Core.Drivers
{
	public interface IDialogService
	{
		void Handle(Action action = null, DialogButton dialogButton = DialogButton.Ok);
		void Upload(string filePath);
	}
}