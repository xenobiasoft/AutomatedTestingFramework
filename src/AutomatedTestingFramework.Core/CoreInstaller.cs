using Autofac;
using AutomatedTestingFramework.Core.Config;
using AutomatedTestingFramework.Core.ExceptionAnalysis;

namespace AutomatedTestingFramework.Core
{
	public class CoreInstaller : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ServiceUnavailableExceptionHandler>().As<IExceptionAnalyzationHandler>();
			builder.RegisterType<FileNotFoundExceptionHandler>().As<IExceptionAnalyzationHandler>();
			builder.RegisterType<AppConfiguration>().As<IAppConfiguration>();
			builder.RegisterType<ExceptionAnalyzer>().As<IExceptionAnalyzer>();
		}
	}
}