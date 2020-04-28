using System;
using System.Reflection;
using AutomatedTestingFramework.Selenium.Attributes;
using AutomatedTestingFramework.Selenium.BehaviorObserver;
using AutomatedTestingFramework.Selenium.Configuration;
using AutomatedTestingFramework.Selenium.Enums;
using AutomatedTestingFramework.Selenium.Interfaces;
using Moq;
using NUnit.Framework;

namespace AutomatedTestingFramework.UnitTests.Media
{
	[TestFixture]
	public class VideoRecorderTests : AutoMockingFixtureByInterface<VideoRecordingTestFlowObserver, ITestObserver>
	{
		private Mock<TestExecutionEventArgs> _mockTestExecutionEventArgs;

		private bool _didRecord;

		[TestFixture]
		public class PostTestInitTests : VideoRecorderTests
		{
			[TestCase(TestOutcome.Failed)]
			[TestCase(TestOutcome.Inconclusive)]
			[TestCase(TestOutcome.Passed)]
			[TestCase(TestOutcome.Skipped)]
			[TestCase(TestOutcome.Warning)]
			public void VideoDoesNotRecordWhenConfigurationIsSetToDisableRecording(TestOutcome testOutcome)
			{
				// Assemble
				_mockTestExecutionEventArgs.Setup(x => x.TestOutcome).Returns(testOutcome);
				ResolveMock<AppSettings>().Setup(x => x.VideoRecording.EnableVideoRecording).Returns(false);

				// Act
				Sut.PostTestInit(this, _mockTestExecutionEventArgs.Object);
				Sut.PostTestCleanup(this, _mockTestExecutionEventArgs.Object);

				// Assert
				Assert.That(_didRecord, Is.False, "Expected video to have not been recorded.");
			}

			[TestCase(TestOutcome.Failed)]
			[TestCase(TestOutcome.Inconclusive)]
			[TestCase(TestOutcome.Passed)]
			[TestCase(TestOutcome.Skipped)]
			[TestCase(TestOutcome.Warning)]
			[VideoRecording(VideoRecordingMode.Always)]
			public void VideoRecordsIfMethodLevelAttributeIsSetToRecordAlways(TestOutcome testOutcome)
			{
				// Assemble
				_mockTestExecutionEventArgs.Setup(x => x.TestOutcome).Returns(testOutcome);

				// Act
				Sut.PostTestInit(this, _mockTestExecutionEventArgs.Object);
				Sut.PostTestCleanup(this, _mockTestExecutionEventArgs.Object);

				// Assert
				Assert.That(_didRecord, Is.True, "Expected video to have been recorded.");
			}

			[Test]
			[VideoRecording(VideoRecordingMode.Always)]
			public void WhenTestExecutionEventArgsMemberInfoIsNullThrowsArgumentNullException()
			{
				// Assemble
				_mockTestExecutionEventArgs.Setup(x => x.MemberInfo).Returns((MemberInfo)null);

				// Act
				Action postTestInit = () => Sut.PostTestInit(this, _mockTestExecutionEventArgs.Object);

				// Assert
				Assert.That(postTestInit,
					Throws.ArgumentNullException.With.Message.EqualTo(
						"Value cannot be null. (Parameter 'memberInfo')"));
			}
		}

		[TestFixture]
		public class PostTestCleanupTests : VideoRecorderTests
		{
			[TestCase(TestOutcome.Failed, true)]
			[TestCase(TestOutcome.Inconclusive, false)]
			[TestCase(TestOutcome.Passed, false)]
			[TestCase(TestOutcome.Skipped, false)]
			[TestCase(TestOutcome.Warning, false)]
			[VideoRecording(VideoRecordingMode.OnlyFail)]
			public void VideoIsRecordedOnlyWhenTestFails(TestOutcome testOutcome, bool expectedDidRecord)
			{
				// Assemble
				_mockTestExecutionEventArgs.Setup(x => x.TestOutcome).Returns(testOutcome);

				// Act
				Sut.PostTestInit(this, _mockTestExecutionEventArgs.Object);
				Sut.PostTestCleanup(this, _mockTestExecutionEventArgs.Object);

				// Assert
				Assert.That(_didRecord, Is.EqualTo(expectedDidRecord), $"Expected video to have {(expectedDidRecord ? "" : "not")} been recorded.");
			}

			[TestCase(TestOutcome.Failed, false)]
			[TestCase(TestOutcome.Inconclusive, false)]
			[TestCase(TestOutcome.Passed, true)]
			[TestCase(TestOutcome.Skipped, false)]
			[TestCase(TestOutcome.Warning, false)]
			[VideoRecording(VideoRecordingMode.OnlyPass)]
			public void VideoIsRecordedOnlyWhenTestPasses(TestOutcome testOutcome, bool expectedDidRecord)
			{
				// Assemble
				_mockTestExecutionEventArgs.Setup(x => x.TestOutcome).Returns(testOutcome);

				// Act
				Sut.PostTestInit(this, _mockTestExecutionEventArgs.Object);
				Sut.PostTestCleanup(this, _mockTestExecutionEventArgs.Object);

				// Assert
				Assert.That(_didRecord, Is.EqualTo(expectedDidRecord), $"Expected video to have {(expectedDidRecord ? "" : "not")} been recorded.");
			}
		}

		[TestFixture]
		[VideoRecording(VideoRecordingMode.Always)]
		public class ClassLevelAlwaysRecordTests : VideoRecorderTests
		{
			[TestCase(TestOutcome.Failed)]
			[TestCase(TestOutcome.Inconclusive)]
			[TestCase(TestOutcome.Passed)]
			[TestCase(TestOutcome.Skipped)]
			[TestCase(TestOutcome.Warning)]
			public void VideoRecordsIfClassLevelVideoRecordAttributeIsSetToRecordAlways(TestOutcome testOutcome)
			{
				// Assemble
				_mockTestExecutionEventArgs.Setup(x => x.TestOutcome).Returns(testOutcome);

				// Act
				Sut.PostTestInit(this, _mockTestExecutionEventArgs.Object);
				Sut.PostTestCleanup(this, _mockTestExecutionEventArgs.Object);

				// Assert
				Assert.That(_didRecord, Is.True, "Expected video to have been recorded.");
			}

			[TestCase(TestOutcome.Failed)]
			[TestCase(TestOutcome.Inconclusive)]
			[TestCase(TestOutcome.Passed)]
			[TestCase(TestOutcome.Skipped)]
			[TestCase(TestOutcome.Warning)]
			[VideoRecording(VideoRecordingMode.DoNotRecord)]
			public void MethodLevelAttributeOverridesClassLevelAttribute(TestOutcome testOutcome)
			{
				// Assemble
				_mockTestExecutionEventArgs.Setup(x => x.TestOutcome).Returns(testOutcome);

				// Act
				Sut.PostTestInit(this, _mockTestExecutionEventArgs.Object);
				Sut.PostTestCleanup(this, _mockTestExecutionEventArgs.Object);

				// Assert
				Assert.That(_didRecord, Is.False, "Expected video to have not been recorded.");
			}
		}

		public override void SetUp()
		{
			ResolveMock<AppSettings>().Setup(x => x.VideoRecording.EnableVideoRecording).Returns(true);

			ResolveMock<IVideoRecorder>()
				.Setup(x => x.Record(It.IsAny<string>(), It.IsAny<string>()))
				.Callback(() => _didRecord = true);

			ResolveMock<IVideoRecordingProvider>()
				.Setup(x => x.DeleteRecording(It.IsAny<string>()))
				.Callback(() => _didRecord = false);

			_mockTestExecutionEventArgs = ResolveMock<TestExecutionEventArgs>();
			_mockTestExecutionEventArgs.Setup(x => x.MemberInfo).Returns(GetType().GetMethod(TestContext.Test.MethodName));
			_mockTestExecutionEventArgs.Setup(x => x.TestName).Returns(TestContext.Test.MethodName);
		}
	}
}
