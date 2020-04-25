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
				.AsClosedTypesOf(typeof(EShopPage<>))
				.AsSelf()
				.InstancePerDependency();
			builder.RegisterAssemblyTypes(ThisAssembly)
				.AssignableTo<PurchaseFacade>()
				.AsSelf()
				.InstancePerDependency();
		}
	}
}
