using AutomatedTestingFramework.Selenium.Elements;
using AutomatedTestingFramework.Selenium.Interfaces.Elements;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.UnitTests.Controls
{
	[TestFixture]
	public class CheckboxTests : AutoMockingFixtureByInterface<Checkbox, ICheckbox>
	{
		[Test]
		public void IsCheckedReturnsWebElementSelected()
		{
			// Assemble
			ResolveMock<IWebElement>().Setup(x => x.Selected).Returns(true);

			// Act

			// Assert
			Assert.That(Sut.IsChecked, Is.True);
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