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

		[Test]
		public void PurchaseFalcon9WithFacade()
		{
			var purchaseInfo = new PurchaseInfo();

			_purchaseFacade.PurchaseItem("Falcon 9", "happybirthday", 2, "235.00€", purchaseInfo);
		}

		[Test]
		public void PurchaseSaturnVWithFacade()
		{
			var purchaseInfo = new PurchaseInfo();

			_purchaseFacade.PurchaseItem("Saturn V", "happybirthday", 2, "235.00€", purchaseInfo);
		}
	}
}
