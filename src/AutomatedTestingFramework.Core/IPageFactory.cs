namespace AutomatedTestingFramework.Core
{
	public interface IPageFactory
	{
		TPage GetPage<TPage>() where TPage : PartialPage;
	}
}