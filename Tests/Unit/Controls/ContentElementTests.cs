using AutomatedTestingFramework.Selenium.Elements;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.UnitTests.Controls
{
	[TestFixture]
	public class ContentElementTests : AutoMockingFixtureByInterface<ContentElement, IContentElement>
	{
		[Test]
		public void IsEnabledReturnsWebElementEnabledProperty()
		{
			// Assemble
			ResolveMock<IWebElement>().Setup(x => x.Enabled).Returns(true);

			// Act

			// Assert
			Sut.IsEnabled.Should().BeTrue();
		}
	}
}