using System;
using System.Reflection;
using AutomatedTestingFramework.Core.Config;
using AutomatedTestingFramework.Core.Enums;
using AutomatedTestingFramework.Core.ExecutionEngine;
using AutomatedTestingFramework.Media.VideoRecorder;

namespace AutomatedTestingFramework.Behaviors.VideoRecorder
{
	public class VideoRecorderObserver : BaseTestObserver
	{
		private readonly IVideoRecorder _VideoRecorder;
		private VideoRecorderMode _VideoRecorderMode;
		private readonly IAppConfiguration _AppConfiguration;

		public VideoRecorderObserver(IVideoRecorder videoRecorder, IAppConfiguration appConfiguration)
		{
			_AppConfiguration = appConfiguration;
			_VideoRecorder = videoRecorder;
		}

		public override void PostTestInit(object sender, TestExecutionEventArgs e)
		{
			_VideoRecorderMode = GetConfiguredVideoRecorderMode(e.MemberInfo);

			if (_VideoRecorderMode != VideoRecorderMode.DoNotRecord)
			{
				_VideoRecorder.StartCapture();
			}
		}

		private VideoRecorderMode GetConfiguredVideoRecorderMode(MemberInfo memberInfo)
		{
			var methodRecordingMode = GetVideoRecorderModeFromAttribute(memberInfo);
			var classRecordingMode = GetVideoRecorderModeFromAttribute(memberInfo.DeclaringType);
			var videoRecorderMode = VideoRecorderMode.DoNotRecord;
			var allowVideoRecording = _AppConfiguration.AllowVideoRecording;

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
				throw new ArgumentNullException("The test method MemberInfo info cannot be null.");
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
				throw new ArgumentNullException("The test method's type cannot be null.");
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
				_VideoRecorder.Dispose();
			}
		}

		private void SaveVideoDependingOnTestOutcome(string testName, bool hasTestPassed)
		{
			if (_VideoRecorderMode != VideoRecorderMode.DoNotRecord && _VideoRecorder.Status == VideoRecordingStatus.Running)
			{
				var shouldRecordAlways = _VideoRecorderMode == VideoRecorderMode.Always;
				var shouldRecordForPassedTest = hasTestPassed && _VideoRecorder.Status.Equals(VideoRecorderMode.OnlyPass);
				var shouldRecordForFailedTest = !hasTestPassed && _VideoRecorder.Status.Equals(VideoRecorderMode.OnlyFail);

				if (shouldRecordAlways || shouldRecordForPassedTest || shouldRecordForFailedTest)
				{
					_VideoRecorder.SaveVideo(testName);
				}
			}
		}
	}
}