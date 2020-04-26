using System;
using System.IO;
using System.Reflection;
using AutomatedTestingFramework.Selenium.Attributes;
using AutomatedTestingFramework.Selenium.Enums;
using AutomatedTestingFramework.Selenium.Interfaces;

namespace AutomatedTestingFramework.Selenium.BehaviorObserver
{
	public class VideoRecordingTestFlowObserver : BaseTestObserver
	{
		private readonly IVideoRecorder _videoRecorder;
		private readonly IVideoRecorderOutputProvider _videoRecorderOutputProvider;

		private VideoRecordingMode _recordingMode;
		private string _videoRecordingPath;

		public VideoRecordingTestFlowObserver(ITestExecutionSubject testExecutionProvider, IVideoRecorder videoRecorder, IVideoRecorderOutputProvider videoRecorderOutputProvider) : base(testExecutionProvider)
		{
			_videoRecorderOutputProvider = videoRecorderOutputProvider;
			_videoRecorder = videoRecorder;
			testExecutionProvider.Attach(this);
		}

		public override void PostTestInit(object sender, TestExecutionEventArgs e)
		{
			_recordingMode = ConfigureTestVideoRecordingMode(e.MemberInfo);

			if (_recordingMode != VideoRecordingMode.DoNotRecord)
			{
				var fullTestName = $"{e.MemberInfo.DeclaringType.Name}.{e.TestName}";
				var videoRecordingDir = _videoRecorderOutputProvider.GetOutputFolder();
				var videoRecordingFileName = _videoRecorderOutputProvider.GetUniqueFileName(fullTestName);

				_videoRecordingPath = _videoRecorder.Record(videoRecordingDir, videoRecordingFileName);
			}
		}

		public override void PostTestCleanup(object sender, TestExecutionEventArgs e)
		{
			if (_recordingMode != VideoRecordingMode.DoNotRecord)
			{
				try
				{
					var hasTestPassed = e.TestOutcome == TestOutcome.Passed;
					DeleteVideoDependingOnTestOutcome(hasTestPassed);
				}
				finally
				{
					_videoRecorder.Dispose();
				}
			}
		}

		private void DeleteVideoDependingOnTestOutcome(bool hasTestPassed)
		{
			if (_recordingMode == VideoRecordingMode.DoNotRecord) return;

			var shouldRecordAlways = _recordingMode == VideoRecordingMode.Always;
			var shouldRecordAllPassed = hasTestPassed && _recordingMode == VideoRecordingMode.OnlyPass;
			var shouldRecordAllFailed = !hasTestPassed && _recordingMode == VideoRecordingMode.OnlyFail;

			if (shouldRecordAlways || shouldRecordAllFailed || shouldRecordAllPassed) return;

			_videoRecorder.Stop();

			if (File.Exists(_videoRecordingPath))
			{
				File.Delete(_videoRecordingPath);
			}
		}

		private VideoRecordingMode ConfigureTestVideoRecordingMode(MemberInfo memberInfo)
		{
			var methodRecordingMode = GetVideoRecordingModeFromAttribute(memberInfo);
			var classRecordingMode = GetVideoRecordingModeFromAttribute(memberInfo.DeclaringType);
			var videoRecordingMode = VideoRecordingMode.DoNotRecord;

			var videoRecordingEnabled = _videoRecorderOutputProvider.VideoRecordingEnabled;

			if (methodRecordingMode != VideoRecordingMode.Ignore && videoRecordingEnabled)
			{
				videoRecordingMode = methodRecordingMode;
			}
			else if (classRecordingMode != VideoRecordingMode.Ignore && videoRecordingEnabled)
			{
				videoRecordingMode = classRecordingMode;
			}

			return videoRecordingMode;
		}

		private VideoRecordingMode GetVideoRecordingModeFromAttribute(MemberInfo memberInfo)
		{
			if (memberInfo == null)
			{
				throw new ArgumentNullException(nameof(memberInfo));
			}

			var recordingModeMethodAttribute = memberInfo.GetCustomAttribute<VideoRecordingAttribute>(true);

			if (recordingModeMethodAttribute != null)
			{
				return recordingModeMethodAttribute.VideoRecording;
			}

			return VideoRecordingMode.Ignore;
		}

		private VideoRecordingMode GetVideoRecordingModeFromAttribute(Type currentType)
		{
			if (currentType == null)
			{
				throw new ArgumentNullException(nameof(currentType));
			}

			var recordingModeClassAttribute = currentType.GetCustomAttribute<VideoRecordingAttribute>(true);

			if (recordingModeClassAttribute != null)
			{
				return recordingModeClassAttribute.VideoRecording;
			}

			return VideoRecordingMode.Ignore;
		}
	}
}
