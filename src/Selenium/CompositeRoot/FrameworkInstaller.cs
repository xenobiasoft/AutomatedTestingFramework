using Autofac;
using AutomatedTestingFramework.Selenium.BehaviorObserver;
using AutomatedTestingFramework.Selenium.Configuration;
using AutomatedTestingFramework.Selenium.Drivers;
using AutomatedTestingFramework.Selenium.Elements;
using AutomatedTestingFramework.Selenium.ExceptionAnalysis;
using AutomatedTestingFramework.Selenium.Interfaces;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;
using AutomatedTestingFramework.Selenium.Media;

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
				.Except<CustomHtmlExceptionHandler>()
				.As<IExceptionAnalyzationHandler>()
				.SingleInstance();
			builder.RegisterType<ExceptionAnalyzer>().As<IExceptionAnalyzer>().SingleInstance();

			builder.RegisterType<ElementFinderService>().As<IElementFinderService>().SingleInstance();
			builder.RegisterType<DriverFactory>().As<IDriverFactory>().SingleInstance();

			builder.RegisterType<WebDriver>()
				.OnActivated(e => e.Instance.ExceptionAnalyzer = e.Context.Resolve<IExceptionAnalyzer>())
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

			builder.RegisterType<VideoRecordingProvider>().As<IVideoRecordingProvider>();
			builder.RegisterType<MpegVideoRecorder>().As<IVideoRecorder>();

			builder.RegisterType<UnitTestExecutionSubject>().As<ITestExecutionSubject>().SingleInstance();
			builder.RegisterType<BrowserLaunchTestBehaviorObserver>().As<ITestObserver>().InstancePerDependency();
			builder.RegisterType<VideoRecordingTestFlowObserver>().As<ITestObserver>().InstancePerDependency();
		}
	}
}