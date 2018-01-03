using System;

namespace AutomatedTestingFramework.Core
{
	public class PageFactory : IPageFactory
	{
		private readonly IResolver _container;

		public PageFactory(Func<IResolver> containerFactory)
		{
			_container = containerFactory.Invoke();
		}

		public TPage GetPage<TPage>() where TPage : PartialPage
		{
			return _container.Resolve<TPage>();
		}
	}
}