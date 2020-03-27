using Autofac;
using AutomatedTestingFramework.Selenium.Services;

namespace AutomatedTestingFramework.Selenium
{
	public class SeleniumInstaller : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ElementFinderService>().As<IElementFinderService>();
		}
	}
}