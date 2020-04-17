using AutomatedTestingFramework.Core.Drivers;

namespace Bellatrix.PageModels.Main
{
	public class MainPage : NavigatableEShopPage
	{
		public MainPage(IDriver driver) : base(driver)
		{
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
			Driver.WaitForAjax();
			Elements.ViewCartButton.Click();
		}

		protected override void WaitForPageLoad()
		{
			Driver.WaitForElementToExist(Elements.AddToCartFalcon9Button.By);
		}
	}
}
