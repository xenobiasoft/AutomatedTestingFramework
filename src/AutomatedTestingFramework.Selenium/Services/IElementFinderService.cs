using System.Collections.Generic;
using AutomatedTestingFramework.Core.Controls;
using OpenQA.Selenium;
using By = AutomatedTestingFramework.Core.By;

namespace AutomatedTestingFramework.Selenium.Services
{
	public interface IElementFinderService
	{
		TElement Find<TElement>(ISearchContext searchContext, By by) where TElement : class, IElement;
		IEnumerable<TElement> FindAll<TElement>(ISearchContext searchContext, By by) where TElement : class, IElement;
		bool IsElementPresent(ISearchContext searchContext, By by);
	}
}