using AutomatedTestingFramework.Selenium.Elements;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.UnitTests.Controls
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
			Assert.That(Sut.AltText, Is.EqualTo(expectedValue));
		}

		[Test]
		public void SrcReturnsWebElementSrcAttributeValue()
		{
			// Assemble
			var expectedValue = "http://www.imgurl.com";
			ResolveMock<IWebElement>().Setup(x => x.GetAttribute(It.Is<string>(y => y == "src"))).Returns(expectedValue);

			// Act

			// Assert
			Assert.That(Sut.Src, Is.EqualTo(expectedValue));
		}
	}
}