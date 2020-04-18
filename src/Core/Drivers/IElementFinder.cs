﻿using System.Collections.Generic;
using AutomatedTestingFramework.Core.Elements;

namespace AutomatedTestingFramework.Core.Drivers
{
	public interface IElementFinder
	{
		TElement Find<TElement>(By by) where TElement : class, IElement;
		IEnumerable<TElement> FindAll<TElement>(By by) where TElement : class, IElement;
		bool IsElementPresent(By by);
		TElement WaitAndFindElement<TElement>(By by) where TElement : class, IElement;
		IElement WaitAndFindElement(By by);
		void WaitForElementToExist(By by);
		void WaitForElementToBeClickable(By by);
	}
}