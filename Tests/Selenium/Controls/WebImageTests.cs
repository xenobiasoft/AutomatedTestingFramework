using AutomatedTestingFramework.Selenium.Controls;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Tests.Selenium.Controls
{
	[TestClass]
	public class WebImageTests : BaseTest<WebImage>
	{
		[TestMethod]
		public void AltTextReturnsWebElementAltAttributeValue()
		{
			// Assemble
			var expectedValue = Create<string>();
			ResolveMock<IWebElement>().Setup(x => x.GetAttribute(It.Is<string>(y => y == "alt"))).Returns(expectedValue);

			// Act

			// Assert
			Uut.AltText.Should().Be(expectedValue);
		}

		[TestMethod]
		public void SrcReturnsWebElementSrcAttributeValue()
		{
			// Assemble
			var expectedValue = "http://www.imgurl.com";
			ResolveMock<IWebElement>().Setup(x => x.GetAttribute(It.Is<string>(y => y == "src"))).Returns(expectedValue);

			// Act

			// Assert
			Uut.Src.Should().Be(expectedValue);
		}
	}
}