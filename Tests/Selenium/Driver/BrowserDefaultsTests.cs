using AutomatedTestingFramework.Core.Config;
using AutomatedTestingFramework.Core.Enums;
using AutomatedTestingFramework.Selenium.Driver;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.PhantomJS;

namespace AutomatedTestingFramework.Tests.Selenium.Driver
{
	[TestClass]
	public class BrowserDefaultsTests : BaseTest<BrowserDefaults>
	{
		private IBrowserSettingsConfiguration _BrowserSettingsConfiguration;

		[TestMethod]
		[TestCategory(TestCategories.Selenium)]
		[TestCategory(TestCategories.Manual)]
		public void GetBrowserReturnsCorrectlyConfiguredBrowser()
		{
			// Assemble

			// Act
			var browser = Uut.DefaultBrowser;

			// Assert
			browser.Should().BeOfType<PhantomJSDriver>();
		}

		[TestMethod]
		[TestCategory(TestCategories.Selenium)]
		[TestCategory(TestCategories.Manual)]
		public void GetImplicitTimeoutValueReturnsCallToBrowserSettingsConfiguration()
		{
			// Assemble

			// Act
			var actualValue = Uut.ImplicitTimeoutValue;

			// Assert
			actualValue.Should().Be(_BrowserSettingsConfiguration.ImplicitWaitTimeout);
		}

		[TestMethod]
		[TestCategory(TestCategories.Selenium)]
		[TestCategory(TestCategories.Manual)]
		public void GetScriptTimeoutValueReturnsCallToBrowserSettingsConfiguration()
		{
			// Assemble

			// Act
			var actualValue = Uut.ScriptTimeoutValue;

			// Assert
			actualValue.Should().Be(_BrowserSettingsConfiguration.ScriptTimeout);
		}

		[TestMethod]
		[TestCategory(TestCategories.Selenium)]
		[TestCategory(TestCategories.Manual)]
		public void GetPageLoadTimeoutValueReturnsCallToBrowserSettingsConfiguration()
		{
			// Assemble

			// Act
			var actualValue = Uut.PageLoadTimeoutValue;

			// Assert
			actualValue.Should().Be(_BrowserSettingsConfiguration.PageLoadTimeout);
		}

		[TestInitialize]
		public void TestInit()
		{
			var mockBrowserSettingsConfig = ResolveMock<IBrowserSettingsConfiguration>();
			
			mockBrowserSettingsConfig.Setup(x => x.DefaultBrowser).Returns(BrowserType.PhantomJs);
			mockBrowserSettingsConfig.Setup(x => x.DriverLocation).Returns(@"Drivers\");
			mockBrowserSettingsConfig.Setup(x => x.ImplicitWaitTimeout).Returns(5);
			mockBrowserSettingsConfig.Setup(x => x.ScriptTimeout).Returns(8);
			mockBrowserSettingsConfig.Setup(x => x.PageLoadTimeout).Returns(13);

			_BrowserSettingsConfiguration = mockBrowserSettingsConfig.Object;
		}

		[TestCleanup]
		public void TestCleanup()
		{
			Uut.DefaultBrowser.Dispose();
		}
	}
}