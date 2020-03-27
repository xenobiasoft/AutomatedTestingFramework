using System;
using System.Reflection;
using AutomatedTestingFramework.Core.Config;
using AutomatedTestingFramework.Core.Enums;
using AutomatedTestingFramework.Core.ExecutionEngine;

namespace AutomatedTestingFramework.Media.VideoRecorder
{
	public class VideoRecorderObserver : BaseTestObserver
	{
		private readonly IVideoRecorder _videoRecorder;
		private readonly IAppConfiguration _appConfiguration;

		public VideoRecorderObserver(
			ITestExecutionSubject testExecutionSubject,
			IVideoRecorder videoRecorder,
			IAppConfiguration appConfiguration)
			: base(testExecutionSubject)
		{
			_appConfiguration = appConfiguration;
			_videoRecorder = videoRecorder;
		}

		public override void PostTestInit(object sender, TestExecutionEventArgs e)
		{
			var videoRecorderMode = GetConfiguredVideoRecorderMode(e.MemberInfo);

			if (videoRecorderMode != VideoRecorderMode.DoNotRecord)
			{
				_videoRecorder.StartCapture();
			}
		}

		public override void PostTestCleanup(object sender, TestExecutionEventArgs e)
		{
			try
			{
				var videoRecorderMode = GetConfiguredVideoRecorderMode(e.MemberInfo);
				var testName = e.TestName;
				var hasTestPassed = e.TestOutcome.Equals(TestOutcome.Passed);

				SaveVideoDependingOnTestOutcome(testName, hasTestPassed, videoRecorderMode);
			}
			finally
			{
				_videoRecorder.Dispose();
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

		private void SaveVideoDependingOnTestOutcome(string testName, bool hasTestPassed, VideoRecorderMode videoRecorderMode)
		{
			if (videoRecorderMode != VideoRecorderMode.DoNotRecord && _videoRecorder.Status == VideoRecordingStatus.Running)
			{
				var shouldRecordAlways = videoRecorderMode == VideoRecorderMode.Always;
				var shouldRecordForPassedTest = hasTestPassed && videoRecorderMode == VideoRecorderMode.OnlyPass;
				var shouldRecordForFailedTest = !hasTestPassed && videoRecorderMode == VideoRecorderMode.OnlyFail;

				if (shouldRecordAlways || shouldRecordForPassedTest || shouldRecordForFailedTest)
				{
					_videoRecorder.SaveVideo(testName);
				}
			}
		}
	}
}