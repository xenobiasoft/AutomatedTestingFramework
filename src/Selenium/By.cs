﻿using AutomatedTestingFramework.Selenium.Enums;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;

namespace AutomatedTestingFramework.Selenium
{
	public class By
	{
		public By(SearchType type, string value)
			: this(type, value, null)
		{ }

		public By(SearchType type, string value, IElement parent)
		{
			Type = type;
			Value = value;
			Parent = parent;
		}

		public SearchType Type { get; }

		public IElement Parent { get; }

		public string Value { get; }

		public static By CssClass(string cssClass)
		{
			return new By(SearchType.CssClass, cssClass);
		}

		public static By CssClass(string cssClass, IElement parentElement)
		{
			return new By(SearchType.CssClass, cssClass, parentElement);
		}

		public static By CssClassContaining(string cssClass)
		{
			return new By(SearchType.CssClassContaining, cssClass);
		}

		public static By CssClassContaining(string cssClass, IElement parentElement)
		{
			return new By(SearchType.CssClassContaining, cssClass, parentElement);
		}

		public static By CssSelector(string cssSelector)
		{
			return new By(SearchType.CssSelector, cssSelector);
		}

		public static By CssSelector(string cssSelector, IElement parentElement)
		{
			return new By(SearchType.CssSelector, cssSelector, parentElement);
		}

		public static By Id(string id)
		{
			return new By(SearchType.Id, id);
		}

		public static By Id(string id, IElement parentElement)
		{
			return new By(SearchType.Id, id, parentElement);
		}

		public static By IdContaining(string id)
		{
			return new By(SearchType.IdContaining, id);
		}

		public static By IdContaining(string id, IElement parentElement)
		{
			return new By(SearchType.IdContaining, id, parentElement);
		}

		public static By LinkText(string linkText)
		{
			return new By(SearchType.LinkText, linkText);
		}

		public static By LinkText(string linkText, IElement parentElement)
		{
			return new By(SearchType.LinkText, linkText, parentElement);
		}

		public static By Name(string name)
		{
			return new By(SearchType.Name, name);
		}

		public static By Name(string name, IElement parentElement)
		{
			return new By(SearchType.Name, name, parentElement);
		}

		public static By Tag(string tagName)
		{
			return new By(SearchType.Tag, tagName);
		}

		public static By Tag(string tagName, IElement parentElement)
		{
			return new By(SearchType.Tag, tagName, parentElement);
		}

		public static By XPath(string xpath)
		{
			return new By(SearchType.XPath, xpath);
		}

		public static By XPath(string xpath, IElement parentElement)
		{
			return new By(SearchType.XPath, xpath, parentElement);
		}
	}
}