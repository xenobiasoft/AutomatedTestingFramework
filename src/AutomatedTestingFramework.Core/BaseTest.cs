using Autofac;
using AutomatedTestingFramework.Core.Driver;
using AutomatedTestingFramework.Core.Enums;
using AutomatedTestingFramework.Core.ExecutionEngine;
using NUnit.Framework;
using System.Collections.Generic;

namespace AutomatedTestingFramework.Core
{
	[TestFixture]
	public abstract class BaseTest
	{
		private IContainer _container;
		private ITestExecutionProvider _testExecutionProvider;
		private IDriver _driver;

		[SetUp]
		public void TestInit()
		{
			_container = InitializeContainer();

			var memberInfo = GetType().GetMethod(TestName);

			SubscribeTestExecutionObservers();
			Driver.MaximizeBrowserWindow();
			TestExecutionProvider.PreTestInit((TestOutcome)TestContext.Result.Outcome.Status, TestName, memberInfo);
			Setup();
			TestExecutionProvider.PostTestInit((TestOutcome)TestContext.Result.Outcome.Status, TestName, memberInfo);
		}

		[TearDown]
		public void TestCleanup()
		{
			var memberInfo = GetType().GetMethod(TestName);

			TestExecutionProvider.PreTestCleanup((TestOutcome)TestContext.Result.Outcome.Status, TestName, memberInfo);
			Teardown();
			TestExecutionProvider.PostTestCleanup((TestOutcome)TestContext.Result.Outcome.Status, TestName, memberInfo);
			UnsubscribeTestExecutionObservers();
			Driver.Dispose();
		}

		[OneTimeTearDown]
		public void ClassCleanup()
		{
			_container.Dispose();
		}

		private void SubscribeTestExecutionObservers()
		{
			var observers = _container.Resolve<IEnumerable<ITestObserver>>();

			foreach (var observer in observers)
			{
				TestExecutionProvider.Subscribe(observer);
			}
		}

		private void UnsubscribeTestExecutionObservers()
		{
			var observers = _container.Resolve<IEnumerable<ITestObserver>>();

			foreach (var observer in observers)
			{
				TestExecutionProvider.Unsubscribe(observer);
			}
		}

		protected abstract IContainer InitializeContainer();

		protected virtual void Setup()
		{ }

		protected virtual void Teardown()
		{ }

		public TestContext TestContext => TestContext.CurrentContext;

		public string TestName => TestContext.Test.Name;

		public IDriver Driver => _driver ?? ( _driver = _container.Resolve<IDriver>());
		
		private ITestExecutionProvider TestExecutionProvider => _testExecutionProvider ?? (_testExecutionProvider = _container.Resolve<ITestExecutionProvider>());
	}
}