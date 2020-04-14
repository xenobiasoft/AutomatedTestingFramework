using System;
using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Selenium.Drivers;
using AutomatedTestingFramework.Selenium.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AutomatedTestingFramework.CompositionRoot
{
	public class CompositeRoot : IDisposable
	{
		private readonly ServiceProvider _container;

		public CompositeRoot()
		{
			var services = new ServiceCollection();

			services.AddOptions();

			services.AddSingleton<IDriverFactory, DriverFactory>();
			services.AddScoped<IElementFinderService, ElementFinderService>();
			services.AddTransient<IDriver>(
				c => ActivatorUtilities.CreateInstance<LoggingDriver>(
					c, ActivatorUtilities.CreateInstance<WebDriver>(c)));
			services.AddTransient<IElementFinder>(c => c.GetRequiredService<IDriver>());
			services.AddTransient<INavigationService>(c => c.GetRequiredService<IDriver>());
			services.AddTransient<ICookieService>(c => c.GetRequiredService<IDriver>());
			services.AddTransient<IDialogService>(c => c.GetRequiredService<IDriver>());
			services.AddTransient<IJavascriptInvoker>(c => c.GetRequiredService<IDriver>());
			services.AddTransient<IBrowser>(c => c.GetRequiredService<IDriver>());

			_container = services.BuildServiceProvider(true);
		}

		public IServiceScope CreateScope()
		{
			return _container.CreateScope();
		}

		public void Dispose()
		{
			_container?.Dispose();
		}
	}
}
