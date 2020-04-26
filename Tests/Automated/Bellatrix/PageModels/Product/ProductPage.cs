using AutomatedTestingFramework.Selenium.Interfaces.Drivers;

namespace Bellatrix.PageModels.Product
{
	public class ProductPage : EShopPage<ProductPage>
	{
		private readonly IElementWaitService _waitService;

		public ProductPage(IDriver driver) : base(driver)
		{
			_waitService = driver;
			Elements = new ProductPageElements(driver);
			Asserts = new ProductPageAssertions(Elements);
		}

		public ProductPageAssertions Asserts { get; }
		public ProductPageElements Elements { get; }

		public void AddRocketToShoppingCart()
		{
			Elements.AddToCartButton.Click();
			_waitService.WaitForElementToBeClickable(Elements.ViewCartLink.By);
			Elements.ViewCartLink.Click();
			_waitService.WaitForAjax();
			_waitService.WaitForPageToLoad();
		}
	}
}
