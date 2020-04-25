using AutomatedTestingFramework.Selenium.Configuration;

namespace Bellatrix.PageModels
{
	public static class PageUrls
	{
		public static string GetPageUrl(string partialPageUrl)
		{
			return $"{ConfigurationService.Instance.GetSettings<AppSettings>("appSettings").BaseUrl}{partialPageUrl}";
		}
	}
}
