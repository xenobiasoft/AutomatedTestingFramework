﻿using AutomatedTestingFramework.Selenium.Interfaces.Elements;

namespace AutomatedTestingFramework.Selenium.Elements
{
	public abstract class Element : IElement
	{
		public abstract By By { get; }
		public abstract string CssClass { get; }
		public abstract bool? Displayed { get; }
		public abstract bool? Enabled { get; }
		public abstract string GetAttribute(string attributeName);
		public abstract int? Height { get; }
		public abstract int? Width { get; }
		public abstract void Click();
		public abstract void Focus();
		public abstract void Hover();
	}
}
