using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomatedTestingFramework.Selenium.Elements
{
	public class WebElement : Element
	{
		protected readonly IWebElement Element;
		protected readonly IWebDriver Driver;

		public WebElement(IWebDriver driver, IWebElement webElement, By by)
		{
			By = by;
			Driver = driver;
			Element = webElement;
		}

		public override By By { get; }
		public override string CssClass => Element?.GetAttribute("className");
		public override bool? Displayed => Element?.Displayed;
		public override bool? Enabled => Element?.Enabled;
		public override int? Height => Element?.Size.Height;
		public override int? Width => Element?.Size.Width;

		public override void Click()
		{
			Element?.Click();
		}

		public override void Focus()
		{
			var action = new Actions(Driver);

			action.MoveToElement(Element).Perform();
		}

		public override string GetAttribute(string attributeName) => Element?.GetAttribute(attributeName);

		public override void Hover()
		{
			var action = new Actions(Driver);

			action.MoveToElement(Element).Perform();
		}
	}
}