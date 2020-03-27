using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Controls;

namespace AutomatedTestingFramework.Selenium.Controls
{
	public abstract class ElementDecorator : Element
	{
		protected readonly IElement Element;

		protected ElementDecorator(Element element)
		{
			Element = element;
		}

		public override By By => Element?.By;

		public override bool? Displayed => Element?.Displayed;

		public override bool? Enabled => Element?.Enabled;

		public override string Text => Element?.Text;

		public override void Click() => Element?.Click();

		public override string CssClass => Element?.CssClass;

		public override string GetAttribute(string attributeName) => Element?.GetAttribute(attributeName);

		public override int? Height => Element?.Height;

		public override void TypeText(string text) => Element?.TypeText(text);

		public override int? Width => Element?.Width;
	}
}
