using Moq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.UnitTests.Driver
{
	[TestFixture]
	public class SeleniumDriverCookieTests : SeleniumDriverTests.WebDriverOptionsTests
	{
		[Test]
		[Category(TestCategories.Selenium)]
		public void GetCookieCallsGetCookieNameOnCookieJar()
		{
			// Assemble
			var expectedCookieValue = Create<string>();
			var cookieName = Create<string>();
			var cookie = new Cookie(cookieName, expectedCookieValue);

			ResolveMock<ICookieJar>().Setup(x => x.GetCookieNamed(It.IsAny<string>())).Returns(cookie);

			// Act
			var actualCookieValue = Sut.GetCookie(Create<string>(), cookieName);

			// Assert
			Assert.That(actualCookieValue, Is.EqualTo(expectedCookieValue));
		}

		[Test]
		public void AddCookieAddsCookieToCookieJar()
		{
			// Assemble

			// Act
			Sut.AddCookie(Create<string>(), Create<string>(), Create<string>());

			// Assert
			ResolveMock<ICookieJar>().Verify(x => x.AddCookie(It.IsAny<Cookie>()), Times.Once);
		}

		[Test]
		public void DeleteCookieDelegatesCallToCookieJar()
		{
			// Assemble
			var cookieName = Create<string>();

			// Act
			Sut.DeleteCookie(cookieName);

			// Assert
			ResolveMock<ICookieJar>().Verify(x => x.DeleteCookieNamed(cookieName), Times.Once);
		}

		[Test]
		public void ClearAllCookiesDelegatesCallToCookieJar()
		{
			// Assemble

			// Act
			Sut.DeleteAllCookies();

			// Assert
			ResolveMock<ICookieJar>().Verify(x => x.DeleteAllCookies(), Times.Once);
		}

		public override void SetUp()
		{
			base.SetUp();

			ResolveMock<IOptions>().Setup(x => x.Cookies).Returns(ResolveMock<ICookieJar>().Object);
		}
	}
}