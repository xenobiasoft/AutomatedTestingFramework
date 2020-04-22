using AutomatedTestingFramework.Selenium.Attributes;
using AutomatedTestingFramework.Selenium.BehaviorObserver;
using AutomatedTestingFramework.Selenium.Drivers;
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

		private static readonly ITestExecutionSubject CurrentTestExecutionSubject;

		static BaseTest()
		{
			CurrentTestExecutionSubject = new UnitTestExecutionSubject();
			Driver = WebDriverFactory.Instance;
			new BrowserLaunchTestBehaviorObserver(CurrentTestExecutionSubject, Driver);
		}

		public TestContext TestContext => TestContext.CurrentContext;

		public string TestName => TestContext.Test.Name;

		[SetUp]
		public void BaseSetup()
		{
			var memberInfo = GetType().GetMethod(TestContext.Test.MethodName);
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
