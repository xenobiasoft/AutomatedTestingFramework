using System;
using System.Collections.Generic;
using System.Linq;
using AutomatedTestingFramework.Core.Controls;
using OpenQA.Selenium;
using By = AutomatedTestingFramework.Core.By;

namespace AutomatedTestingFramework.Selenium.Driver
{
	public class ElementFinderService : IElementFinderService
	{
		private readonly Dictionary<Type, Type> _controlMap;

		public ElementFinderService()
		{
			_controlMap = new Dictionary<Type, Type>();
		}

		public TElement Find<TElement>(ISearchContext searchContext, By by) where TElement : class, IElement
		{
			var element = searchContext.FindElement(by.ToSeleniumBy());

			return ResolveElement<TElement>(searchContext, element);
		}

		public IEnumerable<TElement> FindAll<TElement>(ISearchContext searchContext, By by) where TElement : class, IElement
		{
			var elements = searchContext.FindElements(by.ToSeleniumBy());

			return elements.Select(x => ResolveElement<TElement>(searchContext, x));
		}

		public bool IsElementPresent(ISearchContext searchContext, By by)
		{
			var element = Find<IElement>(searchContext, by);

			return element.IsVisible;
		}

		private TElement ResolveElement<TElement>(ISearchContext searchContext, IWebElement element) where TElement : class, IElement
		{
			var interfaceType = typeof(TElement);
			Type controlType;

			if (_controlMap.ContainsKey(interfaceType))
			{
				controlType = _controlMap[interfaceType];
			}
			else
			{
				controlType = GetType()
						.Assembly
						.GetTypes().First(x => x.GetInterfaces().Any(i => i == interfaceType));

				_controlMap.Add(interfaceType, controlType);
			}

			return (TElement) Activator.CreateInstance(controlType, searchContext as IWebDriver, element, this);
		}
	}
}