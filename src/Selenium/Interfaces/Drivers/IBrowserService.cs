using AutomatedTestingFramework.Selenium.Enums;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;

namespace AutomatedTestingFramework.Selenium.Interfaces.Drivers
{
	public interface IBrowserService
	{
		void ClickBackButton();
		void ClickForwardButton();
		void ClickRefresh();
		IFrame GetFrame(string frameName);
		void MaximizeBrowserWindow();
		void Quit();
		void Start(Browser browser);
		void SwitchToDefault();
		void SwitchToFrame(IFrame frame);


		string Source { get; }
	}
}