using Autofac.Core;

namespace AutomatedTestingFramework.Selenium.Interfaces.DI
{
	public interface IModuleRegistrator
	{
		IModuleRegistrator InstallModule(IModule module);
		IContainerBuilder Build();
	}
}