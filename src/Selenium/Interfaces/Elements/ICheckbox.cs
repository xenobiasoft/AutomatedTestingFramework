namespace AutomatedTestingFramework.Selenium.Interfaces.Elements
{
	public interface ICheckbox : IElement
	{
		bool IsChecked { get; }
		void Check();
		void Uncheck();
	}
}