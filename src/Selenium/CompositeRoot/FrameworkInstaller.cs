using Autofac;
using AutomatedTestingFramework.Selenium.BehaviorObserver;
using AutomatedTestingFramework.Selenium.Configuration;
using AutomatedTestingFramework.Selenium.Drivers;
using AutomatedTestingFramework.Selenium.Elements;
using AutomatedTestingFramework.Selenium.ExceptionAnalysis;
using AutomatedTestingFramework.Selenium.Interfaces;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;

namespace AutomatedTestingFramework.Selenium.CompositeRoot
{
	public class FrameworkInstaller : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ConfigurationService>().SingleInstance();
			builder.Register(x => x.Resolve<ConfigurationService>().GetSettings<AppSettings>("appSettings"));

			builder.RegisterType<ServiceUnavailableExceptionHandler>().As<IExceptionAnalyzationHandler>();
			builder.RegisterType<FileNotFoundExceptionHandler>().As<IExceptionAnalyzationHandler>();
			builder.RegisterType<ExceptionAnalyzer>().As<IExceptionAnalyzer>();

			builder.RegisterType<ElementFinderService>().As<IElementFinderService>();
			builder.RegisterType<DriverFactory>().As<IDriverFactory>();

			builder.RegisterType<WebDriver>()
				.As<IDriver>()
				.As<IBrowserService>()
				.As<ICookieService>()
				.As<IDialogService>()
				.As<IElementFinder>()
				.As<IElementWaitService>()
				.As<IJavascriptInvoker>()
				.As<INavigationService>()
				.InstancePerLifetimeScope();

			builder.RegisterDecorator<LoggingDriver, IDriver>();

			builder.RegisterType<UnitTestExecutionSubject>().As<ITestExecutionSubject>();
			builder.RegisterType<BrowserLaunchTestBehaviorObserver>().As<ITestObserver>();
		}
	}
}
