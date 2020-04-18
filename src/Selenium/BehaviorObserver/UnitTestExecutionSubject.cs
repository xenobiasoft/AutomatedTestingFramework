using System.Collections.Generic;
using System.Reflection;
using AutomatedTestingFramework.Selenium.Enums;
using AutomatedTestingFramework.Selenium.ExecutionEngine;

namespace AutomatedTestingFramework.Selenium.BehaviorObserver
{
	public class UnitTestExecutionSubject : ITestExecutionSubject
	{
		private readonly List<ITestObserver> _testBehaviourObservers;

		public UnitTestExecutionSubject()
		{
			_testBehaviourObservers = new List<ITestObserver>();
		}

		public void Attach(ITestObserver observer)
		{
			_testBehaviourObservers.Add(observer);
		}

		public void Detach(ITestObserver observer)
		{
			_testBehaviourObservers.Remove(observer);
		}

		public void PreTestInit(TestOutcome testOutcome, string testName, MemberInfo memberInfo)
		{
			_testBehaviourObservers.ForEach(x => x.PreTestInit(this, new TestExecutionEventArgs(testOutcome, testName, memberInfo)));
		}

		public void PostTestInit(TestOutcome testOutcome, string testName, MemberInfo memberInfo)
		{
			_testBehaviourObservers.ForEach(x => x.PostTestInit(this, new TestExecutionEventArgs(testOutcome, testName, memberInfo)));
		}

		public void PreTestCleanup(TestOutcome testOutcome, string testName, MemberInfo memberInfo)
		{
			_testBehaviourObservers.ForEach(x => x.PreTestCleanup(this, new TestExecutionEventArgs(testOutcome, testName, memberInfo)));
		}

		public void PostTestCleanup(TestOutcome testOutcome, string testName, MemberInfo memberInfo)
		{
			_testBehaviourObservers.ForEach(x => x.PostTestCleanup(this, new TestExecutionEventArgs(testOutcome, testName, memberInfo)));
		}
	}
}
