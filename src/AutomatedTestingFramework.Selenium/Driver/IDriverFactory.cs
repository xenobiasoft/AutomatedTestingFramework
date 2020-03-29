using AutomatedTestingFramework.Core.Enums;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.Driver
{
	public interface IDriverFactory
	{
		IWebDriver CreateDriver(Browser browser);
	}
}