using AutomatedTestingFramework.Selenium.Elements;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.UnitTests.Controls
{
	[TestFixture]
	public class TextboxTests : AutoMockingFixtureByInterface<TextBox, ITextBox>
	{
		[Test]
		public void TextReturnsWebElementValueAttribute()
		{
			// Assemble
			var expectedText = Create<string>();
			ResolveMock<IWebElement>().Setup(x => x.GetAttribute(It.Is<string>(y => y == "value"))).Returns(expectedText);

			// Act
			var actualText = Sut.Text;

			// Assert
			actualText.Should().Be(expectedText);
		}

		[Test]
		public void SettingTextCallsWebElementClearMethod()
		{
			// Assemble
			var mockWebElement = ResolveMock<IWebElement>();

			// Act
			Sut.Text = Create<string>();

			// Assert
			mockWebElement.Verify(x => x.Clear(), Times.AtLeast(1));
		}

		[Test]
		public void SettingTextCallsWebElementSendKeysWithValueOfText()
		{
			// Assemble
			var expectedValue = Create<string>();
			var mockWebElement = ResolveMock<IWebElement>();

			// Act
			Sut.Text = expectedValue;

			// Assert
			mockWebElement.Verify(x => x.SendKeys(It.Is<string>(y => y == expectedValue)), Times.Once());
		}
	}
}