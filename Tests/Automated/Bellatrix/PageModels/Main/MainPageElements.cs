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

		public IButton ViewCartButton => _elementFinder.Find<IButton>(By.CssSelector("[class*='added_to_cart']"));

		public IAnchor GetProductBoxByName(string name)
		{
			return _elementFinder.Find<IAnchor>(By.XPath($"//h2[text()='{name}']/parent::a[1]"));
		}
	}
}
