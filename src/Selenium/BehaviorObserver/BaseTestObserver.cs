using AutomatedTestingFramework.Selenium.Interfaces;

namespace AutomatedTestingFramework.Selenium.BehaviorObserver
{
	public class BaseTestObserver : ITestObserver
	{
		public BaseTestObserver(ITestExecutionSubject testExecutionProvider)
		{
			testExecutionProvider.Attach(this);
		}

		public virtual void PreTestInit(object sender, TestExecutionEventArgs e)
		{
		}

		public virtual void PostTestInit(object sender, TestExecutionEventArgs e)
		{
		}

		public virtual void PreTestCleanup(object sender, TestExecutionEventArgs e)
		{
		}

		public virtual void PostTestCleanup(object sender, TestExecutionEventArgs e)
		{
		}
	}
}
