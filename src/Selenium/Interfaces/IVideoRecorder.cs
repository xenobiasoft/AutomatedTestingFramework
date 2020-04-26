using System;

namespace AutomatedTestingFramework.Selenium.Interfaces
{
	public interface IVideoRecorder : IDisposable
	{
		string Record(string filePath, string fileName);
		void Stop();
	}
}