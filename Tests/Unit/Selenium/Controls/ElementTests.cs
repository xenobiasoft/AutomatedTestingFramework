using System.Drawing;
using AutomatedTestingFramework.Selenium.Elements;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Tests.Selenium.Controls
{
	[TestFixture]
	public class ElementTests : AutoMockingFixtureByInterface<WebElement, IElement>
	{
		[Test]
		public void GetAttributeDelegatesCallToWebElement()
		{
			// Assemble
			var mockWebElement = ResolveMock<IWebElement>();

			// Act
			Sut.GetAttribute(Create<string>());

			// Assert
			mockWebElement.Verify(x => x.GetAttribute(It.IsAny<string>()), Times.Once());
		}

		[Test]
		public void GetAttributeReturnsValueFromWebElement()
		{
			// Assemble
			var expectedAttributeValue = Create<string>();
			ResolveMock<IWebElement>().Setup(x => x.GetAttribute(It.IsAny<string>())).Returns(expectedAttributeValue);

			// Act
			var actualValue = Sut.GetAttribute(Create<string>());

			// Assert
			actualValue.Should().Be(expectedAttributeValue);
		}

		[Test]
		public void CssClassReturnsClassNameAttribute()
		{
			// Assemble
			var expectedValue = "high-class";
			ResolveMock<IWebElement>().Setup(x => x.GetAttribute(It.Is<string>(y => y == "className"))).Returns(expectedValue);

			// Act
			var actualValue = Sut.CssClass;

			// Assert
			actualValue.Should().Be(expectedValue);
		}

		[Test]
		public void ContentPullsValueFromWebElementTextProperty()
		{
			// Assemble
			var expectedText = "<State Enabled=\"false\" Fallthrough=\"false\" UseLatency=\"false\" />";
			ResolveMock<IWebElement>().Setup(x => x.Text).Returns(expectedText);

			// Act
			var actual = Sut.Text;

			// Assert
			actual.Should().Be(expectedText);
		}

		[Test]
		public void IsVisibleReturnsValueOfWebElementIsDisplayed()
		{
			// Assemble
			ResolveMock<IWebElement>().Setup(x => x.Displayed).Returns(true);

			// Act
			var isVisible = Sut.Displayed;

			// Assert
			isVisible.Should().BeTrue();
		}

		[Test]
		public void WidthReturnsWebElementWidth()
		{
			// Assemble
			var size = new Size(50, 25);
			ResolveMock<IWebElement>().Setup(x => x.Size).Returns(size);

			// Act
			var width = Sut.Width;

			// Assert
			width.Should().Be(50);
		}

		[Test]
		public void HeightReturnsWebElementHeight()
		{
			// Assemble
			var size = new Size(50, 25);
			ResolveMock<IWebElement>().Setup(x => x.Size).Returns(size);

			// Act
			var height = Sut.Height;

			// Assert
			height.Should().Be(25);
		}
	}
}