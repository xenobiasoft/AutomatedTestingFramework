﻿using AutomatedTestingFramework.Core.Elements;
using AutomatedTestingFramework.Selenium.Elements;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Tests.Selenium.Controls
{
	[TestFixture]
	public class ContentElementTests : AutoMockingFixtureByInterface<ContentElement, IContentElement>
	{
		[Test]
		public void IsEnabledReturnsWebElementEnabledProperty()
		{
			// Assemble
			ResolveMock<IWebElement>().Setup(x => x.Enabled).Returns(true);

			// Act

			// Assert
			Sut.IsEnabled.Should().BeTrue();
		}
	}
}