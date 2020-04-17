using AutomatedTestingFramework.Core.Drivers;

namespace Bellatrix.PageModels.Main
{
	public class MainPage : NavigatableEShopPage
	{
		public MainPage(IDriver driver) : base(driver)
		{
			Elements = new MainPageElements(driver);
			Asserts = new MainPageAsserts(Elements);
		}

		protected override string Url => "http://demos.bellatrix.solutions/";
		public MainPageElements Elements { get; }
		public MainPageAsserts Asserts { get; }

		public void AddRocketToShoppingCart()
		{
			Open();

			Elements.AddToCartFalcon9Button.Click();
			Elements.ViewCartButton.Click();
		}

		protected override void WaitForPageLoad()
		{
			Driver.WaitForElementToExist(Elements.AddToCartFalcon9Button.By);
		}
	}
}
