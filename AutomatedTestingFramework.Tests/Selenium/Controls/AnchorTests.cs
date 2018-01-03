using AutomatedTestingFramework.Selenium.Controls;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Tests.Selenium.Controls
{
	[TestClass]
	public class AnchorTests : BaseTest<Anchor>
	{
		[TestMethod]
		public void UrlReturnsWebElementsHref()
		{
			// Assemble
			var expectedUrl = "www.someurl.com/sub-route";
			ResolveMock<IWebElement>().Setup(x => x.GetAttribute(It.IsAny<string>())).Returns(expectedUrl);

			// Act
			var url = Uut.Url;

			// Assert
			url.Should().Be(expectedUrl);
		}
	}
}