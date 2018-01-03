namespace AutomatedTestingFramework.Core.Controls
{
	public interface ICheckbox : IContentElement
	{
		bool IsChecked { get; }
		void Check();
		void Uncheck();
	}
}