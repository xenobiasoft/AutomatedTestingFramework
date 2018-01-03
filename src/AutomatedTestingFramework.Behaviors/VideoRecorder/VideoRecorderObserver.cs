using System;
using System.Reflection;
using AutomatedTestingFramework.Core;
using AutomatedTestingFramework.Core.Config;
using AutomatedTestingFramework.Core.Enums;
using AutomatedTestingFramework.Core.ExecutionEngine;
using AutomatedTestingFramework.Media.VideoRecorder;

namespace AutomatedTestingFramework.Behaviors.VideoRecorder
{
	public class VideoRecorderObserver : BaseTestObserver
	{
		private readonly IVideoRecorder _videoRecorder;
		private VideoRecorderMode _videoRecorderMode;
		private readonly IAppConfiguration _appConfiguration;

		public VideoRecorderObserver(IVideoRecorder videoRecorder, IAppConfiguration appConfiguration)
		{
			_appConfiguration = appConfiguration;
			_videoRecorder = videoRecorder;
		}

		public override void PostTestInit(object sender, TestExecutionEventArgs e)
		{
			_videoRecorderMode = GetConfiguredVideoRecorderMode(e.MemberInfo);

			if (_videoRecorderMode != VideoRecorderMode.DoNotRecord)
			{
				_videoRecorder.StartCapture();
			}
		}

		private VideoRecorderMode GetConfiguredVideoRecorderMode(MemberInfo memberInfo)
		{
			var methodRecordingMode = GetVideoRecorderModeFromAttribute(memberInfo);
			var classRecordingMode = GetVideoRecorderModeFromAttribute(memberInfo.DeclaringType);
			var videoRecorderMode = VideoRecorderMode.DoNotRecord;
			var allowVideoRecording = _appConfiguration.AllowVideoRecording;

			if (methodRecordingMode != VideoRecorderMode.NotDefined && allowVideoRecording)
			{
				videoRecorderMode = methodRecordingMode;
			}
			else if (classRecordingMode != VideoRecorderMode.NotDefined && allowVideoRecording)
			{
				videoRecorderMode = classRecordingMode;
			}

			return videoRecorderMode;
		}

		private VideoRecorderMode GetVideoRecorderModeFromAttribute(MemberInfo memberInfo)
		{
			if (memberInfo == null)
			{
				throw new ArgumentNullException(nameof(memberInfo));
			}

			var recordingModeMethodAttribute = memberInfo.GetCustomAttribute<VideoRecorderAttribute>(true);

			if (recordingModeMethodAttribute != null)
			{
				return recordingModeMethodAttribute.VideoRecorderMode;
			}

			return VideoRecorderMode.NotDefined;
		}

		private VideoRecorderMode GetVideoRecorderModeFromAttribute(Type currentType)
		{
			if (currentType == null)
			{
				throw new ArgumentNullException(nameof(currentType));
			}

			var recordingModeClassAttribute = currentType.GetCustomAttribute<VideoRecorderAttribute>(true);

			if (recordingModeClassAttribute != null)
			{
				return recordingModeClassAttribute.VideoRecorderMode;
			}

			return VideoRecorderMode.NotDefined;
		}

		public override void PostTestCleanup(object sender, TestExecutionEventArgs e)
		{
			try
			{
				var testName = e.TestName;
				var hasTestPassed = e.TestOutcome.Equals(TestOutcome.Passed);

				SaveVideoDependingOnTestOutcome(testName, hasTestPassed);
			}
			finally
			{
				_videoRecorder.Dispose();
			}
		}

		private void SaveVideoDependingOnTestOutcome(string testName, bool hasTestPassed)
		{
			if (_videoRecorderMode != VideoRecorderMode.DoNotRecord && _videoRecorder.Status == VideoRecordingStatus.Running)
			{
				var shouldRecordAlways = _videoRecorderMode == VideoRecorderMode.Always;
				var shouldRecordForPassedTest = hasTestPassed && _videoRecorder.Status.Equals(VideoRecorderMode.OnlyPass);
				var shouldRecordForFailedTest = !hasTestPassed && _videoRecorder.Status.Equals(VideoRecorderMode.OnlyFail);

				if (shouldRecordAlways || shouldRecordForPassedTest || shouldRecordForFailedTest)
				{
					_videoRecorder.SaveVideo(testName);
				}
			}
		}
	}
}