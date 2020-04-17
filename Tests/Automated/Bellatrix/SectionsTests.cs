using Bellatrix.PageModels.Cart;
using Bellatrix.PageModels.Main;
using NUnit.Framework;

namespace Bellatrix
{
	[TestFixture]
	public class SectionsTests : BaseTest
	{
		private static MainPage _mainPage;
		private static CartPage _cartPage;

		public override void Setup()
		{
			_mainPage = new MainPage();
			_cartPage = new CartPage();
		}

		[TestCase("Falcon 9", "falcon-9")]
		[TestCase("Saturn V", "saturn-v")]
		public void LinkAddsCorrectProduct(string linkText, string productName)
		{
			_mainPage.Open();
			_mainPage.Asserts.AssertProductBoxLink(linkText, $"http://demos.bellatrix.solutions/product/{productName}/");
		}
	}
}
