﻿using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Core.Elements;

namespace Bellatrix.PageModels.Checkout
{
	public class CheckoutPageElements
	{
		private readonly IElementFinder _elementFinder;

		public CheckoutPageElements(IElementFinder elementFinder)
		{
			_elementFinder = elementFinder;
		}

		public ITextBox BillingFirstName => _elementFinder.Find<ITextBox>(By.Id("billing_first_name"));
		public ITextBox BillingLastName => _elementFinder.Find<ITextBox>(By.Id("billing_last_name"));
		public ITextBox BillingCompany => _elementFinder.Find<ITextBox>(By.Id("billing_company"));
		public IContentElement BillingCountryWrapper => _elementFinder.Find<IContentElement>(By.Id("select2-billing_country-container"));
		public ITextBox BillingCountryFilter => _elementFinder.Find<ITextBox>(By.CssClass("select2-search__field"));
		public ITextBox BillingAddress1 => _elementFinder.Find<ITextBox>(By.Id("billing_address_1"));
		public ITextBox BillingAddress2 => _elementFinder.Find<ITextBox>(By.Id("billing_address_2"));
		public ITextBox BillingCity => _elementFinder.Find<ITextBox>(By.Id("billing_city"));
		public ITextBox BillingZip => _elementFinder.Find<ITextBox>(By.Id("billing_postcode"));
		public ITextBox BillingPhone => _elementFinder.Find<ITextBox>(By.Id("billing_phone"));
		public ITextBox BillingEmail => _elementFinder.Find<ITextBox>(By.Id("billing_email"));
		public IContentElement CreateAccountCheckBox => _elementFinder.Find<IContentElement>(By.Id("createaccount"));
		public IContentElement CheckPaymentsRadioButton => _elementFinder.Find<IContentElement>(By.CssSelector("[for*='payment_method_cheque']"));
		public IButton PlaceOrderButton => _elementFinder.Find<IButton>(By.Id("place_order"));
		public IContentElement ReceivedMessage => _elementFinder.Find<IContentElement>(By.XPath("//h1"));

		public IContentElement GetCountryOptionByName(string countryName)
		{
			return _elementFinder.Find<IContentElement>(By.XPath($"//*[contains(text(),'{countryName}')]"));
		}
	}
}