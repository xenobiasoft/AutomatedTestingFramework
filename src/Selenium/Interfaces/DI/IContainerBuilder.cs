using System;
using Autofac;

namespace AutomatedTestingFramework.Selenium.Interfaces.DI
{
	public interface IContainerBuilder : IDisposable
	{
		ILifetimeScope CreateScope();
	}
}