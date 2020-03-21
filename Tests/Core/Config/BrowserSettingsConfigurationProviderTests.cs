using AutomatedTestingFramework.Core.Config;
using AutomatedTestingFramework.Core.Enums;
using FluentAssertions;
using NUnit.Framework;

namespace AutomatedTestingFramework.Tests.Core.Config
{
	[TestFixture()]
	public class BrowserSettingsConfigurationProviderTests : AutoMockingFixtureByClass<BrowserSettingsConfigurationProvider>
	{
		[Test]
		[Category(TestCategories.Core)]
		public void MyTestMethod()
		{
			// Assemble
			var expectedBrowserType = Browser.Chrome;
			var expectedDriverLocation = @"Drivers\";
			var expectedImplicitWaitTimeout = 8;
			var expectedPageLoadTimeout = 10;
			var expectedScriptTimeout = 10;

			// Act
			var actual = BrowserSettingsConfigurationProvider.GetSettings();

			// Assert
			actual.DefaultBrowser.Should().Be(expectedBrowserType);
			actual.DriverLocation.Should().Be(expectedDriverLocation);
			actual.ImplicitWaitTimeout.Should().Be(expectedImplicitWaitTimeout);
			actual.PageLoadTimeout.Should().Be(expectedPageLoadTimeout);
			actual.ScriptTimeout.Should().Be(expectedScriptTimeout);
		}
	}
}