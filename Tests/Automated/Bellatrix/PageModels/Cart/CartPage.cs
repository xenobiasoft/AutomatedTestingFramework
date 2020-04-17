using System;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Selenium.Drivers;

namespace Bellatrix.PageModels.Cart
{
	public class CartPage : NavigatableEShopPage<CartPage>
	{
		private static readonly Lazy<CartPage> lazy = new Lazy<CartPage>(() => new CartPage());

		public static CartPage Instance => lazy.Value;

		private readonly IBrowser _browser;

		public CartPage()
		{
			var driver = LoggingDriver.Instance;
			_browser = driver;
			Elements = new CartPageElements(ElementFinder);
			Asserts = new CartPageAssertions(Elements);
		}

		public CartPageElements Elements { get; }
		public CartPageAssertions Asserts { get; }

		public void ApplyCoupon(string coupon)
		{
			Elements.CouponCodeTextBox.TypeText(coupon);
			Elements.ApplyCouponButton.Click();
			_browser.WaitForAjax();
		}

		public void IncreaseProductQuantity(int quantity)
		{
			Elements.QuantityTextBox.TypeText(quantity.ToString());
			Elements.UpdateCartButton.Click();
			_browser.WaitForAjax();
		}

		public void ProceedToCheckout()
		{
			Elements.CheckoutButton.Click();
			_browser.WaitForPageToLoad();
		}

		public string GetTotal()
		{
			return Elements.Total.Text;
		}

		public string GetMessageNotification()
		{
			return Elements.MessageAlert.Text;
		}

		protected override string Url => "http://demos.bellatrix.solutions/cart/";

		protected override void WaitForPageLoad()
		{
			ElementFinder.WaitForElementToExist(Elements.CouponCodeTextBox.By);
		}
	}
}
