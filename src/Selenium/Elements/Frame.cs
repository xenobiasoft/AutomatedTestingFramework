using AutomatedTestingFramework.Selenium.Interfaces.Elements;

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