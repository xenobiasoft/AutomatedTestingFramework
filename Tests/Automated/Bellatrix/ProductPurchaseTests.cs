using System;
using AutomatedTestingFramework.Core.Attributes;
using AutomatedTestingFramework.Core.Elements;
using AutomatedTestingFramework.Core.Enums;
using Bellatrix.PageModels;
using Bellatrix.PageModels.Main;
using FluentAssertions;
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
		private static MainPage _mainPage;
		private static CartPage _cartPage;

		public override void Setup()
		{
			_mainPage = new MainPage(Driver);
			_cartPage = new CartPage(Driver);
		}

		[Test]
		public void CompletePurchaseSuccessfully_WhenNewClient()
		{
			_mainPage.AddRocketToShoppingCart();

			_cartPage.ApplyCoupon("happybirthday");

			_cartPage.GetMessageNotification().Should().Be("Coupon code applied successfully.");

			_cartPage.IncreaseProductQuantity(2);

			_cartPage.GetTotal().Should().Be("114.00€");

			_cartPage.ProceedToCheckout();

			var receivedMessage = Driver.Find<IElement>(By.XPath("//h1"));

			receivedMessage.Text.Should().Be("Checkout");
		}

		[Test]
		[ExecutionBrowser(Browser.Firefox, BrowserBehavior.ReuseIfStarted)]
		public void CompletePurchaseSuccessfully_WhenExistingClient()
		{
			_mainPage.AddRocketToShoppingCart();

			_cartPage.ApplyCoupon("happybirthday");

			_cartPage.GetMessageNotification().Should().Be("Coupon code applied successfully.");

			_cartPage.IncreaseProductQuantity(2);

			_cartPage.ProceedToCheckout();

			var loginHereLink = Driver.Find<IElement>(By.LinkText("Click here to login"));
			loginHereLink.Click();
			Login("info@berlinspaceflowers.com");
			Driver.WaitForAjax();
			var placeOrderButton = Driver.Find<IElement>(By.Id("place_order"));
			placeOrderButton.Click();
			Driver.WaitForAjax();

			var receivedMessage = Driver.Find<IElement>(By.XPath("//h1"));
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