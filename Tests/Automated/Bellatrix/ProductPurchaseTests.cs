using AutomatedTestingFramework.CompositionRoot;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Core.Elements;
using AutomatedTestingFramework.Core.Enums;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using By = AutomatedTestingFramework.Core.By;

namespace Bellatrix
{
	[TestFixture]
	public class ProductPurchaseTests
	{
		private static IDriver _driver;
		private static string _purchaseOrderNumber;
		private static CompositeRoot _container;
		private static readonly string _purchaserEmail = "info@berlinspaceflowers.com";

		[SetUp]
		public static void Setup()
		{
			_container = new CompositeRoot();
			_driver = _container.CreateScope().ServiceProvider.GetRequiredService<IDriver>();

			_driver.Start(Browser.Chrome);
		}

		[TearDown]
		public static void ClassCleanup()
		{
			_driver.Quit();
			_container.Dispose();
		}

		[Test]
		public void CompletePurchaseSuccessfully_WhenNewClient()
		{
			AddRocketToShoppingCart();
			ApplyCoupon();
			IncreaseProductQuantity();

			var proceedToCheckout = _driver.WaitAndFindElement<IButton>(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
			proceedToCheckout.Click();

			_driver.WaitForPageToLoad();

			var billingFirstName = _driver.WaitAndFindElement<ITextBox>(By.Id("billing_first_name"));
			billingFirstName.TypeText("Anton");

			var billingLastName = _driver.WaitAndFindElement<ITextBox>(By.Id("billing_last_name"));
			billingLastName.TypeText("Angelov");

			var billingCompany = _driver.WaitAndFindElement<ITextBox>(By.Id("billing_company"));
			billingCompany.TypeText("Space Flowers");

			var billingCountryWrapper = _driver.WaitAndFindElement<IElement>(By.Id("select2-billing_country-container"));
			billingCountryWrapper.Click();

			var billingCountryFilter = _driver.WaitAndFindElement<ITextBox>(By.CssClass("select2-search__field"));
			billingCountryFilter.TypeText("Germany");

			var germanyOption = _driver.WaitAndFindElement<IElement>(By.XPath("//*[contains(text(),'Germany')]"));
			germanyOption.Click();

			var billingAddress1 = _driver.WaitAndFindElement<ITextBox>(By.Id("billing_address_1"));
			billingAddress1.TypeText("1 Willi Brandt Avenue Tiergarten");

			var billingAddress2 = _driver.WaitAndFindElement<ITextBox>(By.Id("billing_address_2"));
			billingAddress2.TypeText("Lützowplatz 17");

			var billingCity = _driver.WaitAndFindElement<ITextBox>(By.Id("billing_city"));
			billingCity.TypeText("Berlin");

			var billingZip = _driver.WaitAndFindElement<ITextBox>(By.Id("billing_postcode"));
			billingZip.TypeText("10115");

			var billingPhone = _driver.WaitAndFindElement<ITextBox>(By.Id("billing_phone"));
			billingPhone.TypeText("+00498888999281");

			var billingEmail = _driver.WaitAndFindElement<ITextBox>(By.Id("billing_email"));
			billingEmail.TypeText("info@berlinspaceflowers.com");

			var placeOrderButton = _driver.WaitAndFindElement<IButton>(By.Id("place_order"));
			placeOrderButton.Click();

			var receivedMessage = _driver.WaitAndFindElement<IElement>(By.XPath("/html/body/div[1]/div/div/div/main/div/header/h1"));

			Assert.AreEqual("Order received", receivedMessage.Text);
		}

		[Test]
		public void CompletePurchaseSuccessfully_WhenExistingClient()
		{
			AddRocketToShoppingCart();
			ApplyCoupon();
			IncreaseProductQuantity();

			var proceedToCheckout = _driver.WaitAndFindElement<IButton>(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
			proceedToCheckout.Click();

			var loginHereLink = _driver.WaitAndFindElement<IButton>(By.LinkText("Click here to login"));
			loginHereLink.Click();
			Login(_purchaserEmail);

			var placeOrderButton = _driver.WaitAndFindElement<IButton>(By.Id("place_order"));
			placeOrderButton.Click();

			var receivedMessage = _driver.WaitAndFindElement<IElement>(By.XPath("//h1[text() = 'Order received']"));
			Assert.AreEqual("Order received", receivedMessage.Text);

			var orderNumber = _driver.WaitAndFindElement<IElement>(By.XPath("//*[@id='post-7']/div/div/div/ul/li[1]/strong"));
			_purchaseOrderNumber = orderNumber.Text;
		}

		[Test]
		public void CorrectOrderDataDisplayed_WhenNavigateToMyAccountOrderSection()
		{
			_driver.GoToUrl("http://demos.bellatrix.solutions/");

			var myAccountLink = _driver.WaitAndFindElement<IAnchor>(By.LinkText("My account"));
			myAccountLink.Click();

			Login(_purchaserEmail);

			var orders = _driver.WaitAndFindElement<IAnchor>(By.LinkText("Orders"));
			orders.Click();

			var viewButton = _driver.Find<IAnchor>(By.LinkText("View"));
			viewButton.Click();

			var orderName = _driver.WaitAndFindElement<IElement>(By.XPath("//h1"));
			var expectedMessage = $"Order #{_purchaseOrderNumber}";

			Assert.AreEqual(expectedMessage, orderName.Text);
		}

		private void Login(string username)
		{
			var usernameTextField = _driver.WaitAndFindElement<ITextBox>(By.Id("username"));
			usernameTextField.TypeText(username);

			var password = _driver.WaitAndFindElement<ITextBox>(By.Id("password"));
			password.TypeText(GetUserPasswordFromDb(username));

			var loginButton = _driver.WaitAndFindElement<IButton>(By.XPath("//button[@name='login']"));
			loginButton.Click();
		}

		private void IncreaseProductQuantity()
		{
			var quantityBox = _driver.WaitAndFindElement<ITextBox>(By.CssSelector("[class*='input-text qty text']"));
			quantityBox.TypeText("2");

			var updateCart = _driver.WaitAndFindElement<IButton>(By.CssSelector("[value*='Update cart']"));
			updateCart.Click();

			var totalSpan = _driver.WaitAndFindElement(By.XPath("//*[@class='order-total']//span"));

			Assert.AreEqual("114.00€", totalSpan.Text);
		}

		private void ApplyCoupon()
		{
			var couponCodeTextField = _driver.WaitAndFindElement(By.Id("coupon_code"));
			couponCodeTextField.TypeText("happybirthday");

			var applyCouponButton = _driver.WaitAndFindElement(By.CssSelector("[value*='Apply coupon']"));
			applyCouponButton.Click();

			var messageAlert = _driver.WaitAndFindElement(By.CssSelector("[class*='woocommerce-message']"));

			Assert.AreEqual("Coupon code applied successfully.", messageAlert.Text);
		}

		private void AddRocketToShoppingCart()
		{
			_driver.GoToUrl("http://demos.bellatrix.solutions/");

			var addToCartFalcon9 = _driver.WaitAndFindElement(By.CssSelector("[data-product_id*='28']"));
			addToCartFalcon9.Click();

			var viewCartButton = _driver.WaitAndFindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));
			viewCartButton.Click();
		}

		private string GetUserPasswordFromDb(string userName)
		{
			return "@purISQzt%%DYBnLCIhaoG6$";
		}
	}
}