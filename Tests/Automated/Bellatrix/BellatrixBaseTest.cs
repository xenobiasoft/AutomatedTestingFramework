using Autofac;
using AutomatedTestingFramework.NUnit;
using AutomatedTestingFramework.Selenium;
using AutomatedTestingFramework.Selenium.Attributes;
using AutomatedTestingFramework.Selenium.Enums;
using AutomatedTestingFramework.Selenium.Interfaces.DI;
using NUnit.Framework;

namespace Bellatrix
{
	[TestFixture]
	[ExecutionBrowser(Browser.Chrome, BrowserBehavior.ReuseIfStarted)]
	public class BellatrixBaseTest : BaseTest
	{
		private IContainerBuilder _container;

		protected override void RegisterDIModules()
		{
			_container = Container
				.Instance
				.InstallModule(new TestInstaller())
				.Build();
		}

		protected override ILifetimeScope GetLifetimeScope()
		{
			return _container.CreateScope();
		}

		public override void OneTimeTearDown()
		{
			_container.Dispose();
		}
	}
}
