using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Core.Elements;
using NUnit.Framework;

namespace Bellatrix.PageModels
{
	public class MainPage : NavigatableEShopPage
	{
		private readonly By _addToCartFalcon9ButtonBy = By.CssSelector("[data-product_id*= '28']");
		private readonly By _viewCartButtonBy = By.CssSelector("[class*='added_to_cart wc-forward']");

		public MainPage(IDriver driver) : base(driver)
		{ }

		protected override string Url => "http://demos.bellatrix.solutions/";
		private IAnchor AddToCartFalcon9Button => Driver.Find<IAnchor>(_addToCartFalcon9ButtonBy);
		private IButton ViewCartButton => Driver.Find<IButton>(_viewCartButtonBy);

		public void AddRocketToShoppingCart()
		{
			Open();
			AddToCartFalcon9Button.Click();
			ViewCartButton.Click();
		}

		protected override void WaitForPageLoad()
		{
			Driver.WaitForElementToExist(_addToCartFalcon9ButtonBy);
		}

		public void AssertProductBoxLink(string name, string expectedLink)
		{
			var actualLink = GetProductBoxByName(name).Href;

			Assert.That(expectedLink, Is.EqualTo(actualLink));
		}

		private IAnchor GetProductBoxByName(string name)
		{
			return Driver.Find<IAnchor>(By.XPath($"//h2[text()='{name}']/parent::a[1]"));
		}
	}
}
