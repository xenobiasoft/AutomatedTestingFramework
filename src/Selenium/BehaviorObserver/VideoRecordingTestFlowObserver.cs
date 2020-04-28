using System;
using System.Reflection;
using AutomatedTestingFramework.Selenium.Attributes;
using AutomatedTestingFramework.Selenium.Enums;
using AutomatedTestingFramework.Selenium.Interfaces;

namespace AutomatedTestingFramework.Selenium.BehaviorObserver
{
	public class VideoRecordingTestFlowObserver : BaseTestObserver
	{
		private readonly IVideoRecorder _videoRecorder;
		private readonly IVideoRecordingProvider _videoRecorderOutputProvider;

		private VideoRecordingMode _recordingMode;
		private string _videoRecordingPath;

		public VideoRecordingTestFlowObserver(ITestExecutionSubject testExecutionProvider, IVideoRecorder videoRecorder, IVideoRecordingProvider videoRecorderOutputProvider) : base(testExecutionProvider)
		{
			_videoRecorderOutputProvider = videoRecorderOutputProvider;
			_videoRecorder = videoRecorder;
			testExecutionProvider.Attach(this);
		}

		public override void PostTestInit(object sender, TestExecutionEventArgs e)
		{
			_recordingMode = ConfigureTestVideoRecordingMode(e.MemberInfo);

			if (_recordingMode == VideoRecordingMode.DoNotRecord) return;

			var fullTestName = $"{e.MemberInfo.DeclaringType.Name}.{e.TestName}";
			var videoRecordingDir = _videoRecorderOutputProvider.GetOutputFolder();
			var videoRecordingFileName = _videoRecorderOutputProvider.GetUniqueFileName(fullTestName);

			_videoRecordingPath = _videoRecorder.Record(videoRecordingDir, videoRecordingFileName);
		}

		public override void PostTestCleanup(object sender, TestExecutionEventArgs e)
		{
			_recordingMode = ConfigureTestVideoRecordingMode(e.MemberInfo);

			if (_recordingMode == VideoRecordingMode.DoNotRecord) return;

			try
			{
				DeleteVideoDependingOnTestOutcome(e.TestOutcome);
			}
			finally
			{
				_videoRecorder.Dispose();
			}
		}

		private void DeleteVideoDependingOnTestOutcome(TestOutcome testOutcome)
		{
			if (_recordingMode == VideoRecordingMode.DoNotRecord) return;

			var shouldRecordAlways = _recordingMode == VideoRecordingMode.Always;
			var shouldRecordAllPassed = testOutcome == TestOutcome.Passed && _recordingMode == VideoRecordingMode.OnlyPass;
			var shouldRecordAllFailed = testOutcome == TestOutcome.Failed && _recordingMode == VideoRecordingMode.OnlyFail;

			if (shouldRecordAlways || shouldRecordAllFailed || shouldRecordAllPassed) return;

			_videoRecorder.Stop();

			_videoRecorderOutputProvider.DeleteRecording(_videoRecordingPath);
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

			return recordingModeMethodAttribute?.VideoRecording ?? VideoRecordingMode.Ignore;
		}

		private VideoRecordingMode GetVideoRecordingModeFromAttribute(Type currentType)
		{
			if (currentType == null)
			{
				throw new ArgumentNullException(nameof(currentType));
			}

			var recordingModeClassAttribute = currentType.GetCustomAttribute<VideoRecordingAttribute>(true);

			return recordingModeClassAttribute?.VideoRecording ?? VideoRecordingMode.Ignore;
		}
	}
}
