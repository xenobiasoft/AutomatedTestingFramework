using AutomatedTestingFramework.Selenium.Elements;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Tests.Selenium.Controls
{
	[TestFixture]
	public class LabelTests : AutoMockingFixtureByInterface<Label, ILabel>
	{
		[Test]
		public void TextReturnsWebElementText()
		{
			// Assemble
			var expectedText = Create<string>();
			ResolveMock<IWebElement>().Setup(x => x.Text).Returns(expectedText);

			// Act
			var actualText = Sut.Text;

			// Assert
			actualText.Should().Be(expectedText);
		}
	}
}