using System.Collections.Generic;
using System.Reflection;

namespace AutomatedTestingFramework.Selenium.New.BehaviorObserver
{
	public class NUnitTestExecutionSubject : ITestExecutionSubject
	{
		private readonly List<ITestBehaviorObserver> _testBehaviourObservers;

		public NUnitTestExecutionSubject()
		{
			_testBehaviourObservers = new List<ITestBehaviorObserver>();
		}

		public void Attach(ITestBehaviorObserver observer)
		{
			_testBehaviourObservers.Add(observer);
		}

		public void Detach(ITestBehaviorObserver observer)
		{
			_testBehaviourObservers.Remove(observer);
		}

		public void PreTestInit(TestContext context, MemberInfo memberInfo)
		{
			_testBehaviourObservers.ForEach(x => x.PreTestInit(context, memberInfo));
		}

		public void PostTestInit(TestContext context, MemberInfo memberInfo)
		{
			_testBehaviourObservers.ForEach(x => x.PostTestInit(context, memberInfo));
		}

		public void PreTestCleanup(TestContext context, MemberInfo memberInfo)
		{
			_testBehaviourObservers.ForEach(x => x.PreTestCleanup(context, memberInfo));
		}

		public void PostTestCleanup(TestContext context, MemberInfo memberInfo)
		{
			_testBehaviourObservers.ForEach(x => x.PostTestCleanup(context, memberInfo));
		}

		public void TestInstantiated(MemberInfo memberInfo)
		{
			_testBehaviourObservers.ForEach(x => x.TestInitialized(memberInfo));
		}
	}
}
