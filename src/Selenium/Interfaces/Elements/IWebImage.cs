namespace AutomatedTestingFramework.Selenium.Interfaces.Elements
{
	public interface IWebImage : IContentElement
	{
		string AltText { get; }
		string Src { get; }
	}
}