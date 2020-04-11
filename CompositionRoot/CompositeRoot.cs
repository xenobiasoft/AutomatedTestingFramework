using System;
using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Configuration;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Selenium.Drivers;
using AutomatedTestingFramework.Selenium.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AutomatedTestingFramework.CompositionRoot
{
	public class CompositeRoot
	{
		private readonly ServiceProvider _container;

		public CompositeRoot()
		{
			var services = new ServiceCollection();

			services.AddOptions();
			services.Configure<AppSettings>(c => ConfigurationHelper.GetAppSettings(Environment.CurrentDirectory));

			services.AddSingleton(c => c.GetRequiredService<IOptions<AppSettings>>());

			services.AddSingleton<IDriverFactory, DriverFactory>();
			services.AddScoped<IElementFinderService, ElementFinderService>();
			services.AddTransient<WebDriver>();
			services.AddTransient<IDriver>(c => c.GetRequiredService<WebDriver>());
			services.AddTransient<IElementFinder>(c => c.GetRequiredService<WebDriver>());
			services.AddTransient<INavigationService>(c => c.GetRequiredService<WebDriver>());
			services.AddTransient<ICookieService>(c => c.GetRequiredService<WebDriver>());
			services.AddTransient<IDialogService>(c => c.GetRequiredService<WebDriver>());
			services.AddTransient<IJavascriptInvoker>(c => c.GetRequiredService<WebDriver>());
			services.AddTransient<IBrowser>(c => c.GetRequiredService<WebDriver>());

			_container = services.BuildServiceProvider(true);
		}

		public IServiceScope CreateScope()
		{
			return _container.CreateScope();
		}
	}
}
