using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Core.Elements;

namespace Bellatrix.PageModels
{
	public class MainPage : BasePageModel
	{
		private readonly string _url = "http://demos.bellatrix.solutions/";

		public MainPage(IDriver driver) : base(driver)
		{ }

		private IAnchor AddToCartFalcon9Button => Driver.Find<IAnchor>(By.CssSelector("[data-product_id*= '28']"));

		private IButton ViewCartButton => Driver.Find<IButton>(By.CssSelector("[class*='added_to_cart wc-forward']"));

		public void AddRocketToShoppingCart()
		{
			Driver.GoToUrl(_url);
			AddToCartFalcon9Button.Click();
			ViewCartButton.Click();
		}
	}
}
