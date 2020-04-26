using System;
using AutomatedTestingFramework.Selenium.Enums;

namespace AutomatedTestingFramework.Selenium.Attributes
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class VideoRecordingAttribute : Attribute
	{
		public VideoRecordingAttribute(VideoRecordingMode recordingMode)
		{
			VideoRecording = recordingMode;
		}

		public VideoRecordingMode VideoRecording { get; set; }
	}
}
