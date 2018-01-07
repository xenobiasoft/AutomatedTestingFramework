using System.Collections.Generic;
using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Config;
using AutomatedTestingFramework.Core.Driver;
using AutomatedTestingFramework.Core.ExceptionAnalysis;
using AutomatedTestingFramework.Core.ExecutionEngine;
using AutomatedTestingFramework.Media.VideoRecorder;
using AutomatedTestingFramework.Selenium.Driver;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace AutomatedTestingFramework.WindsorInstaller
{
	public class TestFrameworkInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
			container.Register(Component.For<IVideoRecorder>().ImplementedBy<ExpressionEncoderVideoRecorder>());
			container.Register(Component.For<IExceptionAnalyzationHandler>().ImplementedBy<FileNotFoundExceptionHandler > ());
			container.Register(Component.For<IElementFinderService>().ImplementedBy<ElementFinderService>());
			container.Register(Component.For<ITestObserver>().ImplementedBy<VideoRecorderObserver>());
			container.Register(Component.For<IEnumerable<ITestObserver>>().UsingFactoryMethod(() => container.ResolveAll<ITestObserver>()));
			container.Register(Component.For<ITestExecutionProvider>().ImplementedBy<TestExecutionProvider>());

			var browserSettingsConfig = BrowserSettingsConfigurationProvider.GetSettings();
			container.Register(Component.For<IBrowserSettingsConfiguration>().Instance(browserSettingsConfig));
			container.Register(Component.For<IBrowserDefaults>().ImplementedBy<BrowserDefaults>());
			container.Register(Component.For<IAppConfiguration>().ImplementedBy<AppConfiguration>());

			container.Register(Component.For<IExceptionAnalyzer>().ImplementedBy<ExceptionAnalyzer>());

			SeleniumDriver WebDriverFactoryMethod() => new SeleniumDriver(container.Resolve<IBrowserDefaults>(), container.Resolve<IElementFinderService>());
			container.Register(Component.For<IDriver>()
				.Forward<IBrowser>()
				.Forward<ICookieService>()
				.Forward<IDialogService>()
				.Forward<IJavascriptInvoker>()
				.Forward<IElementFinder>()
				.Forward<INavigationService>()
				.UsingFactoryMethod(WebDriverFactoryMethod)
				.OnCreate((kernel, instance) => instance.ExceptionAnalyzer = kernel.Resolve<IExceptionAnalyzer>())
				.LifestyleSingleton());
		}
	}
}