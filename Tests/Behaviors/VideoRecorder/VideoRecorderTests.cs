using System;
using System.Reflection;
using AutomatedTestingFramework.Behaviors.VideoRecorder;
using AutomatedTestingFramework.Core.Config;
using AutomatedTestingFramework.Core.Enums;
using AutomatedTestingFramework.Media.VideoRecorder;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestExecutionEventArgs = AutomatedTestingFramework.Core.ExecutionEngine.TestExecutionEventArgs;

namespace AutomatedTestingFramework.Tests.Behaviors.VideoRecorder
{
	[TestClass]
	public class VideoRecorderTests : BaseTest<VideoRecorderObserver>
	{
		private Mock<IVideoRecorder> _MockVideoRecorder;
		private Mock<IAppConfiguration> _MockAppConfiguration;
		private Mock<TestExecutionEventArgs> _MockTestExecutionEventArgs;

		[TestClass]
		public class PostTestInitTests : VideoRecorderTests
		{
			[TestMethod]
			[TestCategory(TestCategories.Behaviors)]
			public void VideoDoesNotRecordWhenConfigurationIsSetToDisableRecording()
			{
				// Assemble
				_MockAppConfiguration.Setup(x => x.AllowVideoRecording).Returns(false);

				// Act
				Uut.PostTestInit(this, _MockTestExecutionEventArgs.Object);

				// Assert
				_MockVideoRecorder.Verify(x => x.StartCapture(), Times.Never);
			}

			[TestMethod]
			[TestCategory(TestCategories.Behaviors)]
			[VideoRecorder(VideoRecorderMode.Always)]
			public void VideoRecordsIfMethodLevelAttributeIsSetToRecordAlways()
			{
				// Assemble

				// Act
				Uut.PostTestInit(this, _MockTestExecutionEventArgs.Object);

				// Assert
				_MockVideoRecorder.Verify(x => x.StartCapture(), Times.Once);
			}

			[TestMethod]
			[TestCategory(TestCategories.Behaviors)]
			[VideoRecorder(VideoRecorderMode.Always)]
			public void WhenTestExecutionEventArgsMemberInfoIsNullThrowsArgumentNullException()
			{
				// Assemble
				_MockTestExecutionEventArgs.Setup(x => x.MemberInfo).Returns((MemberInfo)null);

				// Act
				Action postTestInit = () => Uut.PostTestInit(this, _MockTestExecutionEventArgs.Object);

				// Assert
				postTestInit.ShouldThrow<ArgumentNullException>().WithMessage("*The test method MemberInfo info cannot be null.");
			}
		}

		[TestClass]
		public class PostTestCleanupTests : VideoRecorderTests
		{
			[TestMethod]
			[VideoRecorder(VideoRecorderMode.OnlyFail)]
			[TestCategory(TestCategories.Behaviors)]
			public void VideoRecordsIfTestFailsAndAttributeSetToOnlyFail()
			{
				// Assemble
				_MockTestExecutionEventArgs.Setup(x => x.TestOutcome).Returns(TestOutcome.Failed);
				_MockVideoRecorder.Setup(x => x.Status).Returns(VideoRecordingStatus.Running);

				// Act
				Uut.PostTestCleanup(this, _MockTestExecutionEventArgs.Object);

				// Assert
				_MockVideoRecorder.Verify(x => x.SaveVideo(It.IsAny<string>()), Times.Once);
			}

			[TestMethod]
			[VideoRecorder(VideoRecorderMode.OnlyPass)]
			[TestCategory(TestCategories.Behaviors)]
			public void VideoRecordsIfTestPassesAndAttributeSetToOnlyPass()
			{
				// Assemble
				_MockTestExecutionEventArgs.Setup(x => x.TestOutcome).Returns(TestOutcome.Passed);
				_MockVideoRecorder.Setup(x => x.Status).Returns(VideoRecordingStatus.Running);

				// Act
				Uut.PostTestCleanup(this, _MockTestExecutionEventArgs.Object);

				// Assert
				_MockVideoRecorder.Verify(x => x.SaveVideo(It.IsAny<string>()), Times.Once);
			}
		}

		[TestClass]
		[VideoRecorder(VideoRecorderMode.Always)]
		public class ClassLevelAlwaysRecordTests : VideoRecorderTests
		{
			[TestMethod]
			[TestCategory(TestCategories.Behaviors)]
			public void VideoRecordsIfClassLevelVideoRecordAttributeIsSetToRecordAlways()
			{
				// Assemble

				// Act
				Uut.PostTestInit(this, _MockTestExecutionEventArgs.Object);

				// Assert
				_MockVideoRecorder.Verify(x => x.StartCapture(), Times.Once);
			}

			[TestMethod]
			[VideoRecorder(VideoRecorderMode.DoNotRecord)]
			[TestCategory(TestCategories.Behaviors)]
			public void MethodLevelAttributeOverridesClassLevelAttribute()
			{
				// Assemble

				// Act
				Uut.PostTestInit(this, _MockTestExecutionEventArgs.Object);

				// Assert
				_MockVideoRecorder.Verify(x => x.StartCapture(), Times.Never);
			}
		}

		[TestInitialize]
		public void TestInit()
		{
			_MockVideoRecorder = ResolveMock<IVideoRecorder>();
			_MockAppConfiguration = ResolveMock<IAppConfiguration>();
			_MockAppConfiguration.Setup(x => x.AllowVideoRecording).Returns(true);
			
			_MockTestExecutionEventArgs = ResolveMock<TestExecutionEventArgs>();
			_MockTestExecutionEventArgs.Setup(x => x.MemberInfo).Returns(GetType().GetMethod(TestContext.TestName));
			_MockTestExecutionEventArgs.Setup(x => x.TestName).Returns(TestContext.TestName);
		}
	}
}