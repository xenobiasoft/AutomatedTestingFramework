﻿using System;
using AutomatedTestingFramework.Selenium.Drivers;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;

namespace Bellatrix.PageModels.Cart
{
	public class CartPage : NavigatableEShopPage<CartPage>
	{
		private static readonly Lazy<CartPage> Lazy = new Lazy<CartPage>(() => new CartPage());

		public static CartPage Instance => Lazy.Value;

		private readonly IElementWaitService _waitService;

		public CartPage()
		{
			var driver = LoggingDriver.Instance;
			_waitService = driver;
			Elements = new CartPageElements(ElementFinder);
			Asserts = new CartPageAssertions(Elements);
		}

		public CartPageElements Elements { get; }
		public CartPageAssertions Asserts { get; }

		public void ApplyCoupon(string coupon)
		{
			Elements.CouponCodeTextBox.TypeText(coupon);
			Elements.ApplyCouponButton.Click();
			_waitService.WaitForAjax();
		}

		public void IncreaseProductQuantity(int quantity)
		{
			Elements.QuantityTextBox.TypeText(quantity.ToString());
			Elements.UpdateCartButton.Click();
			_waitService.WaitForAjax();
		}

		public void ProceedToCheckout()
		{
			_waitService.WaitForElementToBeClickable(Elements.CheckoutButton.By);
			Elements.CheckoutButton.Click();
			_waitService.WaitForAjax();
		}

		protected override string Url => PageUrls.GetPageUrl("cart/");

		protected override void WaitForPageLoad()
		{
			_waitService.WaitForElementToExist(Elements.CouponCodeTextBox.By);
		}
	}
}
