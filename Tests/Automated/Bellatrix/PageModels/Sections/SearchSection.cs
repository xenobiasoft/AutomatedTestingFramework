using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Core.Elements;

namespace Bellatrix.PageModels.Sections
{
	public class SearchSection
	{
		private readonly IElementFinder _elementFinder;

		public SearchSection(IElementFinder elementFinder)
		{
			_elementFinder = elementFinder;
		}

		private ITextBox SearchField => _elementFinder.Find<ITextBox>(By.Id("woocommerce-product-search-field-0"));

		public void SearchForItem(string searchText)
		{
			SearchField.TypeText(searchText);
		}
	}
}
