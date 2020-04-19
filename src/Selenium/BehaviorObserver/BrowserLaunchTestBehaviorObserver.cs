using System;
using System.Reflection;
using AutomatedTestingFramework.Selenium.Attributes;
using AutomatedTestingFramework.Selenium.Enums;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;

namespace AutomatedTestingFramework.Selenium.BehaviorObserver
{
	public class BrowserLaunchTestBehaviorObserver : BaseTestObserver
	{
		private readonly Driver _driver;
		private BrowserConfiguration _currentBrowserConfiguration;
		private BrowserConfiguration _previousBrowserConfiguration;

		public BrowserLaunchTestBehaviorObserver(ITestExecutionSubject testExecutionSubject, Driver driver) : base(testExecutionSubject)
		{
			_driver = driver;
		}

		public override void PreTestInit(object sender, TestExecutionEventArgs e)
		{
			_currentBrowserConfiguration = GetBrowserConfiguration(e.MemberInfo);

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

		public override void PostTestInit(object sender, TestExecutionEventArgs e)
		{
			if (_currentBrowserConfiguration.BrowserBehavior == BrowserBehavior.RestartOnFail && e.TestOutcome.Equals(TestOutcome.Failed))
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
