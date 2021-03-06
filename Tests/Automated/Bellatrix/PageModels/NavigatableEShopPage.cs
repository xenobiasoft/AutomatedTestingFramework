﻿using AutomatedTestingFramework.Selenium.Interfaces.Drivers;

namespace Bellatrix.PageModels
{
	public abstract class NavigatableEShopPage<TPage> : EShopPage<TPage> where TPage : NavigatableEShopPage<TPage>
	{
		protected readonly INavigationService NavigationService;

		protected NavigatableEShopPage(INavigationService navigationService) : base(navigationService as IElementFinder)
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
