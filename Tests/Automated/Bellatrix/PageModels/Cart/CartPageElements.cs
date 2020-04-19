using AutomatedTestingFramework.Selenium;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;

namespace Bellatrix.PageModels.Cart
{
	public class CartPageElements
	{
		private readonly IElementFinder _elementFinder;

		public CartPageElements(IElementFinder elementFinder)
		{
			_elementFinder = elementFinder;
		}

		public ITextBox CouponCodeTextBox => _elementFinder.Find<ITextBox>(By.Id("coupon_code"));

		public IButton ApplyCouponButton => _elementFinder.Find<IButton>(By.Name("apply_coupon"));

		public ITextBox QuantityTextBox => _elementFinder.Find<ITextBox>(By.CssClass("qty"));

		public IButton UpdateCartButton => _elementFinder.Find<IButton>(By.Name("update_cart"));

		public ILabel MessageAlert => _elementFinder.Find<ILabel>(By.CssSelector("[class*='woocommerce-message']"));

		public ILabel Total => _elementFinder.Find<ILabel>(By.XPath("//*[@class='order-total']//span"));

		public IButton CheckoutButton => _elementFinder.Find<IButton>(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
	}
}
