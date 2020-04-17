using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Core.Elements;

namespace Bellatrix.PageModels.Checkout
{
	public class CheckoutPageElements
	{
		private readonly IDriver _driver;

		public CheckoutPageElements(IDriver driver)
		{
			_driver = driver;
		}

		public ITextBox BillingFirstName => _driver.Find<ITextBox>(By.Id("billing_first_name"));
		public ITextBox BillingLastName => _driver.Find<ITextBox>(By.Id("billing_last_name"));
		public ITextBox BillingCompany => _driver.Find<ITextBox>(By.Id("billing_company"));
		public IContentElement BillingCountryWrapper => _driver.Find<IContentElement>(By.Id("select2-billing_country-container"));
		public ITextBox BillingCountryFilter => _driver.Find<ITextBox>(By.CssClass("select2-search__field"));
		public ITextBox BillingAddress1 => _driver.Find<ITextBox>(By.Id("billing_address_1"));
		public ITextBox BillingAddress2 => _driver.Find<ITextBox>(By.Id("billing_address_2"));
		public ITextBox BillingCity => _driver.Find<ITextBox>(By.Id("billing_city"));
		public ITextBox BillingZip => _driver.Find<ITextBox>(By.Id("billing_postcode"));
		public ITextBox BillingPhone => _driver.Find<ITextBox>(By.Id("billing_phone"));
		public ITextBox BillingEmail => _driver.Find<ITextBox>(By.Id("billing_email"));
		public IContentElement CreateAccountCheckBox => _driver.Find<IContentElement>(By.Id("createaccount"));
		public IContentElement CheckPaymentsRadioButton => _driver.Find<IContentElement>(By.CssSelector("[for*='payment_method_cheque']"));
		public IButton PlaceOrderButton => _driver.Find<IButton>(By.Id("place_order"));
		public IContentElement ReceivedMessage => _driver.Find<IContentElement>(By.XPath("//h1"));

		public IContentElement GetCountryOptionByName(string countryName)
		{
			return _driver.Find<IContentElement>(By.XPath($"//*[contains(text(),'{countryName}')]"));
		}
	}
}
