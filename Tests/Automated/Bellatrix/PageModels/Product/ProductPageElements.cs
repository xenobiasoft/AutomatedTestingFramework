using AutomatedTestingFramework.Selenium;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;

namespace Bellatrix.PageModels.Product
{
	public class ProductPageElements
	{
		private readonly IElementFinder _elementFinder;

		public ProductPageElements(IElementFinder elementFinder)
		{
			_elementFinder = elementFinder;
		}

		public IButton AddToCartButton => _elementFinder.Find<IButton>(By.LinkText("Add to cart"));
		public ITextBox QuantityTextBox => _elementFinder.Find<ITextBox>(By.CssClass("[class=*'input-text qty text']"));
		public IAnchor ViewCartLink => _elementFinder.Find<IAnchor>(By.LinkText("View cart"));
	}
}
