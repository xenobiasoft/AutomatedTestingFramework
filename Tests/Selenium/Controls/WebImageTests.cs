using AutomatedTestingFramework.Core.Controls;
using AutomatedTestingFramework.Selenium.Controls;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Tests.Selenium.Controls
{
	[TestFixture]
	public class WebImageTests : AutoMockingFixtureByInterface<WebImage, IWebImage>
	{
		[Test]
		public void AltTextReturnsWebElementAltAttributeValue()
		{
			// Assemble
			var expectedValue = Create<string>();
			ResolveMock<IWebElement>().Setup(x => x.GetAttribute(It.Is<string>(y => y == "alt"))).Returns(expectedValue);

			// Act

			// Assert
			Sut.AltText.Should().Be(expectedValue);
		}

		[Test]
		public void SrcReturnsWebElementSrcAttributeValue()
		{
			// Assemble
			var expectedValue = "http://www.imgurl.com";
			ResolveMock<IWebElement>().Setup(x => x.GetAttribute(It.Is<string>(y => y == "src"))).Returns(expectedValue);

			// Act

			// Assert
			Sut.Src.Should().Be(expectedValue);
		}
	}
}