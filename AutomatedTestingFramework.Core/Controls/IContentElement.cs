namespace AutomatedTestingFramework.Core.Controls
{
	public interface IContentElement : IElement
	{
		bool IsEnabled { get; }
		void Hover();
		void Focus();
		void TakeScreenshot();
	}
}