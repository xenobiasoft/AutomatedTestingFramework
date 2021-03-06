﻿using System.Collections.Generic;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.Interfaces.Elements
{
	public interface IElementFinderService
	{
		TElement Find<TElement>(ISearchContext searchContext, By by) where TElement : class, IElement;
		IEnumerable<TElement> FindAll<TElement>(ISearchContext searchContext, By by) where TElement : class, IElement;
		bool IsElementPresent(ISearchContext searchContext, By by);
		TElement ResolveElement<TElement>(ISearchContext searchContext, IWebElement element, By by)
			where TElement : class, IElement;
	}
}