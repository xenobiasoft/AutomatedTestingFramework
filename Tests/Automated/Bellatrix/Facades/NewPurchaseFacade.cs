using Bellatrix.Models;
using Bellatrix.PageModels;
using Bellatrix.PageModels.Cart;
using Bellatrix.PageModels.Checkout;
using Bellatrix.PageModels.Main;

namespace Bellatrix.Facades
{
	public class NewPurchaseFacade : PurchaseFacade
	{
		private readonly MainPage _mainPage;
		private readonly CartPage _cartPage;
		private readonly CheckoutPage _checkoutPage;

		public NewPurchaseFacade(MainPage mainPage, CartPage cartPage, CheckoutPage checkoutPage)
		{
			_checkoutPage = checkoutPage;
			_cartPage = cartPage;
			_mainPage = mainPage;
		}

		protected override void AddRocketToShoppingCart(string rocketName)
		{
			_mainPage.Open();
			_mainPage.AddRocketToShoppingCart(rocketName);
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
