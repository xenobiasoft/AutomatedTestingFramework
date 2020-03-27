using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Controls;

namespace AutomatedTestingFramework.Selenium.Controls
{
	public abstract class Element : IElement
	{
		public abstract By By { get; }
		public abstract void Click();
		public abstract string CssClass { get; }
		public abstract bool? Displayed { get; }
		public abstract bool? Enabled { get; }
		public abstract string GetAttribute(string attributeName);
		public abstract int? Height { get; }
		public abstract string Text { get; }
		public abstract void TypeText(string text);
		public abstract int? Width { get; }
	}
}
