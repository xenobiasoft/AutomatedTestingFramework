namespace AutomatedTestingFramework.Core.Elements
{
	public interface IWebImage : IContentElement
	{
		string AltText { get; }
		string Src { get; }
	}
}