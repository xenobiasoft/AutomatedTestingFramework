using Bellatrix.PageModels.Main;
using NUnit.Framework;

namespace Bellatrix
{
	[TestFixture]
	public class SectionsTests : BaseTest
	{
		[TestCase("Falcon 9", "falcon-9")]
		[TestCase("Saturn V", "saturn-v")]
		public void LinkAddsCorrectProduct(string linkText, string productName)
		{
			var mainPage = GetPage<MainPage>();
			mainPage.Open();
			mainPage.Asserts.AssertProductBoxLink(linkText, $"http://demos.bellatrix.solutions/product/{productName}/");
		}
	}
}
