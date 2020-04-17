using AutomatedTestingFramework.Core.Drivers;

namespace Bellatrix.PageModels
{
	public abstract class NavigatableEShopPage : EShopPage
	{
		protected readonly INavigationService NavigationService;

		protected NavigatableEShopPage(IElementFinder elementFinder, INavigationService navigationService) : base(elementFinder)
		{
			NavigationService = navigationService;
		}

		protected abstract string Url { get; }

		protected abstract void WaitForPageLoad();

		public void Open()
		{
			NavigationService.GoToUrl(Url);
			WaitForPageLoad();
		}
	}
}
