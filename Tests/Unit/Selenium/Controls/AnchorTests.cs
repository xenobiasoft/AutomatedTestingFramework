using AutomatedTestingFramework.Core.Elements;
using AutomatedTestingFramework.Selenium.Elements;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Tests.Selenium.Controls
{
	[TestFixture]
	public class AnchorTests : AutoMockingFixtureByInterface<Anchor, IAnchor>
	{
		[Test]
		public void UrlReturnsWebElementsHref()
		{
			// Assemble
			var expectedUrl = "www.someurl.com/sub-route";
			ResolveMock<IWebElement>().Setup(x => x.GetAttribute(It.IsAny<string>())).Returns(expectedUrl);

			// Act
			var url = Sut.Href;

			// Assert
			url.Should().Be(expectedUrl);
		}
	}
}