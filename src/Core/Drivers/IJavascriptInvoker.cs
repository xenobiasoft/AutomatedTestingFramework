namespace AutomatedTestingFramework.Core.Drivers
{
	public interface IJavascriptInvoker
	{
		TType InvokeScript<TType>(string script);
	}
}