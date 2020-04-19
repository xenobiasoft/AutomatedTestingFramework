using AutomatedTestingFramework.Selenium.BehaviorObserver;

namespace AutomatedTestingFramework.Selenium.Interfaces
{
	public interface ITestObserver
	{
		void PreTestInit(object sender, TestExecutionEventArgs e);
		void PostTestInit(object sender, TestExecutionEventArgs e);
		void PreTestCleanup(object sender, TestExecutionEventArgs e);
		void PostTestCleanup(object sender, TestExecutionEventArgs e);
	}
}