using System.Reflection;

namespace AutomatedTestingFramework.Selenium.New.BehaviorObserver
{
	public interface ITestBehaviorObserver
	{
		void PreTestInit(TestContext context, MemberInfo memberInfo);
		void PostTestInit(TestContext context, MemberInfo memberInfo);
		void PreTestCleanup(TestContext context, MemberInfo memberInfo);
		void PostTestCleanup(TestContext context, MemberInfo memberInfo);
		void TestInitialized(MemberInfo memberInfo);
	}
}