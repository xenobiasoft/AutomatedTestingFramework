using System;
using System.Reflection;
using AutomatedTestingFramework.Core.Config;
using AutomatedTestingFramework.Core.Enums;
using AutomatedTestingFramework.Core.ExecutionEngine;
using AutomatedTestingFramework.Media.VideoRecorder;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TestExecutionEventArgs = AutomatedTestingFramework.Core.ExecutionEngine.TestExecutionEventArgs;

namespace AutomatedTestingFramework.Tests.Media.VideoRecorder
{
	[TestFixture]
	public class VideoRecorderTests : AutoMockingFixtureByInterface<VideoRecorderObserver, ITestObserver>
	{
		private Mock<IVideoRecorder> _mockVideoRecorder;
		private Mock<IAppConfiguration> _mockAppConfiguration;
		private Mock<TestExecutionEventArgs> _mockTestExecutionEventArgs;

		[TestFixture]
		public class PostTestInitTests : VideoRecorderTests
		{
			[Test]
			[Category(TestCategories.Core)]
			public void VideoDoesNotRecordWhenConfigurationIsSetToDisableRecording()
			{
				// Assemble
				_mockAppConfiguration.Setup(x => x.AllowVideoRecording).Returns(false);

				// Act
				Sut.PostTestInit(this, _mockTestExecutionEventArgs.Object);

				// Assert
				_mockVideoRecorder.Verify(x => x.StartCapture(), Times.Never);
			}

			[Test]
			[Category(TestCategories.Core)]
			[VideoRecorder(VideoRecorderMode.Always)]
			public void VideoRecordsIfMethodLevelAttributeIsSetToRecordAlways()
			{
				// Assemble

				// Act
				Sut.PostTestInit(this, _mockTestExecutionEventArgs.Object);

				// Assert
				_mockVideoRecorder.Verify(x => x.StartCapture(), Times.Once);
			}

			[Test]
			[Category(TestCategories.Core)]
			[VideoRecorder(VideoRecorderMode.Always)]
			public void WhenTestExecutionEventArgsMemberInfoIsNullThrowsArgumentNullException()
			{
				// Assemble
				_mockTestExecutionEventArgs.Setup(x => x.MemberInfo).Returns((MemberInfo)null);

				// Act
				Action postTestInit = () => Sut.PostTestInit(this, _mockTestExecutionEventArgs.Object);

				// Assert
				postTestInit.ShouldThrow<ArgumentNullException>().WithMessage("Value cannot be null.\r\nParameter name: memberInfo");
			}
		}

		[TestFixture]
		public class PostTestCleanupTests : VideoRecorderTests
		{
			[Test]
			[VideoRecorder(VideoRecorderMode.OnlyFail)]
			[Category(TestCategories.Core)]
			public void VideoRecordsIfTestFailsAndAttributeSetToOnlyFail()
			{
				// Assemble
				_mockTestExecutionEventArgs.Setup(x => x.TestOutcome).Returns(TestOutcome.Failed);
				_mockVideoRecorder.Setup(x => x.Status).Returns(VideoRecordingStatus.Running);

				// Act
				Sut.PostTestCleanup(this, _mockTestExecutionEventArgs.Object);

				// Assert
				_mockVideoRecorder.Verify(x => x.SaveVideo(It.IsAny<string>()), Times.Once);
			}

			[Test]
			[VideoRecorder(VideoRecorderMode.OnlyPass)]
			[Category(TestCategories.Core)]
			public void VideoRecordsIfTestPassesAndAttributeSetToOnlyPass()
			{
				// Assemble
				_mockTestExecutionEventArgs.Setup(x => x.TestOutcome).Returns(TestOutcome.Passed);
				_mockVideoRecorder.Setup(x => x.Status).Returns(VideoRecordingStatus.Running);

				// Act
				Sut.PostTestCleanup(this, _mockTestExecutionEventArgs.Object);

				// Assert
				_mockVideoRecorder.Verify(x => x.SaveVideo(It.IsAny<string>()), Times.Once);
			}
		}

		[TestFixture]
		[VideoRecorder(VideoRecorderMode.Always)]
		public class ClassLevelAlwaysRecordTests : VideoRecorderTests
		{
			[Test]
			[Category(TestCategories.Core)]
			public void VideoRecordsIfClassLevelVideoRecordAttributeIsSetToRecordAlways()
			{
				// Assemble

				// Act
				Sut.PostTestInit(this, _mockTestExecutionEventArgs.Object);

				// Assert
				_mockVideoRecorder.Verify(x => x.StartCapture(), Times.Once);
			}

			[Test]
			[VideoRecorder(VideoRecorderMode.DoNotRecord)]
			[Category(TestCategories.Core)]
			public void MethodLevelAttributeOverridesClassLevelAttribute()
			{
				// Assemble

				// Act
				Sut.PostTestInit(this, _mockTestExecutionEventArgs.Object);

				// Assert
				_mockVideoRecorder.Verify(x => x.StartCapture(), Times.Never);
			}
		}

		public override void SetUp()
		{
			_mockVideoRecorder = ResolveMock<IVideoRecorder>();
			_mockAppConfiguration = ResolveMock<IAppConfiguration>();
			_mockAppConfiguration.Setup(x => x.AllowVideoRecording).Returns(true);
			
			_mockTestExecutionEventArgs = ResolveMock<TestExecutionEventArgs>();
			_mockTestExecutionEventArgs.Setup(x => x.MemberInfo).Returns(GetType().GetMethod(TestContext.CurrentContext.Test.Name));
			_mockTestExecutionEventArgs.Setup(x => x.TestName).Returns(TestContext.CurrentContext.Test.Name);
		}
	}
}