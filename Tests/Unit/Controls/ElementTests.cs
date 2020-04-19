using System.Drawing;
using AutomatedTestingFramework.Selenium.Elements;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.UnitTests.Controls
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
			var expectedValue = Create<string>();
			ResolveMock<IWebElement>().Setup(x => x.GetAttribute(It.IsAny<string>())).Returns(expectedValue);

			// Act
			var actualValue = Sut.GetAttribute(Create<string>());

			// Assert
			Assert.That(actualValue, Is.EqualTo(expectedValue));
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
			Assert.That(actualValue, Is.EqualTo(expectedValue));
		}

		[Test]
		public void IsVisibleReturnsValueOfWebElementIsDisplayed()
		{
			// Assemble
			ResolveMock<IWebElement>().Setup(x => x.Displayed).Returns(true);

			// Act
			var isVisible = Sut.Displayed;

			// Assert
			Assert.That(isVisible, Is.True);
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
			Assert.That(width, Is.EqualTo(50));
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
			Assert.That(height, Is.EqualTo(25));
		}
	}
}