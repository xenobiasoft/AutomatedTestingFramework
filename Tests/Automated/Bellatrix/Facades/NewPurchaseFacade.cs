using Bellatrix.Models;
using Bellatrix.PageModels.Cart;
using Bellatrix.PageModels.Checkout;
using Bellatrix.PageModels.Main;
using Bellatrix.PageModels.Product;

namespace Bellatrix.Facades
{
	public class NewPurchaseFacade : PurchaseFacade
	{
		private readonly MainPage _mainPage;
		private readonly ProductPage _productPage;
		private readonly CartPage _cartPage;
		private readonly CheckoutPage _checkoutPage;

		public NewPurchaseFacade()
		{
			_mainPage = MainPage.Instance;
			_productPage = ProductPage.Instance;
			_cartPage = CartPage.Instance;
			_checkoutPage = CheckoutPage.Instance;
		}

		protected override void AddRocketToShoppingCart(string rocketName)
		{
			_mainPage.Open();
			_mainPage.SelectARocket(rocketName);
			_productPage.AddRocketToShoppingCart();
		}

		public override void ApplyCoupon(string couponCode)
		{
			_cartPage.ApplyCoupon(couponCode);
		}

		public override void AssertCouponAppliedSuccessfully()
		{
			_cartPage.Asserts.AssertCouponAppliedSuccessfully();
		}

		public override void IncreaseProductQuantity(int quantity)
		{
			_cartPage.IncreaseProductQuantity(quantity);
		}

		public override void AssertTotalPrice(string expectedPrice)
		{
			_cartPage.Asserts.AssertTotalPrice(expectedPrice);
		}

		public override void ProceedToCheckout()
		{
			_cartPage.ProceedToCheckout();
		}

		public override void FillBillingInfo(PurchaseInfo purchaseInfo)
		{
			_checkoutPage.FillBillingInfo(purchaseInfo);
		}

		public override void AssertOrderReceived()
		{
			_checkoutPage.Asserts.AssertOrderReceived();
		}
	}
}
