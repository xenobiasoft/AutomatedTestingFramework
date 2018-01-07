using Autofac;
using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Config;
using AutomatedTestingFramework.Core.Driver;
using AutomatedTestingFramework.Core.ExceptionAnalysis;
using AutomatedTestingFramework.Core.ExecutionEngine;
using AutomatedTestingFramework.Media.VideoRecorder;
using AutomatedTestingFramework.Selenium.Driver;

namespace AutomatedTestingFramework.AutofacInstaller
{
	public class TestFrameworkInstaller : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ExpressionEncoderVideoRecorder>().As<IVideoRecorder>();
			builder.RegisterType<ServiceUnavailableExceptionHandler>().As<IExceptionAnalyzationHandler>();
			builder.RegisterType<FileNotFoundExceptionHandler>().As<IExceptionAnalyzationHandler>();
			builder.RegisterType<ElementFinderService>().As<IElementFinderService>();
			builder.RegisterType<VideoRecorderObserver>().As<ITestObserver>();
			builder.RegisterType<TestExecutionProvider>().As<ITestExecutionProvider>();

			var browserSettingsConfig = BrowserSettingsConfigurationProvider.GetSettings();
			builder.RegisterInstance(browserSettingsConfig).As<IBrowserSettingsConfiguration>();
			builder.RegisterType<BrowserDefaults>().As<IBrowserDefaults>();
			builder.RegisterType<AppConfiguration>().As<IAppConfiguration>();

			builder.RegisterType<ExceptionAnalyzer>().As<IExceptionAnalyzer>();
			
			builder.Register(x => new SeleniumDriver(
				x.Resolve<IBrowserDefaults>(), 
				x.Resolve<IElementFinderService>()))
				.As<IDriver>()
				.As<IBrowser>()
				.As<ICookieService>()
				.As<IDialogService>()
				.As<IJavascriptInvoker>()
				.As<IElementFinder>()
				.As<INavigationService>()
				.OnActivated(x => x.Instance.ExceptionAnalyzer = x.Context.Resolve<IExceptionAnalyzer>())
				.SingleInstance();
		}
	}
}