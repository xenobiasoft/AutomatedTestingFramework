using Autofac;
using AutomatedTestingFramework.Core.Config;
using AutomatedTestingFramework.Core.ExceptionAnalysis;
using AutomatedTestingFramework.Core.ExecutionEngine;

namespace AutomatedTestingFramework.Core
{
	public class CoreInstaller : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			var browserSettingsConfig = BrowserSettingsConfigurationProvider.GetSettings();

			builder.RegisterType<ServiceUnavailableExceptionHandler>().As<IExceptionAnalyzationHandler>();
			builder.RegisterType<FileNotFoundExceptionHandler>().As<IExceptionAnalyzationHandler>();
			builder.RegisterType<TestExecutionProvider>().As<ITestExecutionProvider>();
			builder.RegisterInstance(browserSettingsConfig).As<IBrowserSettingsConfiguration>();
			builder.RegisterType<AppConfiguration>().As<IAppConfiguration>();
			builder.RegisterType<ExceptionAnalyzer>().As<IExceptionAnalyzer>();
		}
	}
}