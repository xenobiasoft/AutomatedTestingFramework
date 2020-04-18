namespace AutomatedTestingFramework.Selenium.Interfaces.Drivers
{
	public interface IElementWaitService
	{
		void WaitForAjax();
		void WaitForElementToBeClickable(By by);
		void WaitForElementToBeVisible(By by);
		void WaitForElementToExist(By by);
		void WaitForPageToLoad();
	}
}