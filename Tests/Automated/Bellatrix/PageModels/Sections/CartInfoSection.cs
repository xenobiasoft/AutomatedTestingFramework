using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Core.Elements;

namespace Bellatrix.PageModels.Sections
{
	public class CartInfoSection
	{
		private readonly IDriver _driver;

		public CartInfoSection(IDriver driver)
		{
			_driver = driver;
		}

		private IButton CartIcon => _driver.Find<IButton>(By.CssClass("cart-contents"));
		private IElement CartAmount => _driver.Find<IElement>(By.CssClass("amount"));

		public string GetCurrentAmount()
		{
			return CartAmount.Text;
		}

		public void OpenCart()
		{
			CartIcon.Click();
		}
	}
}
