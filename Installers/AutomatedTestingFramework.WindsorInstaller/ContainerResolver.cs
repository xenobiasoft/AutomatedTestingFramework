using AutomatedTestingFramework.Core;
using Castle.Windsor;

namespace AutomatedTestingFramework.WindsorInstaller
{
	public class ContainerResolver : IResolver
	{
		private readonly IWindsorContainer _windsorContainer;

		public ContainerResolver(IWindsorContainer container)
		{
			_windsorContainer = container;
		}

		public void Dispose()
		{
			_windsorContainer.Dispose();
		}

		public TType Resolve<TType>()
		{
			return _windsorContainer.Resolve<TType>();
		}
	}
}