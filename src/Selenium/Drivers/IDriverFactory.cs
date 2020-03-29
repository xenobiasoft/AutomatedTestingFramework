using AutomatedTestingFramework.Core.Enums;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.Drivers
{
	public interface IDriverFactory
	{
		IWebDriver CreateDriver(Browser browser);
	}
}