using AutomatedTestingFramework.Core.Controls;

namespace AutomatedTestingFramework.Core
{
	public static class ElementFinderExtensions
	{
		public static TElement FindByClass<TElement>(this IElementFinder finder, string className)
			where TElement : class, IElement
		{
			return finder.Find<TElement>(By.CssClass(className));
		}

		public static TElement FindByClassContaining<TElement>(this IElementFinder finder, string className)
			where TElement : class, IElement
		{
			return finder.Find<TElement>(By.CssClassContaining(className));
		}

		public static TElement FindByCssSelector<TElement>(this IElementFinder finder, string cssSelector)
			where TElement : class, IElement
		{
			return finder.Find<TElement>(By.CssSelector(cssSelector));
		}

		public static TElement FindById<TElement>(this IElementFinder finder, string id)
			where TElement : class, IElement
		{
			return finder.Find<TElement>(By.Id(id));
		}

		public static TElement FindByIdContaining<TElement>(this IElementFinder finder, string id)
			where TElement : class, IElement
		{
			return finder.Find<TElement>(By.IdContaining(id));
		}

		public static TElement FindByLinkText<TElement>(this IElementFinder finder, string linkText)
			where TElement : class, IElement
		{
			return finder.Find<TElement>(By.LinkText(linkText));
		}

		public static TElement FindByName<TElement>(this IElementFinder finder, string name)
			where TElement : class, IElement
		{
			return finder.Find<TElement>(By.Name(name));
		}

		public static TElement FindByTag<TElement>(this IElementFinder finder, string tagName)
			where TElement : class, IElement
		{
			return finder.Find<TElement>(By.Tag(tagName));
		}

		public static TElement FindByXPath<TElement>(this IElementFinder finder, string xpath)
			where TElement : class, IElement
		{
			return finder.Find<TElement>(By.XPath(xpath));
		}
	}
}