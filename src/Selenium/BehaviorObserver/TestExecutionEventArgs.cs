using System;
using System.Reflection;
using AutomatedTestingFramework.Selenium.Enums;

namespace AutomatedTestingFramework.Selenium.BehaviorObserver
{
	public class TestExecutionEventArgs : EventArgs
	{
		public TestExecutionEventArgs()
		{}

		public TestExecutionEventArgs(TestOutcome testOutcome, string testName, MemberInfo memberInfo)
		{
			MemberInfo = memberInfo;
			TestName = testName;
			TestOutcome = testOutcome;
		}

		public TestExecutionEventArgs(MemberInfo memberInfo)
		{
			MemberInfo = memberInfo;
		}

		public virtual TestOutcome TestOutcome { get; }

		public virtual string TestName { get; }

		public virtual MemberInfo MemberInfo { get; }
	}
}