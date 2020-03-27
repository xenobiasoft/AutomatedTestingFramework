using Moq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Tests.Selenium.Driver
{
	[TestFixture]
	public class SeleniumDriverNavigationServiceTests : SeleniumDriverTests
	{
		[TestFixture]
		public class NavigateTests : SeleniumDriverNavigationServiceTests
		{
			[Test]
			public void DelegatesCallToNavigationGoToUrl()
			{
				// Assemble
				var relativeUrl = "/main/subpage";

				// Act
				Sut.GoToUrl(relativeUrl);

				// Assert
				ResolveMock<INavigation>().Verify(x => x.GoToUrl(It.Is<string>(url => url.EndsWith(relativeUrl))), Times.Once);
			}

			[Test]
			public void UrlDecodesPassedInUrl()
			{
				// Assemble
				var actualUrl = "http%3a%2f%2fwww.microsoft.com";
				var expectedUrl = "http://www.microsoft.com";

				// Act
				Sut.GoToUrl(actualUrl);

				// Assert
				ResolveMock<INavigation>().Verify(x => x.GoToUrl(It.Is<string>(url => url == expectedUrl)), Times.Once);
			}
		}

		public override void SetUp()
		{
			base.SetUp();

			ResolveMock<IWebDriver>().Setup(x => x.Navigate()).Returns(ResolveMock<INavigation>().Object);
		}
	}
}