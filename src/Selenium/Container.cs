using Autofac;
using Autofac.Core;
using AutomatedTestingFramework.Selenium.CompositeRoot;
using AutomatedTestingFramework.Selenium.Interfaces.DI;

namespace AutomatedTestingFramework.Selenium
{
	public class Container : IModuleRegistrator, IContainerBuilder
	{
		private static IModuleRegistrator _instance;

		private readonly ContainerBuilder _builder;
		private IContainer _container;

		private Container()
		{
			_builder = new ContainerBuilder();

			_builder.RegisterModule<FrameworkInstaller>();
		}

		public static IModuleRegistrator Instance => _instance ??= new Container();

		public IModuleRegistrator InstallModule(IModule module)
		{
			_builder.RegisterModule(module);

			return this;
		}

		public IContainerBuilder Build()
		{
			_container = _builder.Build();

			return this;
		}

		public ILifetimeScope CreateScope()
		{
			return _container.BeginLifetimeScope();
		}

		public void Dispose()
		{
			_container?.Dispose();
			_instance = null;
		}
	}
}
