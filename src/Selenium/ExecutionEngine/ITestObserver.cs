namespace AutomatedTestingFramework.Selenium.ExecutionEngine
{
	public interface ITestObserver
	{
		void PreTestInit(object sender, TestExecutionEventArgs e);
		void PostTestInit(object sender, TestExecutionEventArgs e);
		void PreTestCleanup(object sender, TestExecutionEventArgs e);
		void PostTestCleanup(object sender, TestExecutionEventArgs e);
	}
}