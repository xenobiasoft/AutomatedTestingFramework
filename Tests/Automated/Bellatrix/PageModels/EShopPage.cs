using AutomatedTestingFramework.Selenium.Interfaces.Drivers;
using Bellatrix.PageModels.Sections;

namespace Bellatrix.PageModels
{
	public abstract class EShopPage<TPage> where TPage : EShopPage<TPage>
	{
		protected readonly IElementFinder ElementFinder;

		protected EShopPage(IElementFinder elementFinder)
		{
			ElementFinder = elementFinder;
			SearchSection = new SearchSection(ElementFinder);
			MainMenuSection = new MainMenuSection(ElementFinder);
			CartInfoSection = new CartInfoSection(ElementFinder);
		}

		public SearchSection SearchSection { get; }
		public MainMenuSection MainMenuSection { get; }
		public CartInfoSection CartInfoSection { get; }
	}
}
