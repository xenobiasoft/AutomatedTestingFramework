using System.Collections.Generic;
using Autofac;
using AutomatedTestingFramework.Selenium.Attributes;
using AutomatedTestingFramework.Selenium.Enums;
using AutomatedTestingFramework.Selenium.Interfaces;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;
using NUnit.Framework;

namespace Bellatrix
{
	[TestFixture]
	[ExecutionBrowser(Browser.Chrome, BrowserBehavior.ReuseIfStarted)]
	public class BaseTest
	{
		public static readonly IDriver Driver;

		private static readonly ITestExecutionSubject _currentTestExecutionSubject;
		private static readonly ILifetimeScope _scope;

		static BaseTest()
		{
			_scope = Container.Root.BeginLifetimeScope();
			Driver = _scope.Resolve<IDriver>();
			_scope.Resolve<IEnumerable<ITestObserver>>();
			_currentTestExecutionSubject = _scope.Resolve<ITestExecutionSubject>();
		}

		public TestContext TestContext => TestContext.CurrentContext;

		public string TestName => TestContext.Test.Name;

		protected TPage GetPage<TPage>() => _scope.Resolve<TPage>();

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
			var memberInfo = GetType().GetMethod(TestContext.Test.Name);
			_currentTestExecutionSubject.PreTestCleanup(GetTestOutcome(), TestName, memberInfo);
			TearDown();
			_currentTestExecutionSubject.PostTestCleanup(GetTestOutcome(), TestName, memberInfo);
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			Driver?.Quit();
			_scope.Dispose();
		}

		public virtual void Setup()
		{ }

		public virtual void TearDown()
		{ }

		private TestOutcome GetTestOutcome()
		{
			return (TestOutcome)TestContext.Result.Outcome.Status;
		}
	}
}
