﻿using System;
using AutomatedTestingFramework.Selenium.ExceptionAnalysis;
using AutomatedTestingFramework.Selenium.Interfaces;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;
using NUnit.Framework;

namespace AutomatedTestingFramework.UnitTests
{
	[TestFixture]
	public class ExceptionAnalysisTests : AutoMockingFixtureByInterface<ExceptionAnalyzer, IExceptionAnalyzer>
	{
		[TestFixture]
		public class FileNotFoundExceptionHandlerTests : ExceptionAnalysisTests
		{
			[Test]
			public void FileNotFoundExceptionHandlerAppliesTo404Errors()
			{
				// Assemble
				var expectedExceptionMessage = "It is not a test problem. The page does not exist.";
				var mockBrowser = ResolveMock<IBrowserService>();
				mockBrowser.Setup(x => x.Source).Returns("404 - File or directory not found.");
				Sut.AddExceptionAnalyzationHandler(new FileNotFoundExceptionHandler());

				// Act
				Action analyze = () => Sut.Analyze(new Exception(), mockBrowser.Object);

				// Assert
				Assert.That(analyze,
					Throws
						.Exception
						.TypeOf<AnalyzedTestException>()
						.With.Message.Contains(expectedExceptionMessage));
			}
		}

		[TestFixture]
		public class ServiceUnavailableExceptionHandlerTests : ExceptionAnalysisTests
		{
			[Test]
			public void ServiceUnavailableExceptionHandlerAppliesTo500Errors()
			{
				// Assemble
				var expectedExceptionMessage = "It is not a test problem. The service is unavailable.";
				var mockBrowser = ResolveMock<IBrowserService>();
				mockBrowser.Setup(x => x.Source).Returns("HTTP Error 503. The service is unavailable.");
				Sut.AddExceptionAnalyzationHandler(new ServiceUnavailableExceptionHandler());

				// Act
				Action analyze = () => Sut.Analyze(new Exception(), mockBrowser.Object);

				// Assert
				Assert.That(analyze,
					Throws
						.Exception
						.TypeOf<AnalyzedTestException>()
						.With.Message.Contains(expectedExceptionMessage));
			}
		}

		[TestFixture]
		public class CustomHtmlExceptionHandlerTests : ExceptionAnalysisTests
		{
			[Test]
			public void CanAddCustomExceptionHandlers()
			{
				// Assemble
				var expectedExceptionMessage = "*You wouldn't understand. It's a Jeep thing*";
				var textToSearch = "O|||||O";
				var mockBrowser = ResolveMock<IBrowserService>();
				mockBrowser.Setup(x => x.Source).Returns(textToSearch);
				Sut.AddExceptionAnalyzationHandler(textToSearch, expectedExceptionMessage);

				// Act
				Action analyze = () => Sut.Analyze(new Exception(), mockBrowser.Object);

				// Assert
				Assert.That(analyze,
					Throws
						.Exception
						.TypeOf<AnalyzedTestException>()
						.With.Message.Contains(expectedExceptionMessage));
			}
		}
	}
}