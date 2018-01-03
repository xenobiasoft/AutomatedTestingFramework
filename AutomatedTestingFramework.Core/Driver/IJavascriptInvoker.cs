namespace AutomatedTestingFramework.Core.Driver
{
	public interface IJavascriptInvoker
	{
		TType InvokeScript<TType>(string script);
	}
}