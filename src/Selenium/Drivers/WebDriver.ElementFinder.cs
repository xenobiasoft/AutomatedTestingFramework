using System;
using System.Collections.Generic;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;
using AutomatedTestingFramework.Selenium.Services;

namespace AutomatedTestingFramework.Selenium.Drivers
{
	public partial class WebDriver : Driver, IElementFinder
	{
		protected IElementFinderService ElementFinderService { get; }

		public override TElement Find<TElement>(By by)
		{
			try
			{
				return ElementFinderService.Find<TElement>(_driver, by);
			}
			catch (Exception ex)
			{
				ExceptionAnalyzer.Analyze(ex, this);
				throw;
			}
		}

		public override IEnumerable<TElement> FindAll<TElement>(By by)
		{
			try
			{
				return ElementFinderService.FindAll<TElement>(_driver, by);
			}
			catch (Exception ex)
			{
				ExceptionAnalyzer.Analyze(ex, this);
				throw;
			}
		}

		public override bool IsElementPresent(By by)
		{
			try
			{
				return ElementFinderService.IsElementPresent(_driver, by);
			}
			catch (Exception ex)
			{
				ExceptionAnalyzer.Analyze(ex, this);
				throw;
			}
		}
	}
}