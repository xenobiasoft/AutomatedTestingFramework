using AutomatedTestingFramework.Selenium.Drivers;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;

namespace Bellatrix.PageModels
{
	public abstract class NavigatableEShopPage<TPage> : EShopPage<TPage> where TPage : NavigatableEShopPage<TPage>, new()
	{
		protected readonly INavigationService NavigationService;

		protected NavigatableEShopPage()
		{
			NavigationService = LoggingDriver.Instance;
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
