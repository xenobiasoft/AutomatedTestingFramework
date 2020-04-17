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
			var purchaseInfo = new PurchaseInfo
			{
				Email = "info@berlinspaceflowers.com",
				FirstName = "Anton",
				LastName = "Angelov",
				Company = "Space Flowers",
				Country = "Germany",
				Address1 = "1 Willi Brandt Avenue Tiergarten",
				Address2 = "Lützowplatz 17",
				City = "Berlin",
				Zip = "10115",
				Phone = "+00498888999281",
			};

			_purchaseFacade.PurchaseItem("Falcon 9", "happybirthday", 2, "114.00€", purchaseInfo);
		}

		[Test]
		public void PurchaseSaturnVWithFacade()
		{
			var purchaseInfo = new PurchaseInfo
			{
				Email = "info@berlinspaceflowers.com",
				FirstName = "John",
				LastName = "Atanasov",
				Company = "Space Flowers",
				Country = "Germany",
				Address1 = "1 Willi Brandt Avenue Tiergarten",
				Address2 = "Lützowplatz 17",
				City = "Berlin",
				Zip = "10115",
				Phone = "+00498888999281",
			};

			_purchaseFacade.PurchaseItem("Saturn V", "happybirthday", 2, "355.00€", purchaseInfo);
		}
	}
}
