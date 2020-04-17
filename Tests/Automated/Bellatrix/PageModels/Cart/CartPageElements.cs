using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Core.Elements;

namespace Bellatrix.PageModels.Cart
{
	public class CartPageElements
	{
		private readonly IDriver _driver;

		public CartPageElements(IDriver driver)
		{
			_driver = driver;
		}

		public ITextBox CouponCodeTextBox => _driver.Find<ITextBox>(By.Id("coupon_code"));

		public IButton ApplyCouponButton => _driver.Find<IButton>(By.CssSelector("[value*='Apply Coupon']"));

		public ITextBox QuantityTextBox => _driver.Find<ITextBox>(By.CssSelector("[class*=input-text qty text]"));

		public IButton UpdateCartButton => _driver.Find<IButton>(By.CssSelector("[value*='Update Cart']"));

		public IContentElement MessageAlert => _driver.Find<IContentElement>(By.CssSelector("[class*='woocommerce-message']"));

		public IContentElement Total => _driver.Find<IContentElement>(By.XPath("//*[@class='order-total']//span"));

		public IButton CheckoutButton => _driver.Find<IButton>(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
	}
}
