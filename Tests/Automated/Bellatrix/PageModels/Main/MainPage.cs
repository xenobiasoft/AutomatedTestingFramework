using AutomatedTestingFramework.Selenium.Drivers;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;

namespace Bellatrix.PageModels.Main
{
	public class MainPage : NavigatableEShopPage<MainPage>
	{
		private readonly IElementWaitService _waitService;

		public MainPage()
		{
			var driver = LoggingDriver.Instance;
			_waitService = driver;
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
			_waitService.WaitForAjax();
			Elements.ViewCartButton.Click();
		}

		protected override void WaitForPageLoad()
		{
			_waitService.WaitForElementToExist(Elements.AddToCartFalcon9Button.By);
		}
	}
}
