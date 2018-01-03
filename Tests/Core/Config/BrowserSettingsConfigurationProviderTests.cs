using AutomatedTestingFramework.Core.Config;
using AutomatedTestingFramework.Core.Enums;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomatedTestingFramework.Tests.Core.Config
{
	[TestClass]
	public class BrowserSettingsConfigurationProviderTests : BaseTest<BrowserSettingsConfigurationProvider>
	{
		[TestMethod]
		[TestCategory(TestCategories.Core)]
		public void MyTestMethod()
		{
			// Assemble
			var expectedBrowserType = BrowserType.PhantomJs;
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