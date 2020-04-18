using System.Collections.Generic;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;

namespace AutomatedTestingFramework.Selenium.Interfaces.Drivers
{
	public interface IElementFinder
	{
		TElement Find<TElement>(By by) where TElement : class, IElement;
		IEnumerable<TElement> FindAll<TElement>(By by) where TElement : class, IElement;
		bool IsElementPresent(By by);
	}
}