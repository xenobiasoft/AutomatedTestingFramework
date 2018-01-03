using AutomatedTestingFramework.Core.Controls;

namespace AutomatedTestingFramework.Selenium.Controls
{
	public class Frame : IFrame
	{
		public Frame(string frameName)
		{
			Name = frameName;
		}

		public string Name { get; }
	}
}