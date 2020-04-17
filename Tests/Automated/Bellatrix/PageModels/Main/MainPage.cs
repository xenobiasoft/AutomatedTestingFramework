using AutomatedTestingFramework.Core.Drivers;

namespace Bellatrix.PageModels.Main
{
	public class MainPage : NavigatableEShopPage
	{
		private readonly IBrowser _browser;

		public MainPage(IElementFinder elementFinder, INavigationService navigationService, IBrowser browser) : base(elementFinder, navigationService)
		{
			_browser = browser;
			Elements = new MainPageElements(elementFinder);
			Asserts = new MainPageAssertions(Elements);
		}

		protected override string Url => "http://demos.bellatrix.solutions/";
		public MainPageElements Elements { get; }
		public MainPageAssertions Asserts { get; }

		public void AddRocketToShoppingCart(string rocketName)
		{
			Open();
			Elements.GetAddToCartByName(rocketName).Click();
			_browser.WaitForAjax();
			Elements.ViewCartButton.Click();
		}

		protected override void WaitForPageLoad()
		{
			ElementFinder.WaitForElementToExist(Elements.AddToCartFalcon9Button.By);
		}
	}
}
