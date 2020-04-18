using AutomatedTestingFramework.Selenium.BehaviorObserver;
using AutomatedTestingFramework.Selenium.Drivers;
using AutomatedTestingFramework.Selenium.Enums;
using AutomatedTestingFramework.Selenium.ExecutionEngine;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;
using NUnit.Framework;

namespace Bellatrix
{
	[TestFixture]
	public class BaseTest
	{
		public static readonly IDriver Driver;

		private static readonly ITestExecutionSubject CurrentTestExecutionSubject;

		static BaseTest()
		{
			CurrentTestExecutionSubject = new UnitTestExecutionSubject();

			Driver = LoggingDriver.Instance;
			Driver.Start(Browser.Chrome);
			Driver.MaximizeBrowserWindow();
		}

		public TestContext TestContext => TestContext.CurrentContext;

		public string TestName => TestContext.Test.Name;

		[SetUp]
		public void BaseSetup()
		{
			var memberInfo = GetType().GetMethod(TestContext.Test.Name);
			CurrentTestExecutionSubject.PreTestInit(GetTestOutcome(), TestName, memberInfo);
			Setup();
			CurrentTestExecutionSubject.PostTestInit(GetTestOutcome(), TestName, memberInfo);
		}

		[TearDown]
		public void BaseTearDown()
		{
			var memberInfo = GetType().GetMethod(TestContext.Test.Name);
			CurrentTestExecutionSubject.PreTestCleanup(GetTestOutcome(), TestName, memberInfo);
			TearDown();
			CurrentTestExecutionSubject.PostTestCleanup(GetTestOutcome(), TestName, memberInfo);
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			Driver?.Quit();
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
