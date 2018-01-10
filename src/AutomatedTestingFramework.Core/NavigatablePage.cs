using AutomatedTestingFramework.Core.Driver;

namespace AutomatedTestingFramework.Core
{
	public abstract class NavigatablePage<TPage> : BasePage where TPage : BasePage
	{
		protected NavigatablePage(IDriver driver)
			: base(driver)
		{}

		public NavigatablePage<TPage> Go()
		{
			Driver.Navigate(RelativeUrl);

			return this;
		}

		public bool IsAt => Driver.Title == Title;
		public virtual string RelativeUrl { get; set; }
		public virtual string Title { get; set; }
	}
}