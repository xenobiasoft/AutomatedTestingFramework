using AutomatedTestingFramework.Core.Controls;

namespace AutomatedTestingFramework.Core.Driver
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
		void TakeScreenShot();
		void WaitForAjax();
		void WaitForPageToLoad();

		string Source { get; }
	}
}