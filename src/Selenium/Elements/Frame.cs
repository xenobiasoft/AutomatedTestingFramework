using AutomatedTestingFramework.Core.Elements;

namespace AutomatedTestingFramework.Selenium.Elements
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