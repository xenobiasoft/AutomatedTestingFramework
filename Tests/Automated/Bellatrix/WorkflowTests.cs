using Bellatrix.Facades;
using Bellatrix.Models;
using Bellatrix.PageModels;
using Bellatrix.PageModels.Checkout;
using Bellatrix.PageModels.Main;
using NUnit.Framework;

namespace Bellatrix
{
	[TestFixture]
	public class WorkflowTests : BaseTest
	{
		private static MainPage _mainPage;
		private static CartPage _cartPage;
		private static CheckoutPage _checkoutPage;
		private static NewPurchaseFacade _purchaseFacade;

		public override void Setup()
		{
			_mainPage = new MainPage(Driver, Driver, Driver);
			_cartPage = new CartPage(Driver, Driver, Driver);
			_checkoutPage = new CheckoutPage(Driver, Driver);
			_purchaseFacade = new NewPurchaseFacade(_mainPage, _cartPage, _checkoutPage);
		}

		[Test]
		public void PurchaseFalcon9WithFacade()
		{
			var purchaseInfo = new PurchaseInfo
			{
				Email = "info@berlinspaceflowers.com",
				FirstName = "Anton",
				LastName = "Angelov",
				Company = "Space Flowers",
				Country = "Germany",
				Address1 = "1 Willi Brandt Avenue Tiergarten",
				Address2 = "Lützowplatz 17",
				City = "Berlin",
				Zip = "10115",
				Phone = "+00498888999281",
			};

			_purchaseFacade.PurchaseItem("Falcon 9", "happybirthday", 2, "114.00€", purchaseInfo);
		}

		[Test]
		public void PurchaseSaturnVWithFacade()
		{
			var purchaseInfo = new PurchaseInfo
			{
				Email = "info@berlinspaceflowers.com",
				FirstName = "John",
				LastName = "Atanasov",
				Company = "Space Flowers",
				Country = "Germany",
				Address1 = "1 Willi Brandt Avenue Tiergarten",
				Address2 = "Lützowplatz 17",
				City = "Berlin",
				Zip = "10115",
				Phone = "+00498888999281",
			};

			_purchaseFacade.PurchaseItem("Saturn V", "happybirthday", 2, "355.00€", purchaseInfo);
		}
	}
}
