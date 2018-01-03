namespace AutomatedTestingFramework.Core
{
	public class PageEventArgs
	{
		public PageEventArgs(string url)
		{
			Url = url;
		}

		public string Url { get; private set; }
	}
}