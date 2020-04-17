using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Core.Elements;

namespace Bellatrix.PageModels.Sections
{
	public class BreadcrumbSection
	{
		private readonly IDriver _driver;

		public BreadcrumbSection(IDriver driver)
		{
			_driver = driver;
		}

		private IContentElement Breadcrumb => _driver.Find<IContentElement>(By.CssClass("woocommerce-breadcrumb"));

		public void OpenBreadcrumbItem(string itemToOpen)
		{
			_driver.Find<IAnchor>(By.LinkText(itemToOpen, Breadcrumb)).Click();
		}
	}
}