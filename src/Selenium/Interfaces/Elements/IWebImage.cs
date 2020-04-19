namespace AutomatedTestingFramework.Selenium.Interfaces.Elements
{
	public interface IWebImage : IElement
	{
		string AltText { get; }
		string Src { get; }
	}
}