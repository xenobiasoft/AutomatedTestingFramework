using System;
using AutomatedTestingFramework.Core.Attributes;
using AutomatedTestingFramework.Core.Elements;
using AutomatedTestingFramework.Core.Enums;
using NUnit.Framework;
using By = AutomatedTestingFramework.Core.By;

namespace Bellatrix
{
	[TestFixture]
	[ExecutionBrowser(Browser.Chrome, BrowserBehavior.ReuseIfStarted)]
	public class ProductPurchaseTests : BaseTest
	{
		private static string _purchaseEmail;
		private static string _purchaseOrderNumber;

		[Test]
		public void CompletePurchaseSuccessfully_WhenNewClient()
		{
			AddRocketToShoppingCart();
			ApplyCoupon();
			IncreaseProductQuantity();

			var proceedToCheckout = Driver.Find<IButton>(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
			proceedToCheckout.Click();

			Driver.WaitForPageToLoad();

			var billingFirstName = Driver.Find<IElement>(By.Id("billing_first_name"));
			billingFirstName.TypeText("Anton");

			var billingLastName = Driver.Find<IElement>(By.Id("billing_last_name"));
			billingLastName.TypeText("Angelov");

			var billingCompany = Driver.Find<IElement>(By.Id("billing_company"));
			billingCompany.TypeText("Space Flowers");

			var billingCountryWrapper = Driver.Find<IElement>(By.Id("select2-billing_country-container"));
			billingCountryWrapper.Click();

			var billingCountryFilter = Driver.Find<IElement>(By.CssClass("select2-search__field"));
			billingCountryFilter.TypeText("Germany");

			var germanyOption = Driver.Find<IElement>(By.XPath("//*[contains(text(),'Germany')]"));
			germanyOption.Click();

			var billingAddress1 = Driver.Find<IElement>(By.Id("billing_address_1"));
			billingAddress1.TypeText("1 Willi Brandt Avenue Tiergarten");

			var billingAddress2 = Driver.Find<IElement>(By.Id("billing_address_2"));
			billingAddress2.TypeText("Lützowplatz 17");

			var billingCity = Driver.Find<IElement>(By.Id("billing_city"));
			billingCity.TypeText("Berlin");

			var billingZip = Driver.Find<IElement>(By.Id("billing_postcode"));
			billingZip.TypeText("10115");

			var billingPhone = Driver.Find<IElement>(By.Id("billing_phone"));
			billingPhone.TypeText("+00498888999281");

			var billingEmail = Driver.Find<IElement>(By.Id("billing_email"));
			billingEmail.TypeText(GenerateUniqueEmail());

			_purchaseEmail = GenerateUniqueEmail();

			Driver.WaitForAjax();
			var placeOrderButton = Driver.Find<IElement>(By.Id("place_order"));
			placeOrderButton.Click();

			Driver.WaitForAjax();

			var receivedMessage = Driver.Find<IElement>(By.XPath("//h1"));

			Assert.AreEqual("Order received", receivedMessage.Text);
		}

		[Test]
		[ExecutionBrowser(Browser.Firefox, BrowserBehavior.ReuseIfStarted)]
		public void CompletePurchaseSuccessfully_WhenExistingClient()
		{
			AddRocketToShoppingCart();
			ApplyCoupon();
			IncreaseProductQuantity();

			var proceedToCheckout = Driver.Find<IElement>(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
			proceedToCheckout.Click();

			Driver.WaitForPageToLoad();

			var loginHereLink = Driver.Find<IElement>(By.LinkText("Click here to login"));
			loginHereLink.Click();

			Login("info@berlinspaceflowers.com");

			Driver.WaitForAjax();

			var placeOrderButton = Driver.Find<IElement>(By.Id("place_order"));
			placeOrderButton.Click();

			Driver.WaitForAjax();

			var receivedMessage = Driver.Find<IElement>(By.XPath("//h1[text() = 'Order received']"));
			Assert.AreEqual("Order received", receivedMessage.Text);

			var orderNumber = Driver.Find<IElement>(By.XPath("//*[@id='post-7']/div/div/div/ul/li[1]/strong"));
			_purchaseOrderNumber = orderNumber.Text;

		}

		private void Login(string userName)
		{
			Driver.WaitForAjax();

			var userNameTextField = Driver.Find<IElement>(By.Id("username"));
			userNameTextField.TypeText(userName);

			var passwordField = Driver.Find<IElement>(By.Id("password"));
			passwordField.TypeText(GetUserPasswordFromDb(userName));

			var loginButton = Driver.Find<IElement>(By.XPath("//button[@name='login']"));
			loginButton.Click();
		}

		private void IncreaseProductQuantity()
		{
			var quantityBox = Driver.Find<IElement>(By.CssSelector("[class*='input-text qty text']"));
			quantityBox.TypeText("2");

			Driver.WaitForAjax();

			var updateCart = Driver.Find<IElement>(By.CssSelector("[value*='Update cart']"));
			updateCart.Click();

			Driver.WaitForAjax();

			var totalSpan = Driver.Find<IElement>(By.XPath("//*[@class='order-total']//span"));
			Assert.AreEqual("114.00€", totalSpan.Text);
		}

		private void ApplyCoupon()
		{
			var couponCodeTextField = Driver.Find<IElement>(By.Id("coupon_code"));
			couponCodeTextField.TypeText("happybirthday");

			var applyCouponButton = Driver.Find<IElement>(By.CssSelector("[value*='Apply coupon']"));
			applyCouponButton.Click();

			Driver.WaitForAjax();

			var messageAlert = Driver.Find<IElement>(By.CssSelector("[class*='woocommerce-message']"));
			Assert.AreEqual("Coupon code applied successfully.", messageAlert.Text);
		}

		private void AddRocketToShoppingCart()
		{
			Driver.GoToUrl("http://demos.bellatrix.solutions/");

			var addToCartFalcon9 = Driver.Find<IElement>(By.CssSelector("[data-product_id*='28']"));
			addToCartFalcon9.Click();

			Driver.WaitForAjax();

			var viewCartButton = Driver.Find<IElement>(By.CssSelector("[class*='added_to_cart wc-forward']"));
			viewCartButton.Click();
		}

		private string GetUserPasswordFromDb(string userName)
		{
			return "@purISQzt%%DYBnLCIhaoG6$";
		}

		private string GenerateUniqueEmail()
		{
			return $"{Guid.NewGuid()}@berlinspaceflowers.com";
		}
	}
}