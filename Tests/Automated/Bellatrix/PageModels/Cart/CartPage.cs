using AutomatedTestingFramework.Core.Drivers;
using Bellatrix.PageModels.Cart;

namespace Bellatrix.PageModels
{
	public class CartPage : EShopPage
	{
		public CartPage(IDriver driver) : base(driver)
		{
			Elements = new CartPageElements(driver);
			Asserts = new CartPageAsserts(Elements);
		}

		public CartPageElements Elements { get; }
		public CartPageAsserts Asserts { get; }

		public void ApplyCoupon(string coupon)
		{
			Elements.CouponCodeTextBox.TypeText(coupon);
			Elements.ApplyCouponButton.Click();
			Driver.WaitForAjax();
		}

		public void IncreaseProductQuantity(int quantity)
		{
			Elements.QuantityTextBox.TypeText(quantity.ToString());
			Elements.UpdateCartButton.Click();
			Driver.WaitForAjax();
		}

		public void ProceedToCheckout()
		{
			Elements.CheckoutButton.Click();
			Driver.WaitForPageToLoad();
		}

		public string GetTotal()
		{
			return Elements.Total.Text;
		}

		public string GetMessageNotification()
		{
			return Elements.MessageAlert.Text;
		}
	}
}
