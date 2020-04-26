namespace AutomatedTestingFramework.Selenium.Interfaces.Drivers
{
	public interface INavigationService
	{
		string Url { get; }
		string Title { get; }

		void GoToUrl(string url);
	}
}