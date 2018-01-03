using System.Drawing;
using AutomatedTestingFramework.Core.Controls;
using AutomatedTestingFramework.Selenium.Controls;
using AutomatedTestingFramework.Selenium.Driver;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenQA.Selenium;
using By = AutomatedTestingFramework.Core.By;

namespace AutomatedTestingFramework.Tests.Selenium.Controls
{
	[TestClass]
	public class ElementTests : BaseTest<Element>
	{
		[TestMethod]
		public void ClickDelegatesCallToWebElement()
		{
			// Assemble
			var mockWebElement = ResolveMock<IWebElement>();

			// Act
			Uut.Click();

			// Assert
			mockWebElement.Verify(x => x.Click(), Times.Once);
		}

		[TestMethod]
		public void FindDelegatesCallToElementFinderService()
		{
			// Assemble
			var expectedId = Create<string>();
			var mockElementFinderService = ResolveMock<IElementFinderService>();

			// Act
			Uut.Find<IButton>(By.Id(expectedId));

			// Assert
			mockElementFinderService
				.Verify(x => x.Find<IButton>(It.IsAny<ISearchContext>(), It.Is<By>(by => by.Value.Equals(expectedId))), Times.Once());
		}

		[TestMethod]
		public void FindAllDelegatesCallToElementFinderService()
		{
			// Assemble
			var expectedId = Create<string>();
			var mockElementFinderService = ResolveMock<IElementFinderService>();

			// Act
			Uut.FindAll<IButton>(By.Id(expectedId));

			// Assert
			mockElementFinderService
				.Verify(x => x.FindAll<IButton>(It.IsAny<ISearchContext>(), It.Is<By>(by => by.Value.Equals(expectedId))), Times.Once());
		}

		[TestMethod]
		public void GetAttributeDelegatesCallToWebElement()
		{
			// Assemble
			var mockWebElement = ResolveMock<IWebElement>();

			// Act
			Uut.GetAttribute(Create<string>());

			// Assert
			mockWebElement.Verify(x => x.GetAttribute(It.IsAny<string>()), Times.Once());
		}

		[TestMethod]
		public void GetAttributeReturnsValueFromWebElement()
		{
			// Assemble
			var expectedAttributeValue = Create<string>();
			ResolveMock<IWebElement>().Setup(x => x.GetAttribute(It.IsAny<string>())).Returns(expectedAttributeValue);

			// Act
			var actualValue = Uut.GetAttribute(Create<string>());

			// Assert
			actualValue.Should().Be(expectedAttributeValue);
		}

		[TestMethod]
		public void IsElementPresentDelegatesCallToElementFinderService()
		{
			// Assemble
			var mockElementFinderService = ResolveMock<IElementFinderService>();

			// Act
			Uut.IsElementPresent(By.Id(Create<string>()));

			// Assert
			mockElementFinderService.Verify(x => x.IsElementPresent(It.IsAny<ISearchContext>(), It.IsAny<By>()), Times.Once);
		}

		[TestMethod]
		public void CssClassReturnsClassNameAttribute()
		{
			// Assemble
			var expectedValue = "high-class";
			ResolveMock<IWebElement>().Setup(x => x.GetAttribute(It.Is<string>(y => y == "className"))).Returns(expectedValue);

			// Act
			var actualValue = Uut.CssClass;

			// Assert
			actualValue.Should().Be(expectedValue);
		}

		[TestMethod]
		public void ContentPullsValueFromWebElementTextProperty()
		{
			// Assemble
			var expectedText = "<State Enabled=\"false\" Fallthrough=\"false\" UseLatency=\"false\" />";
			ResolveMock<IWebElement>().Setup(x => x.Text).Returns(expectedText);

			// Act
			var actual = Uut.Content;

			// Assert
			actual.Should().Be(expectedText);
		}

		[TestMethod]
		public void IsVisibleReturnsValueOfWebElementIsDisplayed()
		{
			// Assemble
			ResolveMock<IWebElement>().Setup(x => x.Displayed).Returns(true);

			// Act
			var isVisible = Uut.IsVisible;

			// Assert
			isVisible.Should().BeTrue();
		}

		[TestMethod]
		public void WidthReturnsWebElementWidth()
		{
			// Assemble
			var size = new Size(50, 25);
			ResolveMock<IWebElement>().Setup(x => x.Size).Returns(size);

			// Act
			var width = Uut.Width;

			// Assert
			width.Should().Be(50);
		}

		[TestMethod]
		public void HeightReturnsWebElementHeight()
		{
			// Assemble
			var size = new Size(50, 25);
			ResolveMock<IWebElement>().Setup(x => x.Size).Returns(size);

			// Act
			var height = Uut.Height;

			// Assert
			height.Should().Be(25);
		}
	}
}