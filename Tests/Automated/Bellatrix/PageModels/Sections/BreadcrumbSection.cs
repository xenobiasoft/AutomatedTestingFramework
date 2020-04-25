using AutomatedTestingFramework.Selenium;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;

namespace Bellatrix.PageModels.Sections
{
	public class BreadcrumbSection
	{
		private readonly IElementFinder _elementFinder;

		public BreadcrumbSection(IElementFinder elementFinder)
		{
			_elementFinder = elementFinder;
		}

		private IElement Breadcrumb => _elementFinder.Find<IElement>(By.CssClass("woocommerce-breadcrumb"));

		public void OpenBreadcrumbItem(string itemToOpen)
		{
			_elementFinder.Find<IAnchor>(By.LinkText(itemToOpen, Breadcrumb)).Click();
		}
	}
}