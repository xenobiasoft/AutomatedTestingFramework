using System.Collections.Generic;
using System.Reflection;
using AutomatedTestingFramework.Core.Driver;
using AutomatedTestingFramework.Core.Enums;
using AutomatedTestingFramework.Core.ExecutionEngine;
using NUnit.Framework;

namespace AutomatedTestingFramework.Core
{
	[TestFixture]
	public abstract class BaseTest
	{
		private ITestExecutionProvider _testExecutionProvider;
		private IDriver _driver;

		[SetUp]
		public void TestInit()
		{
			InitializeContainer();

			var memberInfo = GetCurrentExecutionMemberInfo();
			
			SubscribeTestExecutionObservers();
			Driver.MaximizeBrowserWindow();
			TestExecutionProvider.PreTestInit((TestOutcome)TestContext.Result.Outcome.Status, TestName, memberInfo);
			Setup();
			TestExecutionProvider.PostTestInit((TestOutcome)TestContext.Result.Outcome.Status, TestName, memberInfo);
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

		protected virtual void Setup()
		{ }

		[TearDown]
		public void TestCleanup()
		{
			var memberInfo = GetCurrentExecutionMemberInfo();

			TestExecutionProvider.PreTestCleanup((TestOutcome)TestContext.Result.Outcome.Status, TestName, memberInfo);
			Teardown();
			TestExecutionProvider.PostTestCleanup((TestOutcome)TestContext.Result.Outcome.Status, TestName, memberInfo);
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

		protected virtual void Teardown()
		{ }

		[OneTimeTearDown]
		public void ClassCleanup()
		{
			Container.Dispose();
		}


		public TestContext TestContext => TestContext.CurrentContext;

		public string TestName => TestContext.Test.Name;

		public IDriver Driver => _driver ?? ( _driver = Container.Resolve<IDriver>());
		
		private ITestExecutionProvider TestExecutionProvider => _testExecutionProvider ?? (_testExecutionProvider = Container.Resolve<ITestExecutionProvider>());

		protected IResolver Container { get; set; }
	}
}