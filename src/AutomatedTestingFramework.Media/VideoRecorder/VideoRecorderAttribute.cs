﻿using System;

namespace AutomatedTestingFramework.Media.VideoRecorder
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class VideoRecorderAttribute : Attribute
	{
		public VideoRecorderAttribute(VideoRecorderMode videoRecordingMode)
		{
			VideoRecorderMode = videoRecordingMode;
		}

		public VideoRecorderMode VideoRecorderMode { get; }
	}
}