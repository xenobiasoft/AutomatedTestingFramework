﻿using System.Collections.Generic;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;
using By = AutomatedTestingFramework.Selenium.By;

namespace AutomatedTestingFramework.UnitTests.Driver
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
				.Returns(ResolveMock<IElement>().Object);

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