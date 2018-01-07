using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Driver;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace AutomatedTestingFramework.Tests.Core
{
	[TestFixture]
	public class BasePageTests : BaseTestByClass<TestPage>
	{
		[Test]
		[Category(TestCategories.Core)]
		public void CallingGoDelegatesCallToDriver()
		{
			// Assemble
			var mockDriver = ResolveMock<IDriver>();
			var url = "/this-is-a-url/";
			Sut.RelativeUrl = url;

			// Act
			Sut.Go();

			// Assert
			mockDriver.Verify(x => x.Navigate(url, true), Times.Once);
		}

		[Test]
		[Category(TestCategories.Core)]
		public void WhenPageTitleMatchesDriverTitleIsAtReturnsTrue()
		{
			// Assemble
			var mockDriver = ResolveMock<IDriver>();
			var pageTitle = Create<string>();
			mockDriver.Setup(x => x.Title).Returns(pageTitle);
			Sut.Title = pageTitle;

			// Act
			var isAtPage = Sut.IsAt;

			// Assert
			isAtPage.Should().BeTrue();
		}

		[Test]
		[Category(TestCategories.Core)]
		public void WhenPageTitleDoesNotMatchDriverTitleIsAtReturnsFalse()
		{
			// Assemble
			var mockDriver = ResolveMock<IDriver>();
			mockDriver.Setup(x => x.Title).Returns("Title - Of Another Page");
			Sut.Title = "Title - Of Page";

			// Act
			var isAtPage = Sut.IsAt;

			// Assert
			isAtPage.Should().BeFalse();
		}
	}

	public class TestPage : NavigatablePage
	{
		public TestPage(IDriver driver) : base(driver)
		{}
	}
}