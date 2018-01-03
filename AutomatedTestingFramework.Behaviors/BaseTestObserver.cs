using AutomatedTestingFramework.Core.ExecutionEngine;

namespace AutomatedTestingFramework.Behaviors
{
	public abstract class BaseTestObserver : ITestObserver
	{
		public virtual void PreTestInit(object sender, TestExecutionEventArgs e) {}

		public virtual void PostTestInit(object sender, TestExecutionEventArgs e) {}

		public virtual void PreTestCleanup(object sender, TestExecutionEventArgs e) {}

		public virtual void PostTestCleanup(object sender, TestExecutionEventArgs e) {}
	}
}