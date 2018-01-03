namespace AutomatedTestingFramework.Core.Controls
{
	public interface IWebImage : IContentElement
	{
		string AltText { get; }
		string Src { get; }
	}
}