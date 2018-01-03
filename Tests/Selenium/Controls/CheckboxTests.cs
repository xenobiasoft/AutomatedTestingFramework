using AutomatedTestingFramework.Selenium.Controls;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Tests.Selenium.Controls
{
	[TestClass]
	public class CheckboxTests : BaseTest<Checkbox>
	{
		[TestMethod]
		public void IsCheckedReturnsWebElementSelected()
		{
			// Assemble
			ResolveMock<IWebElement>().Setup(x => x.Selected).Returns(true);

			// Act

			// Assert
			Uut.IsChecked.Should().BeTrue();
		}

		[TestMethod]
		public void CheckCallsWebElementClickMethodWhenIsSelectedIsFalse()
		{
			// Assemble
			var mockElement = ResolveMock<IWebElement>();
			mockElement.Setup(x => x.Selected).Returns(false);

			// Act
			Uut.Check();

			// Assert
			mockElement.Verify(x => x.Click(), Times.Once);
		}

		[TestMethod]
		public void CheckDoesNotCallWebElementClickMethodWhenIsSelectedIsTrue()
		{
			// Assemble
			ResolveMock<IWebElement>().Setup(x => x.Selected).Returns(true);

			// Act
			Uut.Check();

			// Assert
			ResolveMock<IWebElement>().Verify(x => x.Click(), Times.Never);
		}

		[TestMethod]
		public void UncheckCallsWebElementClickMethodWhenIsSelectedIsTrue()
		{
			// Assemble
			ResolveMock<IWebElement>().Setup(x => x.Selected).Returns(true);

			// Act
			Uut.Uncheck();

			// Assert
			ResolveMock<IWebElement>().Verify(x => x.Click(), Times.Once);
		}

		[TestMethod]
		public void UncheckDoesNotCallsWebElementClickMethodWhenIsSelectedIsFalse()
		{
			// Assemble

			// Act
			Uut.Uncheck();

			// Assert
			ResolveMock<IWebElement>().Verify(x => x.Click(), Times.Never);
		}
	}
}