using Autofac;
using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Driver;
using AutomatedTestingFramework.Core.ExceptionAnalysis;
using AutomatedTestingFramework.Selenium.Driver;

namespace AutomatedTestingFramework.Selenium
{
	public class SeleniumInstaller : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ElementFinderService>().As<IElementFinderService>();
			builder.RegisterType<BrowserDefaults>().As<IBrowserDefaults>();
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