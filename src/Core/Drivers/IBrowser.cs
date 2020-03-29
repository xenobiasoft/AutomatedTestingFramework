using AutomatedTestingFramework.Core.Elements;

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
		void SwitchToDefault();
		void SwitchToFrame(IFrame frame);
		void WaitForAjax();
		void WaitForPageToLoad();

		string Source { get; }
	}
}