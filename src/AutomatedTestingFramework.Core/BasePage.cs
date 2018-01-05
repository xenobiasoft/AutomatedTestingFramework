using AutomatedTestingFramework.Core.Driver;

namespace AutomatedTestingFramework.Core
{
	public class BasePage
	{
		public BasePage(IDriver driver) => Driver = driver;
		
		protected IDriver Driver { get; }
	}
}