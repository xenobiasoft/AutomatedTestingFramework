using AutomatedTestingFramework.Selenium.Controls;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Tests.Selenium.Controls
{
	[TestClass]
	public class ContentElementTests : BaseTest<ContentElement>
	{
		[TestMethod]
		public void IsEnabledReturnsWebElementEnabledProperty()
		{
			// Assemble
			ResolveMock<IWebElement>().Setup(x => x.Enabled).Returns(true);

			// Act

			// Assert
			Uut.IsEnabled.Should().BeTrue();
		}
	}
}