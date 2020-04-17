using AutomatedTestingFramework.Core.Drivers;
using Bellatrix.PageModels.Sections;

namespace Bellatrix.PageModels
{
	public abstract class EShopPage
	{
		protected readonly IDriver Driver;

		protected EShopPage(IDriver driver)
		{
			Driver = driver;
			SearchSection = new SearchSection(Driver);
			MainMenuSection = new MainMenuSection(Driver);
			CartInfoSection = new CartInfoSection(Driver);
		}

		public SearchSection SearchSection { get; }
		public MainMenuSection MainMenuSection { get; }
		public CartInfoSection CartInfoSection { get; }
	}
}
