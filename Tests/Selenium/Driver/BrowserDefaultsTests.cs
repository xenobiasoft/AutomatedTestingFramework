using System.IO;
using AutomatedTestingFramework.Core.Config;
using AutomatedTestingFramework.Core.Enums;
using AutomatedTestingFramework.Selenium.Driver;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace AutomatedTestingFramework.Tests.Selenium.Driver
{
	[TestFixture]
	public class BrowserDefaultsTests : AutoMockingFixtureByInterface<BrowserDefaults, IBrowserDefaults>
	{
		private IBrowserSettingsConfiguration _browserSettingsConfiguration;

		[Test]
		[Category(TestCategories.Selenium)]
		public void GetBrowserReturnsCorrectlyConfiguredBrowser()
		{
			// Assemble

			// Act
			var browser = Sut.DefaultBrowser;

			// Assert
			browser.Should().BeOfType<ChromeDriver>();
		}

		[Test]
		[Category(TestCategories.Selenium)]
		public void GetImplicitTimeoutValueReturnsCallToBrowserSettingsConfiguration()
		{
			// Assemble

			// Act
			var actualValue = Sut.ImplicitTimeoutValue;

			// Assert
			actualValue.Should().Be(_browserSettingsConfiguration.ImplicitWaitTimeout);
		}

		[Test]
		[Category(TestCategories.Selenium)]
		public void GetScriptTimeoutValueReturnsCallToBrowserSettingsConfiguration()
		{
			// Assemble

			// Act
			var actualValue = Sut.ScriptTimeoutValue;

			// Assert
			actualValue.Should().Be(_browserSettingsConfiguration.ScriptTimeout);
		}

		[Test]
		[Category(TestCategories.Selenium)]
		public void GetPageLoadTimeoutValueReturnsCallToBrowserSettingsConfiguration()
		{
			// Assemble

			// Act
			var actualValue = Sut.PageLoadTimeoutValue;

			// Assert
			actualValue.Should().Be(_browserSettingsConfiguration.PageLoadTimeout);
		}

		public override void SetUp()
		{
			var mockBrowserSettingsConfig = ResolveMock<IBrowserSettingsConfiguration>();

			mockBrowserSettingsConfig.Setup(x => x.DefaultBrowser).Returns(BrowserType.Chrome);
			mockBrowserSettingsConfig.Setup(x => x.DriverLocation).Returns(Path.Combine(TestContext.TestDirectory, "Drivers"));
			mockBrowserSettingsConfig.Setup(x => x.ImplicitWaitTimeout).Returns(5);
			mockBrowserSettingsConfig.Setup(x => x.ScriptTimeout).Returns(8);
			mockBrowserSettingsConfig.Setup(x => x.PageLoadTimeout).Returns(13);

			_browserSettingsConfiguration = mockBrowserSettingsConfig.Object;
		}

		[TearDown]
		public void TestCleanup()
		{
			Sut.DefaultBrowser.Dispose();
		}
	}
}