namespace AutomatedTestingFramework.Core.Elements
{
	public interface ICheckbox : IContentElement
	{
		bool IsChecked { get; }
		void Check();
		void Uncheck();
	}
}