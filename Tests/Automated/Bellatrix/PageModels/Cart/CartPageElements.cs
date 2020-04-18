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

		public IButton ApplyCouponButton => _elementFinder.Find<IButton>(By.CssSelector("[value*='Apply Coupon']"));

		public ITextBox QuantityTextBox => _elementFinder.Find<ITextBox>(By.CssSelector("[class*=input-text qty text]"));

		public IButton UpdateCartButton => _elementFinder.Find<IButton>(By.CssSelector("[value*='Update Cart']"));

		public IContentElement MessageAlert => _elementFinder.Find<IContentElement>(By.CssSelector("[class*='woocommerce-message']"));

		public IContentElement Total => _elementFinder.Find<IContentElement>(By.XPath("//*[@class='order-total']//span"));

		public IButton CheckoutButton => _elementFinder.Find<IButton>(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
	}
}
