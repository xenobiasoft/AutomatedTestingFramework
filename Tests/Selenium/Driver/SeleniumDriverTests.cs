using AutomatedTestingFramework.Core.Config;
using AutomatedTestingFramework.Core.Driver;
using AutomatedTestingFramework.Selenium.Driver;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Tests.Selenium.Driver
{
	[TestFixture]
	public class SeleniumDriverTests : AutoMockingFixtureByInterface<WebDriver, IDriver>
	{
		private Mock<IWebDriver> _mockWebDriver;

		[Test]
		[Category(TestCategories.Selenium)]
		public void QuitCallsCloseOnWebDriver()
		{
			// Assemble

			// Act
			Sut.Quit();

			// Assert
			_mockWebDriver.Verify(x => x.Quit(), Times.Once);
		}

		public override void SetUp()
		{
			_mockWebDriver = ResolveMock<IWebDriver>();
			ResolveMock<IAppConfiguration>().SetupGet(x => x.DriverLocation).Returns($"{TestContext.TestDirectory}\\Drivers");
		}

		public override void TearDown()
		{
			_mockWebDriver.Object.Quit();
		}

		[TestFixture]
		public class WebDriverOptionsTests : SeleniumDriverTests
		{
			[Test]
			[Category(TestCategories.Selenium)]
			public void MaximizeBrowserWindowCallsWindowMaximize()
			{
				// Assemble
				var mockWindow = ResolveMock<IWindow>();
				ResolveMock<IOptions>().Setup(x => x.Window).Returns(mockWindow.Object);

				// Act
				Sut.MaximizeBrowserWindow();

				// Assert
				mockWindow.Verify(x => x.Maximize(), Times.Once);
			}

			public override void SetUp()
			{
				base.SetUp();

				ResolveMock<IWebDriver>().Setup(x => x.Manage()).Returns(ResolveMock<IOptions>().Object);
			}
		}
	}
}