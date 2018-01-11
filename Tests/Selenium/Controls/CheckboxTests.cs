using AutomatedTestingFramework.Core.Controls;
using AutomatedTestingFramework.Selenium.Controls;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Tests.Selenium.Controls
{
	[TestFixture]
	public class CheckboxTests : BaseTestByInterface<Checkbox, ICheckbox>
	{
		[Test]
		public void IsCheckedReturnsWebElementSelected()
		{
			// Assemble
			ResolveMock<IWebElement>().Setup(x => x.Selected).Returns(true);

			// Act

			// Assert
			Sut.IsChecked.Should().BeTrue();
		}

		[Test]
		public void CheckCallsWebElementClickMethodWhenIsSelectedIsFalse()
		{
			// Assemble
			var mockElement = ResolveMock<IWebElement>();
			mockElement.Setup(x => x.Selected).Returns(false);

			// Act
			Sut.Check();

			// Assert
			mockElement.Verify(x => x.Click(), Times.Once);
		}

		[Test]
		public void CheckDoesNotCallWebElementClickMethodWhenIsSelectedIsTrue()
		{
			// Assemble
			ResolveMock<IWebElement>().Setup(x => x.Selected).Returns(true);

			// Act
			Sut.Check();

			// Assert
			ResolveMock<IWebElement>().Verify(x => x.Click(), Times.Never);
		}

		[Test]
		public void UncheckCallsWebElementClickMethodWhenIsSelectedIsTrue()
		{
			// Assemble
			ResolveMock<IWebElement>().Setup(x => x.Selected).Returns(true);

			// Act
			Sut.Uncheck();

			// Assert
			ResolveMock<IWebElement>().Verify(x => x.Click(), Times.Once);
		}

		[Test]
		public void UncheckDoesNotCallsWebElementClickMethodWhenIsSelectedIsFalse()
		{
			// Assemble

			// Act
			Sut.Uncheck();

			// Assert
			ResolveMock<IWebElement>().Verify(x => x.Click(), Times.Never);
		}
	}
}