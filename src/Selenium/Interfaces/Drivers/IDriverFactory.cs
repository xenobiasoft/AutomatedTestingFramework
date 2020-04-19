using AutomatedTestingFramework.Selenium.Enums;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.Interfaces.Drivers
{
	public interface IDriverFactory
	{
		IWebDriver CreateDriver(Browser browser);
	}
}