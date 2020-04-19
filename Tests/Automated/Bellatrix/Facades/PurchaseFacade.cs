using Bellatrix.Models;

namespace Bellatrix.Facades
{
	public abstract class PurchaseFacade
	{
		public void PurchaseItem(string rocketName, string couponCode, int quantity, string expectedPrice,
			PurchaseInfo purchaseInfo)
		{
			AddRocketToShoppingCart(rocketName);
			ApplyCoupon(couponCode);
			AssertCouponAppliedSuccessfully();
			IncreaseProductQuantity(quantity);
			AssertTotalPrice(expectedPrice);
			ProceedToCheckout();
			FillBillingInfo(purchaseInfo);
			AssertOrderReceived();
		}

		protected abstract void AddRocketToShoppingCart(string rocketName);
		public abstract void ApplyCoupon(string couponCode);
		public abstract void AssertCouponAppliedSuccessfully();
		public abstract void IncreaseProductQuantity(int quantity);
		public abstract void AssertTotalPrice(string expectedPrice);
		public abstract void ProceedToCheckout();
		public abstract void FillBillingInfo(PurchaseInfo purchaseInfo);
		public abstract void AssertOrderReceived();
	}
}
