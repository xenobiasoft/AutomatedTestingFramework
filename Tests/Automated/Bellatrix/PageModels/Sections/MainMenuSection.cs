using AutomatedTestingFramework.Selenium;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;

namespace Bellatrix.PageModels.Sections
{
	public class MainMenuSection : EShopPage<MainMenuSection>
	{
		private readonly IElementFinder _elementFinder;

		public MainMenuSection(IElementFinder elementFinder) : base(elementFinder)
		{
			_elementFinder = elementFinder;
		}

		private IAnchor HomeLink => _elementFinder.Find<IAnchor>(By.LinkText("Home"));
		private IAnchor BlogLink => _elementFinder.Find<IAnchor>(By.LinkText("Blog"));
		private IAnchor CartLink => _elementFinder.Find<IAnchor>(By.LinkText("Cart"));
		private IAnchor CheckoutLink => _elementFinder.Find<IAnchor>(By.LinkText("Checkout"));
		private IAnchor MyAccountLink => _elementFinder.Find<IAnchor>(By.LinkText("My Account"));
		private IAnchor PromotionsLink => _elementFinder.Find<IAnchor>(By.LinkText("Promotions"));

		public void OpenHomePage()
		{
			HomeLink.Click();
		}

		public void OpenBlogPage()
		{
			BlogLink.Click();
		}

		public void OpenMyAccountPage()
		{
			MyAccountLink.Click();
		}

		public void OpenPromotionsPage()
		{
			PromotionsLink.Click();
		}
	}
}