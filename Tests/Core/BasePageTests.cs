using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Driver;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AutomatedTestingFramework.Tests.Core
{
	[TestClass]
	public class BasePageTests : BaseTest<TestPage>
	{
		[TestMethod]
		[TestCategory(TestCategories.Core)]
		public void CallingGoDelegatesCallToDriver()
		{
			// Assemble
			var mockDriver = ResolveMock<IDriver>();
			var url = "/this-is-a-url/";
			Uut.RelativeUrl = url;

			// Act
			Uut.Go();

			// Assert
			mockDriver.Verify(x => x.Navigate(url, true), Times.Once);
		}

		[TestMethod]
		[TestCategory(TestCategories.Core)]
		public void WhenPageTitleMatchesDriverTitleIsAtReturnsTrue()
		{
			// Assemble
			var mockDriver = ResolveMock<IDriver>();
			var pageTitle = Create<string>();
			mockDriver.Setup(x => x.Title).Returns(pageTitle);
			Uut.Title = pageTitle;

			// Act
			var isAtPage = Uut.IsAt;

			// Assert
			isAtPage.Should().BeTrue();
		}

		[TestMethod]
		[TestCategory(TestCategories.Core)]
		public void WhenPageTitleDoesNotMatchDriverTitleIsAtReturnsFalse()
		{
			// Assemble
			var mockDriver = ResolveMock<IDriver>();
			mockDriver.Setup(x => x.Title).Returns("Title - Of Another Page");
			Uut.Title = "Title - Of Page";

			// Act
			var isAtPage = Uut.IsAt;

			// Assert
			isAtPage.Should().BeFalse();
		}
	}

	public class TestPage : BasePage
	{
		public TestPage(IDriver driver, IPageFactory pageFactory) : base(driver, pageFactory)
		{}
	}
}