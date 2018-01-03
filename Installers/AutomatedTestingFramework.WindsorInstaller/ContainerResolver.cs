using AutomatedTestingFramework.Core;
using Castle.Windsor;

namespace AutomatedTestingFramework.WindsorInstaller
{
	public class ContainerResolver : IResolver
	{
		private readonly IWindsorContainer _WindsorContainer;

		public ContainerResolver(IWindsorContainer container)
		{
			_WindsorContainer = container;
		}

		public void Dispose()
		{
			_WindsorContainer.Dispose();
		}

		public TType Resolve<TType>()
		{
			return _WindsorContainer.Resolve<TType>();
		}
	}
}