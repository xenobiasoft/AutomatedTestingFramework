namespace AutomatedTestingFramework.Selenium.Interfaces.Elements
{
	public interface IElement
	{
		By By { get; }
		string CssClass { get; }
		bool? Displayed { get; }
		bool? Enabled { get; }
		string GetAttribute(string attributeName);
		int? Height { get; }
		int? Width { get; }

		void Click();
		void Hover();
		void Focus();
	}
}