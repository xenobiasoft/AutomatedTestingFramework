namespace AutomatedTestingFramework.Core.Controls
{
	public interface IElement : IElementFinder
	{
		void Click();
		string Content { get; }
		string CssClass { get; }
		string GetAttribute(string name);
		bool IsVisible { get; }
		void MouseClick();
		int Width { get; }
		int Height { get; }
	}
}