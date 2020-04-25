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
			builder.Register(x => x.Resolve<ConfigurationService>().GetSettings<AppSettings>("appSettings"))
				.As<AppSettings>()
				.SingleInstance();

			builder.RegisterAssemblyTypes(ThisAssembly)
				.Named<IExceptionAnalyzationHandler>("exceptionHandlers")
				.SingleInstance();
			builder.RegisterType<ExceptionAnalyzer>().As<IExceptionAnalyzer>().SingleInstance();

			builder.RegisterType<ElementFinderService>().As<IElementFinderService>().SingleInstance();
			builder.RegisterType<DriverFactory>().As<IDriverFactory>().SingleInstance();

			builder.RegisterType<WebDriver>()
				.As<IDriver>()
				.As<IBrowserService>()
				.As<ICookieService>()
				.As<IDialogService>()
				.As<IElementFinder>()
				.As<IElementWaitService>()
				.As<IJavascriptInvoker>()
				.As<INavigationService>()
				.As<Driver>()
				.SingleInstance();

			builder.RegisterDecorator<LoggingDriver, IDriver>();

			builder.RegisterType<UnitTestExecutionSubject>().As<ITestExecutionSubject>().SingleInstance();
			builder.RegisterType<BrowserLaunchTestBehaviorObserver>().As<ITestObserver>().SingleInstance();
		}
	}
}