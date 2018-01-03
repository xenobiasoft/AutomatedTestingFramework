using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Expression.Encoder.ScreenCapture;

namespace AutomatedTestingFramework.Media.VideoRecorder
{
	public class ExpressionEncoderVideoRecorder : IVideoRecorder
	{
		private const int FrameRate = 5;
		private const int Quality = 20;
		private readonly int _Height = Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.Bounds.Height % 16;
		private readonly int _Width = Screen.PrimaryScreen.Bounds.Width - Screen.PrimaryScreen.Bounds.Width % 16;
		private ScreenCaptureJob _ScreenCaptureJob;
		private bool _IsDisposed;

		public void StartCapture()
		{
			try
			{
				InitializeScreenCapture();
			}
			catch (Exception ex)
			{
				throw new VideoCaptureException($"Video capture failed with the following exception: {ex.Message}. Resolution: width - {_Width}, height - {_Height}.");
			}
		}

		public void SaveVideo(string testName)
		{
			try
			{
				FinalizeScreenCapture(testName);
			}
			catch (Exception ex)
			{
				throw new VideoCaptureException($"Video capture failed with the following exception: {ex.Message}. Resolution: width - {_Width}, height - {_Height}.");
			}
		}

		public void Dispose()
		{
			if (!_IsDisposed)
			{
				if (Status == VideoRecordingStatus.Running)
				{
					StopCapture();
				}
				DeleteTempVideo();
				_IsDisposed = true;
			}
		}

		private void InitializeScreenCapture()
		{
			Initialize();
			_ScreenCaptureJob.Start();
		}

		private void Initialize()
		{
			_IsDisposed = false;
			_ScreenCaptureJob = new ScreenCaptureJob
			{
				CaptureMouseCursor = true,
				CaptureRectangle = new Rectangle(0, 0, _Width, _Height),
				OutputScreenCaptureFileName = MediaFileUtil.GetTempFilenameWithPath(MediaFileType.Wmv),
				ScreenCaptureVideoProfile =
				{
					AutoFit = true,
					Force16Pixels = true,
					FrameRate = FrameRate,
					Quality = Quality,
					Size = new Size(_Width, _Height)
				},
				ShowFlashingBoundary = true
			};
		}

		private void FinalizeScreenCapture(string testName)
		{
			StopCapture();

			if (MediaFileUtil.MediaFolderExists())
			{
				var moveToPath = MediaFileUtil.GetDateFormattedFilenameWithPath(testName, MediaFileType.Wmv);

				File.Move(_ScreenCaptureJob.OutputScreenCaptureFileName, moveToPath);
			}
			else
			{
				throw new VideoCaptureException($"The specified save location does not exist: {MediaFileUtil.MediaFolderPath}.");
			}
		}

		private void DeleteTempVideo()
		{
			if (File.Exists(_ScreenCaptureJob?.OutputScreenCaptureFileName))
			{
				File.Delete(_ScreenCaptureJob.OutputScreenCaptureFileName);
			}
		}

		private void StopCapture()
		{
			_ScreenCaptureJob.Stop();
		}

		public VideoRecordingStatus Status
		{
			get
			{
				if (_ScreenCaptureJob != null)
				{
					return (VideoRecordingStatus) _ScreenCaptureJob.Status;
				}

				return VideoRecordingStatus.NotStarted;
			}
		}
	}
}