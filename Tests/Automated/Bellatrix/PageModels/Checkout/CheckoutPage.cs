using AutomatedTestingFramework.Core.Drivers;
using Bellatrix.Models;

namespace Bellatrix.PageModels.Checkout
{
	public class CheckoutPage : EShopPage
	{
		private readonly IBrowser _browser;

		public CheckoutPage(IElementFinder elementFinder, IBrowser browser) : base(elementFinder)
		{
			_browser = browser;
			Elements = new CheckoutPageElements(elementFinder);
			Asserts = new CheckoutPageAssertions(Elements);
		}

		public CheckoutPageElements Elements { get; }
		public CheckoutPageAssertions Asserts { get; }

		public void FillBillingInfo(PurchaseInfo purchaseInfo)
		{
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
			_browser.WaitForAjax();
		}
	}
}
