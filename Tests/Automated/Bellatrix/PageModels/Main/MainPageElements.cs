using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Core.Elements;

namespace Bellatrix.PageModels.Main
{
	public class MainPageElements
	{
		private readonly IDriver _driver;

		public MainPageElements(IDriver driver)
		{
			_driver = driver;
		}

		public IAnchor AddToCartFalcon9Button => _driver.Find<IAnchor>(By.CssSelector("[data-product_id*= '28']"));

		public IButton ViewCartButton => _driver.Find<IButton>(By.CssSelector("[class*='added_to_cart wc-forward']"));

		public IAnchor GetAddToCartByName(string name)
		{
			return _driver.Find<IAnchor>(By.XPath($"//h2[text()='{name}']/parent::a[1]"));
		}

		public IAnchor GetProductBoxByName(string name)
		{
			return _driver.Find<IAnchor>(By.XPath($"//h2[text()='{name}']/parent::a[1]"));
		}
	}
}
