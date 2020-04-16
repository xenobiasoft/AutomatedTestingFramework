using AutomatedTestingFramework.Core.Drivers;

namespace Bellatrix.PageModels
{
	public abstract class BasePageModel
	{
		protected readonly IDriver Driver;

		protected BasePageModel(IDriver driver)
		{
			Driver = driver;
		}
	}
}
