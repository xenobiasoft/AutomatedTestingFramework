namespace AutomatedTestingFramework.Selenium.Interfaces.Elements
{
	public interface ICheckbox : IContentElement
	{
		bool IsChecked { get; }
		void Check();
		void Uncheck();
	}
}