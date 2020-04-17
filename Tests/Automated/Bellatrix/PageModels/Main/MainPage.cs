using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Selenium.Drivers;

namespace Bellatrix.PageModels.Main
{
	public class MainPage : NavigatableEShopPage<MainPage>
	{
		private readonly IBrowser _browser;

		public MainPage()
		{
			var driver = LoggingDriver.Instance;
			_browser = driver;
			Elements = new MainPageElements(driver);
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
