using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Core.Elements;

namespace Bellatrix.PageModels.Sections
{
	public class SearchSection
	{
		private readonly IDriver _driver;

		public SearchSection(IDriver driver)
		{
			_driver = driver;
		}

		private ITextBox SearchField => _driver.Find<ITextBox>(By.Id("woocommerce-product-search-field-0"));

		public void SearchForItem(string searchText)
		{
			SearchField.TypeText(searchText);
		}
	}
}
