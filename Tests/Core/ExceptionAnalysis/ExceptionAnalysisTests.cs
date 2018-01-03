using System;
using AutomatedTestingFramework.Core.Driver;
using AutomatedTestingFramework.Core.ExceptionAnalysis;
using FluentAssertions;
using NUnit.Framework;

namespace AutomatedTestingFramework.Tests.Core.ExceptionAnalysis
{
	[TestFixture]
	public class ExceptionAnalysisTests : BaseTestByClass<ExceptionAnalyzer>
	{
		[TestFixture]
		public class FileNotFoundExceptionHandlerTests : ExceptionAnalysisTests
		{
			[Test]
			[Category(TestCategories.Core)]
			public void FileNotFoundExceptionHandlerAppliesTo404Errors()
			{
				// Assemble
				var expectedExceptionMessage = "*It is not a test problem. The page does not exist.*";
				var mockBrowser = ResolveMock<IBrowser>();
				mockBrowser.Setup(x => x.Source).Returns("404 - File or directory not found.");
				Sut.AddExceptionAnalyzationHandler(new FileNotFoundExceptionHandler());

				// Act
				Action analyze = () => Sut.Analyze(new Exception(), mockBrowser.Object);

				// Assert
				analyze.ShouldThrow<AnalyzedTestException>().WithMessage(expectedExceptionMessage);
			}
		}

		[TestFixture]
		public class ServiceUnavailableExceptionHandlerTests : ExceptionAnalysisTests
		{
			[Test]
			[Category(TestCategories.Core)]
			public void ServiceUnavailableExceptionHandlerAppliesTo500Errors()
			{
				// Assemble
				var expectedExceptionMessage = "*It is not a test problem. The service is unavailable.*";
				var mockBrowser = ResolveMock<IBrowser>();
				mockBrowser.Setup(x => x.Source).Returns("HTTP Error 503. The service is unavailable.");
				Sut.AddExceptionAnalyzationHandler(new ServiceUnavailableExceptionHandler());

				// Act
				Action analyze = () => Sut.Analyze(new Exception(), mockBrowser.Object);

				// Assert
				analyze.ShouldThrow<AnalyzedTestException>().WithMessage(expectedExceptionMessage);
			}
		}

		[TestFixture]
		public class CustomHtmlExceptionHandlerTests : ExceptionAnalysisTests
		{
			[Test]
			[Category(TestCategories.Core)]
			public void CanAddCustomExceptionHandlers()
			{
				// Assemble
				var expectedExceptionMessage = "*You wouldn't understand. It's a Jeep thing*";
				var textToSearch = "O|||||O";
				var mockBrowser = ResolveMock<IBrowser>();
				mockBrowser.Setup(x => x.Source).Returns(textToSearch);
				Sut.AddExceptionAnalyzationHandler(textToSearch, expectedExceptionMessage);

				// Act
				Action analyze = () => Sut.Analyze(new Exception(), mockBrowser.Object);

				// Assert
				analyze.ShouldThrow<AnalyzedTestException>().WithMessage(expectedExceptionMessage);
			}
		}
	}
}