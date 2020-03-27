using System.Reflection;
using AutomatedTestingFramework.Core.Enums;

namespace AutomatedTestingFramework.Core.ExecutionEngine
{
	public interface ITestExecutionSubject
	{
		void Attach(ITestObserver observer);
		void Detach(ITestObserver observer);
		void PreTestInit(TestOutcome testOutcome, string testName, MemberInfo memberInfo);
		void PostTestInit(TestOutcome testOutcome, string testName, MemberInfo memberInfo);
		void PreTestCleanup(TestOutcome testOutcome, string testName, MemberInfo memberInfo);
		void PostTestCleanup(TestOutcome testOutcome, string testName, MemberInfo memberInfo);
	}
}