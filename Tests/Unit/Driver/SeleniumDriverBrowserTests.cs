using Moq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.UnitTests.Driver
{
	[TestFixture]
	public class SeleniumDriverBrowserTests : SeleniumDriverTests
	{
		[Test]
		public void PageSourceReturnsWebDriverSourceProperty()
		{
			// Assemble
			var expectedPageSource = "<html xmlns=\"http://www.w3.org/1999/xhtml\"><head></head><body><p>This is the page content!</p></body></html>";
			ResolveMock<IWebDriver>().Setup(x => x.PageSource).Returns(expectedPageSource);

			// Act
			var actualPageSource = Sut.Source;

			// Assert
			Assert.That(actualPageSource, Is.EqualTo(expectedPageSource));
		}

		[Test]
		public void GetFrameByNameReturnsFrameObjectWithMatchingName()
		{
			// Assemble
			var expectedFrameName = Create<string>();

			// Act
			var actualFrame = Sut.GetFrame(expectedFrameName);

			// Assert
			Assert.That(actualFrame.Name, Is.EqualTo(expectedFrameName));
		}

		[Test]
		public void QuitDelegatesCallToWebDriver()
		{
			// Assemble

			// Act
			Sut.Quit();

			// Assert
			ResolveMock<IWebDriver>().Verify(x => x.Quit(), Times.Once);
		}

		[TestFixture]
		public class NavigateTests : SeleniumDriverBrowserTests
		{
			[Test]
			public void ClickBackButtonCallsNavigateBack()
			{
				// Assemble
				var mockNavigation = ResolveMock<INavigation>();

				// Act
				Sut.ClickBackButton();

				// Assert
				mockNavigation.Verify(x => x.Back(), Times.Once);
			}

			[Test]
			public void ClickForwardButtonCallsNavigateForward()
			{
				// Assemble
				var mockNavigation = ResolveMock<INavigation>();

				// Act
				Sut.ClickForwardButton();

				// Assert
				mockNavigation.Verify(x => x.Forward(), Times.Once);
			}

			[Test]
			public void ClickRefreshCallsNavigateRefresh()
			{
				// Assemble
				var mockNavigation = ResolveMock<INavigation>();

				// Act
				Sut.ClickRefresh();

				// Assert
				mockNavigation.Verify(x => x.Refresh(), Times.Once);
			}

			public override void SetUp()
			{
				base.SetUp();

				ResolveMock<IWebDriver>().Setup(x => x.Navigate()).Returns(ResolveMock<INavigation>().Object);
			}
		}

		[TestFixture]
		public class TargetLocatorTests : SeleniumDriverTests
		{
			[Test]
			public void SwitchToFrameSwitchesContextToThatFrame()
			{
				// Assemble
				var targetFrame = Sut.GetFrame(Create<string>());

				// Act
				Sut.SwitchToFrame(targetFrame);

				// Assert
				ResolveMock<ITargetLocator>().Verify(x => x.Frame(targetFrame.Name), Times.Once);
			}

			[Test]
			public void SwitchToDefaultCallsDefaultContent()
			{
				// Assemble
				var mockTargetLocator = ResolveMock<ITargetLocator>();

				// Act
				Sut.SwitchToDefault();

				// Assert
				mockTargetLocator.Verify(x => x.DefaultContent(), Times.Once);
			}

			public override void SetUp()
			{
				base.SetUp();

				ResolveMock<IWebDriver>().Setup(x => x.SwitchTo()).Returns(ResolveMock<ITargetLocator>().Object);
			}
		}
	}
}