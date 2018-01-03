using AutomatedTestingFramework.Core.Driver;

namespace AutomatedTestingFramework.Core
{
	public class PartialPage
	{
		public PartialPage(IDriver driver, IPageFactory pageFactory)
		{
			PageFactory = pageFactory;
			Driver = driver;
		}


		protected IDriver Driver { get; set; }
		protected IPageFactory PageFactory { get; set; }
	}
}