using AutomatedTestingFramework.Core.Elements;
using AutomatedTestingFramework.Core.Enums;

namespace AutomatedTestingFramework.Core.Drivers
{
	public interface IBrowser
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
		void WaitForAjax();
		void WaitForPageToLoad();


		string Source { get; }
	}
}