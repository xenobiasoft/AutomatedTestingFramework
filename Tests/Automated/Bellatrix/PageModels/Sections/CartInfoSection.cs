using AutomatedTestingFramework.Selenium;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;

namespace Bellatrix.PageModels.Sections
{
	public class CartInfoSection : EShopPage<CartInfoSection>
	{
		private readonly IElementFinder _elementFinder;

		public CartInfoSection(IElementFinder elementFinder) : base(elementFinder)
		{
			_elementFinder = elementFinder;
		}

		private IButton CartIcon => _elementFinder.Find<IButton>(By.CssClass("cart-contents"));
		private ILabel CartAmount => _elementFinder.Find<ILabel>(By.CssClass("amount"));

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
