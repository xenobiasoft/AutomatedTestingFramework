using System;
using System.Collections.Generic;
using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Drivers;
using AutomatedTestingFramework.Core.Elements;
using AutomatedTestingFramework.Selenium.Services;

namespace AutomatedTestingFramework.Selenium.Drivers
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

		public override TElement WaitAndFindElement<TElement>(By by)
		{
			var element = Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by.ToSeleniumBy()));

			return ElementFinderService.ResolveElement<TElement>(_driver, element, by);
		}

		public override IElement WaitAndFindElement(By by)
		{
			return WaitAndFindElement<IElement>(by);
		}
	}
}