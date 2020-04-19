using AutomatedTestingFramework.Selenium.Configuration;
using Bellatrix.Configuration;

namespace Bellatrix.Models
{
	public class PurchaseInfo
	{
		private readonly BillingInfoDefaultValues _defaultBillingInfo;

		public PurchaseInfo()
		{
			_defaultBillingInfo = ConfigurationService.Instance.GetSettings<BillingInfoDefaultValues>("billingInfoDefaultValues");
		}

		public string FirstName => _defaultBillingInfo.FirstName;
		public string LastName => _defaultBillingInfo.LastName;
		public string Company => _defaultBillingInfo.Company;
		public string Country => _defaultBillingInfo.Country;
		public string Address1 => _defaultBillingInfo.Address1;
		public string Address2 => _defaultBillingInfo.Address2;
		public string City => _defaultBillingInfo.City;
		public string Zip => _defaultBillingInfo.Zip;
		public string Phone => _defaultBillingInfo.Phone;
		public string Email => _defaultBillingInfo.Email;
		public bool ShouldCreateAccount { get; set; }
		public bool ShouldCheckPayment { get; set; }
		public string Notes { get; set; }
	}
}
