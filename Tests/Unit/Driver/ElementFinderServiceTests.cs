using System.Collections.Generic;
using System.Linq;
using AutomatedTestingFramework.Selenium.Elements;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;
using By = AutomatedTestingFramework.Selenium.By;
using SeleniumBy = OpenQA.Selenium.By;

namespace AutomatedTestingFramework.UnitTests.Driver
{
	[TestFixture]
	public class ElementFinderServiceTests : AutoMockingFixtureByInterface<ElementFinderService, IElementFinderService>
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
				Sut.Find<IElement>(mockSearchContext.Object, By.Id(Create<string>()));

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
				var control = Sut.Find<IElement>(mockSearchContext.Object, By.Id(Create<string>()));

				// Assert
				Assert.That(control, Is.AssignableTo<IElement>());
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
				var controlList = Resolve<IWebElement[]>();
				mockSearchContext.Setup(x => x.FindElements(It.IsAny<SeleniumBy>())).Returns(controlList.ToList().AsReadOnly);

				// Act
				var buttons = Sut.FindAll<IButton>(mockSearchContext.Object, By.CssClass("btn"));

				// Assert
				buttons.ToList().ForEach(x => Assert.That(x, Is.AssignableTo<IElement>()));
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
				Assert.That(isElementPresent, Is.True);
			}
		}
	}
}