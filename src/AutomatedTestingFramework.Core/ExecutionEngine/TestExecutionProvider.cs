using System;
using System.Reflection;
using AutomatedTestingFramework.Core.Enums;

namespace AutomatedTestingFramework.Core.ExecutionEngine
{
	public class TestExecutionProvider : ITestExecutionProvider
	{
		private event EventHandler<TestExecutionEventArgs> PreTestInitEvent;
		private event EventHandler<TestExecutionEventArgs> PostTestInitEvent;
		private event EventHandler<TestExecutionEventArgs> PreTestCleanupEvent;
		private event EventHandler<TestExecutionEventArgs> PostTestCleanupEvent;

		public void Subscribe(ITestObserver observer)
		{
			PreTestInitEvent += observer.PreTestInit;
			PostTestInitEvent += observer.PostTestInit;
			PreTestCleanupEvent += observer.PreTestCleanup;
			PostTestCleanupEvent += observer.PostTestCleanup;
		}

		public void Unsubscribe(ITestObserver observer)
		{
			PreTestInitEvent -= observer.PreTestInit;
			PostTestInitEvent -= observer.PostTestInit;
			PreTestCleanupEvent -= observer.PreTestCleanup;
			PostTestCleanupEvent -= observer.PostTestCleanup;
		}

		public void PreTestInit(TestOutcome testOutcome, string testName, MemberInfo memberInfo)
		{
			RaiseTestEvent(PreTestInitEvent, testOutcome, testName, memberInfo);
		}

		public void PostTestInit(TestOutcome testOutcome, string testName, MemberInfo memberInfo)
		{
			RaiseTestEvent(PostTestInitEvent, testOutcome, testName, memberInfo);
		}

		public void PreTestCleanup(TestOutcome testOutcome, string testName, MemberInfo memberInfo)
		{
			RaiseTestEvent(PreTestCleanupEvent, testOutcome, testName, memberInfo);
		}

		public void PostTestCleanup(TestOutcome testOutcome, string testName, MemberInfo memberInfo)
		{
			RaiseTestEvent(PostTestCleanupEvent, testOutcome, testName, memberInfo);
		}

		private void RaiseTestEvent(EventHandler<TestExecutionEventArgs> eventHandler, TestOutcome testOutcome, string testName, MemberInfo memberInfo)
		{
			eventHandler?.Invoke(this, new TestExecutionEventArgs(testOutcome, testName, memberInfo));
		}
	}
}