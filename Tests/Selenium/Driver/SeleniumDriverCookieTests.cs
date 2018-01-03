using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Tests.Selenium.Driver
{
	[TestClass]
	public class SeleniumDriverCookieTests : SeleniumDriverTests.WebDriverOptionsTests
	{
		[TestMethod]
		[TestCategory(TestCategories.Selenium)]
		public void GetCookieCallsGetCookieNameOnCookieJar()
		{
			// Assemble
			var expectedCookieValue = Create<string>();
			var cookieName = Create<string>();
			var cookie = new Cookie(cookieName, expectedCookieValue);

			ResolveMock<ICookieJar>().Setup(x => x.GetCookieNamed(It.IsAny<string>())).Returns(cookie);

			// Act
			var actualCookieValue = Uut.GetCookie(Create<string>(), cookieName);

			// Assert
			actualCookieValue.Should().Be(expectedCookieValue);
		}

		[TestMethod]
		public void AddCookieAddsCookieToCookieJar()
		{
			// Assemble

			// Act
			Uut.AddCookie(Create<string>(), Create<string>(), Create<string>());

			// Assert
			ResolveMock<ICookieJar>().Verify(x => x.AddCookie(It.IsAny<Cookie>()), Times.Once);
		}

		[TestMethod]
		public void DeleteCookieDelegatesCallToCookieJar()
		{
			// Assemble
			var cookieName = Create<string>();

			// Act
			Uut.DeleteCookie(cookieName);

			// Assert
			ResolveMock<ICookieJar>().Verify(x => x.DeleteCookieNamed(cookieName), Times.Once);
		}

		[TestMethod]
		public void ClearAllCookiesDelegatesCallToCookieJar()
		{
			// Assemble

			// Act
			Uut.ClearAllCookies();

			// Assert
			ResolveMock<ICookieJar>().Verify(x => x.DeleteAllCookies(), Times.Once);
		}

		[TestInitialize]
		public override void TestInit()
		{
			base.TestInit();

			ResolveMock<IOptions>().Setup(x => x.Cookies).Returns(ResolveMock<ICookieJar>().Object);
		}
	}
}