using Autofac;
using AutomatedTestingFramework.Core;

namespace AutomatedTestingFramework.AutofacInstaller
{
	public class ContainerResolver : IResolver
	{
		private readonly IContainer _container;

		public ContainerResolver(IContainer container)
		{
			_container = container;
		}

		public void Dispose()
		{
			_container.Dispose();
		}

		public TType Resolve<TType>()
		{
			return _container.Resolve<TType>();
		}
	}
}