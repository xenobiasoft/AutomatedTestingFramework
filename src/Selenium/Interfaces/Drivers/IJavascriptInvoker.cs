namespace AutomatedTestingFramework.Selenium.Interfaces.Drivers
{
	public interface IJavascriptInvoker
	{
		TType InvokeScript<TType>(string script);
	}
}