using Autofac;
using AutomatedTestingFramework.Selenium.CompositeRoot;

namespace Bellatrix
{
	public class Container
	{
		static Container()
		{
			var builder = new ContainerBuilder();

			builder.RegisterModule<FrameworkInstaller>();
			builder.RegisterModule<TestInstaller>();

			Root = builder.Build();
		}

		public static IContainer Root { get; }
	}
}
