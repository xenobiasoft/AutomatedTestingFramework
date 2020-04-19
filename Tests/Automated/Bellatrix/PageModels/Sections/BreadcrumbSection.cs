using AutomatedTestingFramework.Selenium;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;

namespace Bellatrix.PageModels.Sections
{
	public class BreadcrumbSection
	{
		private readonly IDriver _driver;

		public BreadcrumbSection(IDriver driver)
		{
			_driver = driver;
		}

		private IElement Breadcrumb => _driver.Find<IElement>(By.CssClass("woocommerce-breadcrumb"));

		public void OpenBreadcrumbItem(string itemToOpen)
		{
			_driver.Find<IAnchor>(By.LinkText(itemToOpen, Breadcrumb)).Click();
		}
	}
}