using System.Collections.Generic;
using System.Linq;
using AutomatedTestingFramework.Core.Controls;
using AutomatedTestingFramework.Selenium.Driver;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenQA.Selenium;
using By = AutomatedTestingFramework.Core.By;
using SeleniumBy = OpenQA.Selenium.By;

namespace AutomatedTestingFramework.Tests.Selenium.Driver
{
	[TestClass]
	public class ElementFinderServiceTests : BaseTest<ElementFinderService>
	{
		[TestClass]
		public class FindTests : ElementFinderServiceTests
		{
			[TestMethod]
			public void DelegatesCallToSearchContext()
			{
				// Assemble
				var mockSearchContext = ResolveMock<ISearchContext>();
				mockSearchContext.Setup(x => x.FindElement(It.IsAny<SeleniumBy>())).Returns(ResolveMock<IWebElement>().Object);

				// Act
				Uut.Find<IContentElement>(mockSearchContext.Object, By.Id(Create<string>()));

				// Assert
				mockSearchContext.Verify(x => x.FindElement(It.IsAny<SeleniumBy>()), Times.Once);
			}

			[TestMethod]
			public void ReturnsInstanceOfRequestedInterface()
			{
				// Assemble
				var mockSearchContext = ResolveMock<ISearchContext>();
				mockSearchContext.Setup(x => x.FindElement(It.IsAny<SeleniumBy>())).Returns(ResolveMock<IWebElement>().Object);

				// Act
				var control = Uut.Find<IContentElement>(mockSearchContext.Object, By.Id(Create<string>()));

				// Assert
				control.Should().BeAssignableTo<IContentElement>();
			}
		}

		[TestClass]
		public class FindAllTests : ElementFinderServiceTests
		{
			[TestMethod]
			public void DelegatesCallToSearchContext()
			{
				// Assemble
				var mockSearchContext = ResolveMock<ISearchContext>();
				mockSearchContext.Setup(x => x.FindElements(It.IsAny<SeleniumBy>())).Returns(ResolveMock<List<IWebElement>>().Object.AsReadOnly);
				
				// Act
				Uut.FindAll<IButton>(mockSearchContext.Object, By.CssClass("btn"));

				// Assert
				mockSearchContext.Verify(x => x.FindElements(It.IsAny<SeleniumBy>()), Times.Once);
			}

			[TestMethod]
			public void ReturnsListOfRequestedInterface()
			{
				// Assemble
				var mockSearchContext = ResolveMock<ISearchContext>();
				var controlList = new List<IWebElement>
				{
					ResolveMock<IWebElement>().Object,
					ResolveMock<IWebElement>().Object
				};
				mockSearchContext.Setup(x => x.FindElements(It.IsAny<SeleniumBy>())).Returns(controlList.AsReadOnly());

				// Act
				var buttons = Uut.FindAll<IButton>(mockSearchContext.Object, By.CssClass("btn"));

				// Assert
				buttons.ToList().ForEach(x => x.Should().BeAssignableTo<IContentElement>());
			}
		}

		[TestClass]
		public class IsElementPresentTests : ElementFinderServiceTests
		{
			[TestMethod]
			public void ReturnsTrueIfElementIsVisible()
			{
				// Assemble
				var mockSearchContext = ResolveMock<ISearchContext>();
				var mockControl = ResolveMock<IWebElement>();
				mockControl.Setup(y => y.Displayed).Returns(true);
				mockSearchContext.Setup(x => x.FindElement(It.IsAny<SeleniumBy>()))
					.Returns(mockControl.Object);

				// Act
				var isElementPresent = Uut.IsElementPresent(mockSearchContext.Object, By.Id(Create<string>()));

				// Assert
				isElementPresent.Should().BeTrue();
			}
		}
	}
}