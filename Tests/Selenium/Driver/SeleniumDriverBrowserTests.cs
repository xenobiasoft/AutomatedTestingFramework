using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Tests.Selenium.Driver
{
	[TestClass]
	public class SeleniumDriverBrowserTests : SeleniumDriverTests
	{
		[TestMethod]
		[TestCategory(TestCategories.Selenium)]
		public void PageSourceReturnsWebDriverSourceProperty()
		{
			// Assemble
			var expectedPageSource = "<html><head></head><body><p>This is the page content!</p></body></html>";
			ResolveMock<IWebDriver>().Setup(x => x.PageSource).Returns(expectedPageSource);

			// Act
			var actualPageSource = Uut.Source;

			// Assert
			actualPageSource.Should().Be(expectedPageSource);
		}

		[TestMethod]
		[TestCategory(TestCategories.Selenium)]
		public void GetFrameByNameReturnsFrameObjectWithMatchingName()
		{
			// Assemble
			var expectedFrameName = Create<string>();

			// Act
			var actualFrame = Uut.GetFrame(expectedFrameName);

			// Assert
			actualFrame.Name.Should().Be(expectedFrameName);
		}

		[TestMethod]
		[TestCategory(TestCategories.Selenium)]
		public void QuitDelegatesCallToWebDriver()
		{
			// Assemble

			// Act
			Uut.Quit();

			// Assert
			ResolveMock<IWebDriver>().Verify(x => x.Quit(), Times.Once);
		}

		[TestClass]
		public class NavigateTests : SeleniumDriverBrowserTests
		{
			[TestMethod]
			[TestCategory(TestCategories.Selenium)]
			public void ClickBackButtonCallsNavigateBack()
			{
				// Assemble
				var mockNavigation = ResolveMock<INavigation>();

				// Act
				Uut.ClickBackButton();

				// Assert
				mockNavigation.Verify(x => x.Back(), Times.Once);
			}

			[TestMethod]
			[TestCategory(TestCategories.Selenium)]
			public void ClickForwardButtonCallsNavigateForward()
			{
				// Assemble
				var mockNavigation = ResolveMock<INavigation>();

				// Act
				Uut.ClickForwardButton();

				// Assert
				mockNavigation.Verify(x => x.Forward(), Times.Once);
			}

			[TestMethod]
			[TestCategory(TestCategories.Selenium)]
			public void ClickRefreshCallsNavigateRefresh()
			{
				// Assemble
				var mockNavigation = ResolveMock<INavigation>();

				// Act
				Uut.ClickRefresh();

				// Assert
				mockNavigation.Verify(x => x.Refresh(), Times.Once);
			}

			[TestInitialize]
			public override void TestInit()
			{
				base.TestInit();

				ResolveMock<IWebDriver>().Setup(x => x.Navigate()).Returns(ResolveMock<INavigation>().Object);
			}
		}

		[TestClass]
		public class TargetLocatorTests : SeleniumDriverTests
		{
			[TestMethod]
			[TestCategory(TestCategories.Selenium)]
			public void SwitchToFrameSwitchesContextToThatFrame()
			{
				// Assemble
				var targetFrame = Uut.GetFrame(Create<string>());

				// Act
				Uut.SwitchToFrame(targetFrame);

				// Assert
				ResolveMock<ITargetLocator>().Verify(x => x.Frame(targetFrame.Name), Times.Once);
			}

			[TestMethod]
			public void SwitchToDefaultCallsDefaultContent()
			{
				// Assemble
				var mockTargetLocator = ResolveMock<ITargetLocator>();

				// Act
				Uut.SwitchToDefault();

				// Assert
				mockTargetLocator.Verify(x => x.DefaultContent(), Times.Once);
			}

			[TestInitialize]
			public override void TestInit()
			{
				base.TestInit();

				ResolveMock<IWebDriver>().Setup(x => x.SwitchTo()).Returns(ResolveMock<ITargetLocator>().Object);
			}
		}
	}
}