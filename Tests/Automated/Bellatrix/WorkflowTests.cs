using Bellatrix.Facades;
using Bellatrix.Models;
using NUnit.Framework;

namespace Bellatrix
{
	[TestFixture]
	public class WorkflowTests : BaseTest
	{
		private static NewPurchaseFacade _purchaseFacade;

		public override void Setup()
		{
			_purchaseFacade = new NewPurchaseFacade();
		}

		[TestCase("Falcon 9", "happybirthday", 2, "114.00€")]
		[TestCase("Saturn V", "happybirthday", 3, "355.00€")]
		public void PurchaseRocket(string rocketName, string couponCode, int quantity, string expectedPrice)
		{
			var purchaseInfo = new PurchaseInfo();

			_purchaseFacade.PurchaseItem(rocketName, couponCode, quantity, expectedPrice, purchaseInfo);
		}
	}
}
