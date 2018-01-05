using System.Collections.Generic;
using System.Reflection;
using AutomatedTestingFramework.Core.Driver;
using AutomatedTestingFramework.Core.Enums;
using AutomatedTestingFramework.Core.ExecutionEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomatedTestingFramework.Core
{
	[TestClass]
	public abstract class BaseTest
	{
		private ITestExecutionProvider _testExecutionProvider;
		private IDriver _driver;

		[TestInitialize]
		public void TestInit()
		{
			InitializeContainer();

			var memberInfo = GetCurrentExecutionMemberInfo();
			
			SubscribeTestExecutionObservers();
			Driver.MaximizeBrowserWindow();
			TestExecutionProvider.PreTestInit((TestOutcome)TestContext.CurrentTestOutcome, TestName, memberInfo);
			TestInitialize();
			TestExecutionProvider.PostTestInit((TestOutcome)TestContext.CurrentTestOutcome, TestName, memberInfo);
		}


		protected abstract void InitializeContainer();

		private MemberInfo GetCurrentExecutionMemberInfo() => GetType().GetMethod(TestName);

		private void SubscribeTestExecutionObservers()
		{
			var observers = Container.Resolve<IEnumerable<ITestObserver>>();

			foreach (var observer in observers)
			{
				TestExecutionProvider.Subscribe(observer);
			}
		}

		protected virtual void TestInitialize()
		{ }

		[TestCleanup]
		public void TestCleanup()
		{
			var memberInfo = GetCurrentExecutionMemberInfo();

			TestExecutionProvider.PreTestCleanup((TestOutcome)TestContext.CurrentTestOutcome, TestName, memberInfo);
			TeardownTest();
			TestExecutionProvider.PostTestCleanup((TestOutcome)TestContext.CurrentTestOutcome, TestName, memberInfo);
			UnsubscribeTestExecutionObservers();
			Driver.Dispose();
		}

		private void UnsubscribeTestExecutionObservers()
		{
			var observers = Container.Resolve<IEnumerable<ITestObserver>>();

			foreach (var observer in observers)
			{
				TestExecutionProvider.Unsubscribe(observer);
			}
		}

		protected virtual void TeardownTest()
		{ }

		[ClassCleanup]
		public void ClassCleanup()
		{
			Container.Dispose();
		}


		public TestContext TestContext { get; set; }

		public string TestName => TestContext.TestName;

		public IDriver Driver => _driver ?? ( _driver = Container.Resolve<IDriver>());
		
		private ITestExecutionProvider TestExecutionProvider => _testExecutionProvider ?? (_testExecutionProvider = Container.Resolve<ITestExecutionProvider>());

		protected IResolver Container { get; set; }
	}
}