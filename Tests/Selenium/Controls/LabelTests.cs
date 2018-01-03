using AutomatedTestingFramework.Selenium.Controls;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Tests.Selenium.Controls
{
	[TestClass]
	public class LabelTests : BaseTest<Label>
	{
		[TestMethod]
		public void TextReturnsWebElementText()
		{
			// Assemble
			var expectedText = Create<string>();
			ResolveMock<IWebElement>().Setup(x => x.Text).Returns(expectedText);

			// Act
			var actualText = Uut.Text;

			// Assert
			actualText.Should().Be(expectedText);
		}
	}
}