﻿using System.Collections.Generic;
using AutomatedTestingFramework.Core.Controls;
using AutomatedTestingFramework.Selenium.Driver;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenQA.Selenium;
using By = AutomatedTestingFramework.Core.By;

namespace AutomatedTestingFramework.Tests.Selenium.Driver
{
	[TestClass]
	public class SeleniumDriverElementFinderTests : SeleniumDriverTests
	{
		[TestMethod]
		public void FindDelegatesCallToElementFinderService()
		{
			// Assemble
			var cssSelector = By.CssSelector(Create<string>());
			ResolveMock<IElementFinderService>()
				.Setup(x => x.Find<IElement>(It.IsAny<ISearchContext>(), It.Is<By>(s => s == cssSelector)))
				.Returns(ResolveMock<IContentElement>().Object);

			// Act
			var contentElement = Uut.Find<IElement>(cssSelector);

			// Assert
			contentElement.Should().NotBeNull();
		}

		[TestMethod]
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
				.Setup(x => x.FindAll<IElement>(It.IsAny<ISearchContext>(), It.Is<By>(s => s == cssSelector)))
				.Returns(expectedElements);

			// Act
			var contentElements = Uut.FindAll<IElement>(cssSelector);

			// Assert
			contentElements.Should().BeEquivalentTo(expectedElements);
		}

		[TestMethod]
		public void IsElementPresentDelegatesCallToElementFinderService()
		{
			// Assemble
			ResolveMock<IElementFinderService>()
				.Setup(x => x.IsElementPresent(It.IsAny<ISearchContext>(), It.IsAny<By>()))
				.Returns(true);

			// Act
			var isElementPresent = Uut.IsElementPresent(By.CssClass(Create<string>()));

			// Assert
			isElementPresent.Should().BeTrue();
		}
	}
}