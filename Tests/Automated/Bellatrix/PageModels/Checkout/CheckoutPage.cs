using System.Threading;
using AutomatedTestingFramework.Selenium.Drivers;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;
using Bellatrix.Models;

namespace Bellatrix.PageModels.Checkout
{
	public class CheckoutPage : EShopPage<CheckoutPage>
	{
		private readonly IElementWaitService _waitService;

		public CheckoutPage()
		{
			var driver = WebDriverFactory.Instance;
			_waitService = driver;
			Elements = new CheckoutPageElements(driver);
			Asserts = new CheckoutPageAssertions(Elements);
		}

		public CheckoutPageElements Elements { get; }
		public CheckoutPageAssertions Asserts { get; }

		public void FillBillingInfo(PurchaseInfo purchaseInfo)
		{
			Thread.Sleep(4000);

			Elements.BillingFirstName.TypeText(purchaseInfo.FirstName);
			Elements.BillingLastName.TypeText(purchaseInfo.LastName);
			Elements.BillingCompany.TypeText(purchaseInfo.Company);
			Elements.BillingCountryWrapper.Click();
			Elements.BillingCountryFilter.TypeText(purchaseInfo.Country);
			Elements.GetCountryOptionByName(purchaseInfo.Country).Click();
			Elements.BillingAddress1.TypeText(purchaseInfo.Address1);
			Elements.BillingAddress2.TypeText(purchaseInfo.Address2);
			Elements.BillingCity.TypeText(purchaseInfo.City);
			Elements.BillingZip.TypeText(purchaseInfo.Zip);
			Elements.BillingPhone.TypeText(purchaseInfo.Phone);
			Elements.BillingEmail.TypeText(purchaseInfo.Email);

			if (purchaseInfo.ShouldCreateAccount)
			{
				Elements.CreateAccountCheckBox.Click();
			}

			if (purchaseInfo.ShouldCheckPayment)
			{
				Elements.CheckPaymentsRadioButton.Click();
			}

			Elements.PlaceOrderButton.Click();
			_waitService.WaitForAjax();
		}
	}
}
