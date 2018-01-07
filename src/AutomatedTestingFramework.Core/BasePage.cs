using AutomatedTestingFramework.Core.Driver;

namespace AutomatedTestingFramework.Core
{
	public abstract class BasePage
	{
		protected BasePage(IDriver driver) => Driver = driver;
		
		protected IDriver Driver { get; }
	}
}