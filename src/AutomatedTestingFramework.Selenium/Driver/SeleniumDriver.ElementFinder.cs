using System;
using System.Collections.Generic;
using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Controls;

namespace AutomatedTestingFramework.Selenium.Driver
{
	public partial class SeleniumDriver : IElementFinder
	{
		protected IElementFinderService ElementFinderService { get; }

		public TElement Find<TElement>(By by) where TElement : class, IElement
		{
			try
			{
				return ElementFinderService.Find<TElement>(_Driver, by);
			}
			catch (Exception ex)
			{
				ExceptionAnalyzer.Analyze(ex, this);
				throw;
			}
		}

		public IEnumerable<TElement> FindAll<TElement>(By by) where TElement : class, IElement
		{
			try
			{
				return ElementFinderService.FindAll<TElement>(_Driver, by);
			}
			catch (Exception ex)
			{
				ExceptionAnalyzer.Analyze(ex, this);
				throw;
			}
		}

		public bool IsElementPresent(By by)
		{
			try
			{
				return ElementFinderService.IsElementPresent(_Driver, by);
			}
			catch (Exception ex)
			{
				ExceptionAnalyzer.Analyze(ex, this);
				throw;
			}
		}
	}
}