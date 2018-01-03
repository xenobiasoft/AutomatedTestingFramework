using AutomatedTestingFramework.Core.Driver;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.Driver
{
	public partial class SeleniumDriver : IJavascriptInvoker
	{
		public TType InvokeScript<TType>(string script)
		{
			var javascriptExecutor = _driver as IJavaScriptExecutor;

			var results = javascriptExecutor?.ExecuteScript(script);

			return (TType) results;
		}
	}
}