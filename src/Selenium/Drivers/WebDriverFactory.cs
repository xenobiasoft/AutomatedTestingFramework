using System.Collections.Generic;
using AutomatedTestingFramework.Selenium.Elements;
using AutomatedTestingFramework.Selenium.ExceptionAnalysis;
using AutomatedTestingFramework.Selenium.Interfaces;

namespace AutomatedTestingFramework.Selenium.Drivers
{
	public class WebDriverFactory
	{
		private static LoggingDriver _instance;

		public static LoggingDriver Instance =>
			_instance ??= new LoggingDriver(new WebDriver(new ElementFinderService(), new DriverFactory()))
			{
				ExceptionAnalyzer = new ExceptionAnalyzer(new List<IExceptionAnalyzationHandler>
				{
					new ServiceUnavailableExceptionHandler(),
					new FileNotFoundExceptionHandler()
				})
			};
	}
}
