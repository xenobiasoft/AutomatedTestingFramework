using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Core.Elements;

namespace Bellatrix.PageModels.Sections
{
	public class CartInfoSection
	{
		private readonly IElementFinder _elementFinder;

		public CartInfoSection(IElementFinder elementFinder)
		{
			_elementFinder = elementFinder;
		}

		private IButton CartIcon => _elementFinder.Find<IButton>(By.CssClass("cart-contents"));
		private IElement CartAmount => _elementFinder.Find<IElement>(By.CssClass("amount"));

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
