using AutomatedTestingFramework.Selenium.Controls;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Tests.Selenium.Controls
{
	[TestClass]
	public class TextboxTests : BaseTest<TextBox>
	{
		[TestMethod]
		public void TextReturnsWebElementValueAttribute()
		{
			// Assemble
			var expectedText = Create<string>();
			ResolveMock<IWebElement>().Setup(x => x.GetAttribute(It.Is<string>(y => y == "value"))).Returns(expectedText);

			// Act
			var actualText = Uut.Text;

			// Assert
			actualText.Should().Be(expectedText);
		}

		[TestMethod]
		public void SettingTextCallsWebElementClearMethod()
		{
			// Assemble
			var mockWebElement = ResolveMock<IWebElement>();

			// Act
			Uut.Text = Create<string>();

			// Assert
			mockWebElement.Verify(x => x.Clear(), Times.AtLeast(1));
		}

		[TestMethod]
		public void SettingTextCallsWebElementSendKeysWithValueOfText()
		{
			// Assemble
			var expectedValue = Create<string>();
			var mockWebElement = ResolveMock<IWebElement>();

			// Act
			Uut.Text = expectedValue;

			// Assert
			mockWebElement.Verify(x => x.SendKeys(It.Is<string>(y => y == expectedValue)), Times.Once());
		}
	}
}