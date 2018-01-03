using System;
using AutomatedTestingFramework.Core.Driver;
using AutomatedTestingFramework.Core.ExceptionAnalysis;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomatedTestingFramework.Tests.Core.ExceptionAnalysis
{
	[TestClass]
	public class ExceptionAnalysisTests : BaseTest<ExceptionAnalyzer>
	{
		[TestClass]
		public class FileNotFoundExceptionHandlerTests : ExceptionAnalysisTests
		{
			[TestMethod]
			[TestCategory(TestCategories.Core)]
			public void FileNotFoundExceptionHandlerAppliesTo404Errors()
			{
				// Assemble
				var expectedExceptionMessage = "*It is not a test problem. The page does not exist.*";
				var mockBrowser = ResolveMock<IBrowser>();
				mockBrowser.Setup(x => x.Source).Returns("404 - File or directory not found.");
				Uut.AddExceptionAnalyzationHandler(new FileNotFoundExceptionHandler());

				// Act
				Action analyze = () => Uut.Analyze(new Exception(), mockBrowser.Object);

				// Assert
				analyze.ShouldThrow<AnalyzedTestException>().WithMessage(expectedExceptionMessage);
			}
		}

		[TestClass]
		public class ServiceUnavailableExceptionHandlerTests : ExceptionAnalysisTests
		{
			[TestMethod]
			[TestCategory(TestCategories.Core)]
			public void ServiceUnavailableExceptionHandlerAppliesTo500Errors()
			{
				// Assemble
				var expectedExceptionMessage = "*It is not a test problem. The service is unavailable.*";
				var mockBrowser = ResolveMock<IBrowser>();
				mockBrowser.Setup(x => x.Source).Returns("HTTP Error 503. The service is unavailable.");
				Uut.AddExceptionAnalyzationHandler(new ServiceUnavailableExceptionHandler());

				// Act
				Action analyze = () => Uut.Analyze(new Exception(), mockBrowser.Object);

				// Assert
				analyze.ShouldThrow<AnalyzedTestException>().WithMessage(expectedExceptionMessage);
			}
		}

		[TestClass]
		public class CustomHtmlExceptionHandlerTests : ExceptionAnalysisTests
		{
			[TestMethod]
			[TestCategory(TestCategories.Core)]
			public void CanAddCustomExceptionHandlers()
			{
				// Assemble
				var expectedExceptionMessage = "*You wouldn't understand. It's a Jeep thing*";
				var textToSearch = "O|||||O";
				var mockBrowser = ResolveMock<IBrowser>();
				mockBrowser.Setup(x => x.Source).Returns(textToSearch);
				Uut.AddExceptionAnalyzationHandler(textToSearch, expectedExceptionMessage);

				// Act
				Action analyze = () => Uut.Analyze(new Exception(), mockBrowser.Object);

				// Assert
				analyze.ShouldThrow<AnalyzedTestException>().WithMessage(expectedExceptionMessage);
			}
		}
	}
}