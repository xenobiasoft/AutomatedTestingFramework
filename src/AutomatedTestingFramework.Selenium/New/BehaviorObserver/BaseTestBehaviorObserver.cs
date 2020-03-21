using System.Reflection;

namespace AutomatedTestingFramework.Selenium.New.BehaviorObserver
{
	public class BaseTestBehaviorObserver : ITestBehaviorObserver
	{
		private readonly ITestExecutionSubject _testExecutionSubject;

		public BaseTestBehaviorObserver(ITestExecutionSubject testExecutionSubject)
		{
			_testExecutionSubject = testExecutionSubject;
			_testExecutionSubject.Attach(this);
		}

		public virtual void PreTestInit(TestContext context, MemberInfo memberInfo)
		{
		}

		public virtual void PostTestInit(TestContext context, MemberInfo memberInfo)
		{
		}

		public virtual void PreTestCleanup(TestContext context, MemberInfo memberInfo)
		{
		}

		public virtual void PostTestCleanup(TestContext context, MemberInfo memberInfo)
		{
		}

		public virtual void TestInitialized(MemberInfo memberInfo)
		{
		}
	}
}
