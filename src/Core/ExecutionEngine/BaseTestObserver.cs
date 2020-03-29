namespace AutomatedTestingFramework.Core.ExecutionEngine
{
	public class BaseTestObserver : ITestObserver
	{
		private readonly ITestExecutionSubject _testExecutionProvider;

		public BaseTestObserver(ITestExecutionSubject testExecutionProvider)
		{
			_testExecutionProvider = testExecutionProvider;
			_testExecutionProvider.Attach(this);
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
