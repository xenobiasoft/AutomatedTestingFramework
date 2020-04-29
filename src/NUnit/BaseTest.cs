using System.Collections.Generic;
using Autofac;
using AutomatedTestingFramework.Selenium.Enums;
using AutomatedTestingFramework.Selenium.Interfaces;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;
using NUnit.Framework;

namespace AutomatedTestingFramework.NUnit
{
	[TestFixture]
	public abstract class BaseTest
	{
		private IDriver _driver;
		private ITestExecutionSubject _currentTestExecutionSubject;
		private ILifetimeScope _scope;

		public TestContext TestContext => TestContext.CurrentContext;

		public string TestName => TestContext.Test.Name;

		protected TPage GetPage<TPage>() => _scope.Resolve<TPage>();

		protected abstract void RegisterDIModules();

		protected abstract ILifetimeScope GetLifetimeScope();

		[SetUp]
		public void BaseSetup()
		{
			var memberInfo = GetType().GetMethod(TestContext.Test.MethodName);
			_currentTestExecutionSubject.PreTestInit(GetTestOutcome(), TestName, memberInfo);
			Setup();
			_currentTestExecutionSubject.PostTestInit(GetTestOutcome(), TestName, memberInfo);
		}

		[TearDown]
		public void BaseTearDown()
		{
			var memberInfo = GetType().GetMethod(TestContext.Test.MethodName);
			_currentTestExecutionSubject.PreTestCleanup(GetTestOutcome(), TestName, memberInfo);
			TearDown();
			_currentTestExecutionSubject.PostTestCleanup(GetTestOutcome(), TestName, memberInfo);
		}

		[OneTimeSetUp]
		public void BaseOneTimeSetup()
		{
			RegisterDIModules();
			_scope = GetLifetimeScope();
			_driver = _scope.Resolve<IDriver>();
			_scope.Resolve<IEnumerable<ITestObserver>>();
			_currentTestExecutionSubject = _scope.Resolve<ITestExecutionSubject>();
			OneTimeSetup();
		}

		[OneTimeTearDown]
		public void BaseOneTimeTearDown()
		{
			_driver?.Quit();
			_scope.Dispose();
			OneTimeTearDown();
		}

		public virtual void Setup()
		{ }

		public virtual void OneTimeSetup()
		{ }

		public virtual void TearDown()
		{ }

		public virtual void OneTimeTearDown()
		{ }

		private TestOutcome GetTestOutcome()
		{
			return (TestOutcome)TestContext.Result.Outcome.Status;
		}
	}
}
