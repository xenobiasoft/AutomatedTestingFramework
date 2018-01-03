using AutomatedTestingFramework.Selenium.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Tests.Selenium.Driver
{
	[TestClass]
	public class SeleniumDriverTests : BaseTest<SeleniumDriver>
	{
		private Mock<IWebDriver> _mockWebDriver;

		[TestMethod]
		[TestCategory(TestCategories.Selenium)]
		public void DisposeCallsCloseAndDisposeOnWebDriver()
		{
			// Assemble

			// Act
			Uut.Dispose();

			// Assert
			_mockWebDriver.Verify(x => x.Quit(), Times.Once);
			_mockWebDriver.Verify(x => x.Dispose(), Times.Once);
		}

		[TestInitialize]
		public virtual void TestInit()
		{
			_mockWebDriver = ResolveMock<IWebDriver>();
			ResolveMock<IBrowserDefaults>().Setup(x => x.DefaultBrowser).Returns(_mockWebDriver.Object);
		}

		[TestClass]
		public class WebDriverOptionsTests : SeleniumDriverTests
		{
			[TestMethod]
			[TestCategory(TestCategories.Selenium)]
			public void MaximizeBrowserWindowCallsWindowMaximize()
			{
				// Assemble
				var mockWindow = ResolveMock<IWindow>();
				ResolveMock<IOptions>().Setup(x => x.Window).Returns(mockWindow.Object);

				// Act
				Uut.MaximizeBrowserWindow();

				// Assert
				mockWindow.Verify(x => x.Maximize(), Times.Once);
			}

			[TestInitialize]
			public override void TestInit()
			{
				base.TestInit();

				ResolveMock<IWebDriver>().Setup(x => x.Manage()).Returns(ResolveMock<IOptions>().Object);
			}
		}
	}
}