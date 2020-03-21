using System;
using System.Reflection;
using AutomatedTestingFramework.Core.Enums;

namespace AutomatedTestingFramework.Selenium.New.BehaviorObserver
{
	public class BrowserLaunchTestBehaviorObserver : BaseTestBehaviorObserver
	{
		private readonly Driver.Driver _driver;
		private BrowserConfiguration _currentBrowserConfiguration;
		private BrowserConfiguration _previousBrowserConfiguration;

		public BrowserLaunchTestBehaviorObserver(ITestExecutionSubject testExecutionSubject, Driver.Driver driver) : base(testExecutionSubject)
		{
			_driver = driver;
		}

		public override void PreTestInit(TestContext context, MemberInfo memberInfo)
		{
			_currentBrowserConfiguration = GetBrowserConfiguration(memberInfo);

			var shouldRestartBrowser = ShouldRestartBrowser(_currentBrowserConfiguration);

			if (shouldRestartBrowser)
			{
				RestartBrowser();
			}
			else
			{
				_driver.DeleteAllCookies();
			}

			_previousBrowserConfiguration = _currentBrowserConfiguration;
		}

		public override void PostTestInit(TestContext context, MemberInfo memberInfo)
		{
			if (_currentBrowserConfiguration.BrowserBehavior == BrowserBehavior.RestartOnFail && context.TestOutcome.Equals(TestOutcome.Failed))
			{
				RestartBrowser();
			}
		}

		private void RestartBrowser()
		{
			_driver.Quit();
			_driver.Start(_currentBrowserConfiguration.Browser);
		}

		private bool ShouldRestartBrowser(BrowserConfiguration browserConfiguration)
		{
			if (_previousBrowserConfiguration == null)
			{
				return true;
			}

			return browserConfiguration.BrowserBehavior == BrowserBehavior.RestartEveryTime ||
				   browserConfiguration.BrowserBehavior == BrowserBehavior.NotSet;
		}

		private BrowserConfiguration GetBrowserConfiguration(MemberInfo memberInfo)
		{
			var result = new BrowserConfiguration();
			var classBrowserType = GetExecutionBrowserClassLevel(memberInfo.DeclaringType);
			var methodBrowserType = GetExecutionBrowserMethodLevel(memberInfo);

			if (methodBrowserType != null)
			{
				result = methodBrowserType;
			}
			else if (classBrowserType != null)
			{
				result = classBrowserType;
			}

			return result;
		}

		private BrowserConfiguration GetExecutionBrowserMethodLevel(MemberInfo memberInfo)
		{
			var executionBrowserAttribute = memberInfo.GetCustomAttribute<ExecutionBrowserAttribute>(true);

			return executionBrowserAttribute?.BrowserConfiguration;
		}

		private BrowserConfiguration GetExecutionBrowserClassLevel(Type type)
		{
			var executionBrowserAttribute = type.GetCustomAttribute<ExecutionBrowserAttribute>(true);

			return executionBrowserAttribute?.BrowserConfiguration;
		}
	}
}
