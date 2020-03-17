using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.New
{
	public abstract class Element
	{
		public abstract By By { get; }
		public abstract bool? Displayed { get; }
		public abstract bool? Enabled { get; }
		public abstract string Text { get; }
		public abstract void Click();
		public abstract string GetAttribute(string attributeName);
		public abstract void TypeText(string text);
	}
}
