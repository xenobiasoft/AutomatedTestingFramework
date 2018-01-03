using System.Collections.Generic;
using AutomatedTestingFramework.Core.Controls;

namespace AutomatedTestingFramework.Core
{
	public interface IElementFinder
	{
		TElement Find<TElement>(By by) where TElement : class, IElement;

		IEnumerable<TElement> FindAll<TElement>(By by) where TElement : class, IElement;

		bool IsElementPresent(By by);
	}
}