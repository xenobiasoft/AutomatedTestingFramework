namespace AutomatedTestingFramework.Selenium.Interfaces.Elements
{
	public interface ITextBox : IElement
	{
		string Text { get; }
		void TypeText(string text);
	}
}