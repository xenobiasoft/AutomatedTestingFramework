using System.Collections.Generic;
using AutomatedTestingFramework.Core.Elements;
using AutomatedTestingFramework.Selenium.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;
using By = AutomatedTestingFramework.Core.By;

namespace AutomatedTestingFramework.Tests.Selenium.Driver
{
	[TestFixture]
	public class SeleniumDriverElementFinderTests : SeleniumDriverTests
	{
		[Test]
		public void FindDelegatesCallToElementFinderService()
		{
			// Assemble
			var cssSelector = By.CssSelector(Create<string>());
			ResolveMock<IElementFinderService>()
				.Setup(x => x.Find<IElement>(It.IsAny<ISearchContext>(), It.IsAny<By>()))
				.Returns(ResolveMock<IContentElement>().Object);

			// Act
			var contentElement = Sut.Find<IElement>(cssSelector);

			// Assert
			contentElement.Should().NotBeNull();
		}

		[Test]
		public void FindAllDelegatesCallToElementFinderService()
		{
			// Assemble
			var cssSelector = By.CssSelector(Create<string>());
			var expectedElements = new List<IElement>
			{
				ResolveMock<IElement>().Object,
				ResolveMock<IElement>().Object,
				ResolveMock<IElement>().Object,
			};
			ResolveMock<IElementFinderService>()
				.Setup(x => x.FindAll<IElement>(It.IsAny<ISearchContext>(), It.IsAny<By>()))
				.Returns(expectedElements);

			// Act
			var contentElements = Sut.FindAll<IElement>(cssSelector);

			// Assert
			contentElements.Should().BeEquivalentTo(expectedElements);
		}

		[Test]
		public void IsElementPresentDelegatesCallToElementFinderService()
		{
			// Assemble
			ResolveMock<IElementFinderService>()
				.Setup(x => x.IsElementPresent(It.IsAny<ISearchContext>(), It.IsAny<By>()))
				.Returns(true);

			// Act
			var isElementPresent = Sut.IsElementPresent(By.CssClass(Create<string>()));

			// Assert
			isElementPresent.Should().BeTrue();
		}
	}
}