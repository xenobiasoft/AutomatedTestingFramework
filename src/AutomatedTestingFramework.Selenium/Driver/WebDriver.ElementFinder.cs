using System;
using System.Collections.Generic;
using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Driver;
using AutomatedTestingFramework.Selenium.Services;

namespace AutomatedTestingFramework.Selenium.Driver
{
	public partial class WebDriver : BaseDriver, IElementFinder
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