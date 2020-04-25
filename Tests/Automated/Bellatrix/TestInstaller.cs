using Autofac;
using Bellatrix.Facades;
using Bellatrix.PageModels;

namespace Bellatrix
{
	public class TestInstaller : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(ThisAssembly)
				.Where(x => x.IsAssignableFrom(typeof(EShopPage<>)))
				.AsSelf()
				.InstancePerDependency();
			builder.RegisterAssemblyTypes(ThisAssembly)
				.Where(x => x.IsAssignableFrom(typeof(PurchaseFacade)))
				.AsSelf()
				.InstancePerDependency();
		}
	}
}
