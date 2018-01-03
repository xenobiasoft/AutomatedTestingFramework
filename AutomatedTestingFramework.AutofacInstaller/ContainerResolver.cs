using Autofac;
using AutomatedTestingFramework.Core;

namespace AutomatedTestingFramework.AutofacInstaller
{
	public class ContainerResolver : IResolver
	{
		private readonly IContainer _Container;

		public ContainerResolver(IContainer container)
		{
			_Container = container;
		}

		public void Dispose()
		{
			_Container.Dispose();
		}

		public TType Resolve<TType>()
		{
			return _Container.Resolve<TType>();
		}
	}
}