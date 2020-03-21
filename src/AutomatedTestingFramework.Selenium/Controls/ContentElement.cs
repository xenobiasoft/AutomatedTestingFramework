using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using AutomatedTestingFramework.Core.Controls;
using AutomatedTestingFramework.Media;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using By = AutomatedTestingFramework.Core.By;

namespace AutomatedTestingFramework.Selenium.Controls
{
	public class ContentElement : Element, IContentElement
	{
		public ContentElement(IWebDriver driver, IWebElement webElement, By by)
			: base(driver, webElement, by)
		{ }

		public bool IsEnabled => WebElement.Enabled;

		public void Focus()
		{
			var action = new Actions(Driver);

			action.MoveToElement(WebElement).Perform();
		}

		public void Hover()
		{
			var action = new Actions(Driver);

			action.MoveToElement(WebElement).Perform();
		}

		public void TakeScreenshot()
		{
			var screenshot = Driver.TakeScreenshot();
			var screenshotFilename = MediaFileUtil.GetDateFormattedFilenameWithPath(GetType().Name, MediaFileType.Png);

			using (var memStream = new MemoryStream(screenshot.AsByteArray))
			{
				using (var bmp = new Bitmap(memStream))
				{
					var newSize = GetScreenshotSize(bmp.Size);
					var cropArea = new Rectangle(WebElement.Location, newSize);

					using (var croppedBmp = bmp.Clone(cropArea, bmp.PixelFormat))
					{
						croppedBmp.Save(screenshotFilename, ImageFormat.Png);
					}
				}
			}
		}

		public Size GetScreenshotSize(Size originalSize)
		{
			var newSize = new Size(Math.Min(originalSize.Width, WebElement.Size.Width), Math.Min(originalSize.Height, WebElement.Size.Height));

			newSize.Width = newSize.Width - WebElement.Location.X;
			newSize.Height = newSize.Height - WebElement.Location.Y;

			return newSize;
		}
	}
}