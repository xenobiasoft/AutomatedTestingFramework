using AutomatedTestingFramework.Selenium;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;

namespace Bellatrix.PageModels.Main
{
	public class MainPageElements
	{
		private readonly IElementFinder _elementFinder;

		public MainPageElements(IElementFinder elementFinder)
		{
			_elementFinder = elementFinder;
		}

		public IAnchor AddToCartFalcon9Button => _elementFinder.Find<IAnchor>(By.CssSelector("[data-product_id*= '28']"));

		public IButton ViewCartButton => _elementFinder.Find<IButton>(By.CssSelector("[class*='added_to_cart wc-forward']"));

		public IAnchor GetAddToCartByName(string name)
		{
			return _elementFinder.Find<IAnchor>(By.XPath($"//h2[text()='{name}']/parent::a[1]"));
		}

		public IAnchor GetProductBoxByName(string name)
		{
			return _elementFinder.Find<IAnchor>(By.XPath($"//h2[text()='{name}']/parent::a[1]"));
		}
	}
}
