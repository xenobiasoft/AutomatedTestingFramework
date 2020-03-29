namespace AutomatedTestingFramework.Core.Elements
{
	public interface IElement
	{
		By By { get; }
		void Click();
		string CssClass { get; }
		bool? Displayed { get; }
		bool? Enabled { get; }
		string GetAttribute(string attributeName);
		int? Height { get; }
		string Text { get; }
		void TypeText(string text);
		int? Width { get; }
	}
}