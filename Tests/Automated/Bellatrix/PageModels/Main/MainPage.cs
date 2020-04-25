using AutomatedTestingFramework.Selenium.Configuration;
using AutomatedTestingFramework.Selenium.Interfaces.Drivers;

namespace Bellatrix.PageModels.Main
{
	public class MainPage : NavigatableEShopPage<MainPage>
	{
		private readonly IElementWaitService _waitService;

		public MainPage(IDriver driver) : base(driver)
		{
			_waitService = driver;
			Elements = new MainPageElements(driver);
			Asserts = new MainPageAssertions(Elements);
		}

		protected override string Url => ConfigurationService.Instance.GetSettings<AppSettings>("webSettings").BaseUrl;
		public MainPageElements Elements { get; }
		public MainPageAssertions Asserts { get; }

		public void SelectARocket(string rocketName)
		{
			Elements
				.GetProductBoxByName(rocketName)
				.Click();
			_waitService.WaitForPageToLoad();
		}

		protected override void WaitForPageLoad()
		{
			_waitService.WaitForElementToExist(Elements.GetProductBoxByName("Falcon 9").By);
		}
	}
}
