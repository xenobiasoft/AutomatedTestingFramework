using System.Collections.Generic;
using System.Linq;
using AutomatedTestingFramework.Core.Controls;
using AutomatedTestingFramework.Selenium.Driver;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;
using By = AutomatedTestingFramework.Core.By;
using SeleniumBy = OpenQA.Selenium.By;

namespace AutomatedTestingFramework.Tests.Selenium.Driver
{
	[TestFixture]
	public class ElementFinderServiceTests : BaseTestByClass<ElementFinderService>
	{
		[TestFixture]
		public class FindTests : ElementFinderServiceTests
		{
			[Test]
			public void DelegatesCallToSearchContext()
			{
				// Assemble
				var mockSearchContext = ResolveMock<ISearchContext>();
				mockSearchContext.Setup(x => x.FindElement(It.IsAny<SeleniumBy>())).Returns(ResolveMock<IWebElement>().Object);

				// Act
				Sut.Find<IContentElement>(mockSearchContext.Object, By.Id(Create<string>()));

				// Assert
				mockSearchContext.Verify(x => x.FindElement(It.IsAny<SeleniumBy>()), Times.Once);
			}

			[Test]
			public void ReturnsInstanceOfRequestedInterface()
			{
				// Assemble
				var mockSearchContext = ResolveMock<ISearchContext>();
				mockSearchContext.Setup(x => x.FindElement(It.IsAny<SeleniumBy>())).Returns(ResolveMock<IWebElement>().Object);

				// Act
				var control = Sut.Find<IContentElement>(mockSearchContext.Object, By.Id(Create<string>()));

				// Assert
				control.Should().BeAssignableTo<IContentElement>();
			}
		}

		[TestFixture]
		public class FindAllTests : ElementFinderServiceTests
		{
			[Test]
			public void DelegatesCallToSearchContext()
			{
				// Assemble
				var mockSearchContext = ResolveMock<ISearchContext>();
				mockSearchContext.Setup(x => x.FindElements(It.IsAny<SeleniumBy>())).Returns(ResolveMock<List<IWebElement>>().Object.AsReadOnly);
				
				// Act
				Sut.FindAll<IButton>(mockSearchContext.Object, By.CssClass("btn"));

				// Assert
				mockSearchContext.Verify(x => x.FindElements(It.IsAny<SeleniumBy>()), Times.Once);
			}

			[Test]
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
				var buttons = Sut.FindAll<IButton>(mockSearchContext.Object, By.CssClass("btn"));

				// Assert
				buttons.ToList().ForEach(x => x.Should().BeAssignableTo<IContentElement>());
			}
		}

		[TestFixture]
		public class IsElementPresentTests : ElementFinderServiceTests
		{
			[Test]
			public void ReturnsTrueIfElementIsVisible()
			{
				// Assemble
				var mockSearchContext = ResolveMock<ISearchContext>();
				var mockControl = ResolveMock<IWebElement>();
				mockControl.Setup(y => y.Displayed).Returns(true);
				mockSearchContext.Setup(x => x.FindElement(It.IsAny<SeleniumBy>()))
					.Returns(mockControl.Object);

				// Act
				var isElementPresent = Sut.IsElementPresent(mockSearchContext.Object, By.Id(Create<string>()));

				// Assert
				isElementPresent.Should().BeTrue();
			}
		}
	}
}