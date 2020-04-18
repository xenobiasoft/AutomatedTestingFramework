using AutomatedTestingFramework.Selenium.Interfaces.Drivers;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.Drivers
{
	public partial class WebDriver : Driver, IJavascriptInvoker
	{
		public override TType InvokeScript<TType>(string script)
		{
			var javascriptExecutor = _driver as IJavaScriptExecutor;

			var results = javascriptExecutor?.ExecuteScript(script);

			return (TType)results;
		}
	}
}