namespace AutomatedTestingFramework.Selenium
{
	public class PageEventArgs
	{
		public PageEventArgs(string url)
		{
			Url = url;
		}

		public string Url { get; }
	}
}