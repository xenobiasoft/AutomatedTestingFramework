using System;

namespace AutomatedTestingFramework.Core
{
	public class PageFactory : IPageFactory
	{
		private readonly IResolver _Container;

		public PageFactory(Func<IResolver> containerFactory)
		{
			_Container = containerFactory.Invoke();
		}

		public TPage GetPage<TPage>() where TPage : PartialPage
		{
			return _Container.Resolve<TPage>();
		}
	}
}