using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomatedTestingFramework.Selenium.Driver
{
	public interface IBrowserDefaults
	{
		IWebDriver DefaultBrowser { get; }
		int ImplicitTimeoutValue { get; }
		int ScriptTimeoutValue { get; }
		int PageLoadTimeoutValue { get; }
		WebDriverWait ScriptWait { get; }
		WebDriverWait DocumentWait { get; }
	}
}