using Bellatrix.PageModels;
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
			_mainPage = new MainPage(Driver, Driver, Driver);
			_cartPage = new CartPage(Driver, Driver, Driver);
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
