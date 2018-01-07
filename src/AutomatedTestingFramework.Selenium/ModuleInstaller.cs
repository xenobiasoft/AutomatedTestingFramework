using Autofac;
using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Driver;
using AutomatedTestingFramework.Core.ExceptionAnalysis;
using AutomatedTestingFramework.Selenium.Driver;

namespace AutomatedTestingFramework.Selenium
{
	public class ModuleInstaller : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
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