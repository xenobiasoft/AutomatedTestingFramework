using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Core.Elements;

namespace Bellatrix.PageModels.Sections
{
	public class MainMenuSection
	{
		private readonly IDriver _driver;

		public MainMenuSection(IDriver driver)
		{
			_driver = driver;
		}

		private IAnchor HomeLink => _driver.Find<IAnchor>(By.LinkText("Home"));
		private IAnchor BlogLink => _driver.Find<IAnchor>(By.LinkText("Blog"));
		private IAnchor CartLink => _driver.Find<IAnchor>(By.LinkText("Cart"));
		private IAnchor CheckoutLink => _driver.Find<IAnchor>(By.LinkText("Checkout"));
		private IAnchor MyAccountLink => _driver.Find<IAnchor>(By.LinkText("My Account"));
		private IAnchor PromotionsLink => _driver.Find<IAnchor>(By.LinkText("Promotions"));

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