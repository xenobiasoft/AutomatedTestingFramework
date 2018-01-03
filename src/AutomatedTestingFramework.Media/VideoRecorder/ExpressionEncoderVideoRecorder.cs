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
		private readonly int _height = Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.Bounds.Height % 16;
		private readonly int _width = Screen.PrimaryScreen.Bounds.Width - Screen.PrimaryScreen.Bounds.Width % 16;
		private ScreenCaptureJob _screenCaptureJob;
		private bool _isDisposed;

		public void StartCapture()
		{
			try
			{
				InitializeScreenCapture();
			}
			catch (Exception ex)
			{
				throw new VideoCaptureException($"Video capture failed with the following exception: {ex.Message}. Resolution: width - {_width}, height - {_height}.");
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
				throw new VideoCaptureException($"Video capture failed with the following exception: {ex.Message}. Resolution: width - {_width}, height - {_height}.");
			}
		}

		public void Dispose()
		{
			if (!_isDisposed)
			{
				if (Status == VideoRecordingStatus.Running)
				{
					StopCapture();
				}
				DeleteTempVideo();
				_isDisposed = true;
			}
		}

		private void InitializeScreenCapture()
		{
			Initialize();
			_screenCaptureJob.Start();
		}

		private void Initialize()
		{
			_isDisposed = false;
			_screenCaptureJob = new ScreenCaptureJob
			{
				CaptureMouseCursor = true,
				CaptureRectangle = new Rectangle(0, 0, _width, _height),
				OutputScreenCaptureFileName = MediaFileUtil.GetTempFilenameWithPath(MediaFileType.Wmv),
				ScreenCaptureVideoProfile =
				{
					AutoFit = true,
					Force16Pixels = true,
					FrameRate = FrameRate,
					Quality = Quality,
					Size = new Size(_width, _height)
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

				File.Move(_screenCaptureJob.OutputScreenCaptureFileName, moveToPath);
			}
			else
			{
				throw new VideoCaptureException($"The specified save location does not exist: {MediaFileUtil.MediaFolderPath}.");
			}
		}

		private void DeleteTempVideo()
		{
			if (File.Exists(_screenCaptureJob?.OutputScreenCaptureFileName))
			{
				File.Delete(_screenCaptureJob.OutputScreenCaptureFileName);
			}
		}

		private void StopCapture()
		{
			_screenCaptureJob.Stop();
		}

		public VideoRecordingStatus Status
		{
			get
			{
				if (_screenCaptureJob != null)
				{
					return (VideoRecordingStatus) _screenCaptureJob.Status;
				}

				return VideoRecordingStatus.NotStarted;
			}
		}
	}
}