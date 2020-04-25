using Autofac;

namespace AutomatedTestingFramework.Selenium.CompositeRoot
{
	public class CompositeRoot
	{
		static CompositeRoot()
		{
			var builder = new ContainerBuilder();

			builder.RegisterModule<FrameworkInstaller>();

			Root = builder.Build();
		}

		public static IContainer Root { get; }
	}
}
