using AutomatedTestingFramework.Core.Drivers;

namespace Bellatrix.PageModels
{
	public abstract class NavigatableEShopPage : EShopPage
	{
		protected NavigatableEShopPage(IDriver driver) : base(driver)
		{
		}

		protected abstract string Url { get; }

		protected abstract void WaitForPageLoad();

		public void Open()
		{
			Driver.GoToUrl(Url);
			WaitForPageLoad();
		}
	}
}
