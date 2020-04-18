namespace AutomatedTestingFramework.Selenium.Interfaces.Elements
{
	public interface IContentElement : IElement
	{
		bool IsEnabled { get; }
		void Hover();
		void Focus();
	}
}