using AutomatedTestingFramework.Core.Controls;
using AutomatedTestingFramework.Selenium.Controls;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Tests.Selenium.Controls
{
	[TestFixture]
	public class ContentElementTests : BaseTestByInterface<ContentElement, IContentElement>
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