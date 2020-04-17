using AutomatedTestingFramework.Core.Drivers;
using Bellatrix.PageModels.Sections;

namespace Bellatrix.PageModels
{
	public abstract class EShopPage
	{
		protected readonly IElementFinder ElementFinder;

		protected EShopPage(IElementFinder elementFinder)
		{
			ElementFinder = elementFinder;
			SearchSection = new SearchSection(elementFinder);
			MainMenuSection = new MainMenuSection(elementFinder);
			CartInfoSection = new CartInfoSection(elementFinder);
		}

		public SearchSection SearchSection { get; }
		public MainMenuSection MainMenuSection { get; }
		public CartInfoSection CartInfoSection { get; }
	}
}
