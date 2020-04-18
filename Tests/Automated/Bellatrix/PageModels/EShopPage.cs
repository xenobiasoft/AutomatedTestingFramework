using AutomatedTestingFramework.Selenium.Drivers;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;
using Bellatrix.PageModels.Sections;

namespace Bellatrix.PageModels
{
	public abstract class EShopPage<TPage> where TPage : EShopPage<TPage>, new()
	{
		private static TPage _instance;

		protected readonly IElementFinder ElementFinder;

		protected EShopPage()
		{
			ElementFinder = LoggingDriver.Instance;
			SearchSection = new SearchSection(ElementFinder);
			MainMenuSection = new MainMenuSection(ElementFinder);
			CartInfoSection = new CartInfoSection(ElementFinder);
		}

		public static TPage Instance => _instance ??= new TPage();

		public SearchSection SearchSection { get; }
		public MainMenuSection MainMenuSection { get; }
		public CartInfoSection CartInfoSection { get; }
	}
}
