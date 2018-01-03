using AutomatedTestingFramework.Core.Driver;

namespace AutomatedTestingFramework.Core
{
	public abstract class BasePage : PartialPage
	{
		protected BasePage(IDriver driver, IPageFactory pageFactory)
			: base(driver, pageFactory)
		{}

		public void Go()
		{
			Driver.Navigate(RelativeUrl);
		}

		public bool IsAt => Driver.Title == Title;
		public virtual string RelativeUrl { get; set; }
		public virtual string Title { get; set; }
	}
}