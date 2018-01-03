using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Tests.Selenium.Driver
{
	[TestClass]
	public class SeleniumDriverNavigationServiceTests : SeleniumDriverTests
	{
		[TestClass]
		public class NavigateTests : SeleniumDriverNavigationServiceTests
		{
			[TestMethod]
			public void DelegatesCallToNavigationGoToUrl()
			{
				// Assemble
				var relativeUrl = "/main/subpage";

				// Act
				Uut.Navigate(relativeUrl);

				// Assert
				ResolveMock<INavigation>().Verify(x => x.GoToUrl(It.Is<string>(url => url.EndsWith(relativeUrl))), Times.Once);
			}

			[TestMethod]
			public void UrlDecodesPassedInUrl()
			{
				// Assemble
				var actualUrl = "http%3a%2f%2fwww.microsoft.com";
				var expectedUrl = "http://www.microsoft.com";

				// Act
				Uut.Navigate(actualUrl);

				// Assert
				ResolveMock<INavigation>().Verify(x => x.GoToUrl(It.Is<string>(url => url == expectedUrl)), Times.Once);
			}
		}

		[TestInitialize]
		public override void TestInit()
		{
			base.TestInit();

			ResolveMock<IWebDriver>().Setup(x => x.Navigate()).Returns(ResolveMock<INavigation>().Object);
		}
	}
}