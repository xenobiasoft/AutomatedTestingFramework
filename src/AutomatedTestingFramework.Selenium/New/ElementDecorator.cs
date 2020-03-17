using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.New
{
	public abstract class ElementDecorator : Element
	{
		protected readonly Element Element;

		protected ElementDecorator(Element element)
		{
			Element = element;
		}

		public override By By => Element?.By;

		public override bool? Displayed => Element?.Displayed;

		public override bool? Enabled => Element?.Enabled;

		public override string Text => Element?.Text;

		public override void Click() => Element?.Click();

		public override string GetAttribute(string attributeName) => Element?.GetAttribute(attributeName);

		public override void TypeText(string text) => Element?.TypeText(text);
	}
}
