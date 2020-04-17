using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Core.Elements;

namespace Bellatrix.PageModels
{
	public class CartPage : EShopPage
	{
		public CartPage(IDriver driver) : base(driver)
		{ }

		private ITextBox CouponCodeTextBox => Driver.Find<ITextBox>(By.Id("coupon_code"));

		private IButton ApplyCouponButton => Driver.Find<IButton>(By.CssSelector("[value*='Apply Coupon']"));

		private ITextBox QuantityTextBox => Driver.Find<ITextBox>(By.CssSelector("[class*=input-text qty text]"));

		private IButton UpdateCartButton => Driver.Find<IButton>(By.CssSelector("[value*='Update Cart']"));

		private IContentElement MessageAlert => Driver.Find<IContentElement>(By.CssSelector("[class*='woocommerce-message']"));

		private IContentElement Total => Driver.Find<IContentElement>(By.XPath("//*[@class='order-total']//span"));

		private IButton CheckoutButton => Driver.Find<IButton>(By.CssSelector("[class*='checkout-button button alt wc-forward']"));

		public void ApplyCoupon(string coupon)
		{
			CouponCodeTextBox.TypeText(coupon);
			ApplyCouponButton.Click();
			Driver.WaitForAjax();
		}

		public void IncreaseProductQuantity(int quantity)
		{
			QuantityTextBox.TypeText(quantity.ToString());
			UpdateCartButton.Click();
			Driver.WaitForAjax();
		}

		public void ProceedToCheckout()
		{
			CheckoutButton.Click();
			Driver.WaitForPageToLoad();
		}

		public string GetTotal()
		{
			return Total.Text;
		}

		public string GetMessageNotification()
		{
			return MessageAlert.Text;
		}
	}
}
