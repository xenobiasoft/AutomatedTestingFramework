using System.Collections.Generic;
using AutomatedTestingFramework.Core.Controls;
using AutomatedTestingFramework.Selenium.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using By = AutomatedTestingFramework.Core.By;

namespace AutomatedTestingFramework.Selenium.Controls
{
	public class Element : IElement
	{
		protected readonly IWebElement WebElement;
		protected readonly IWebDriver Driver;
		protected readonly IElementFinderService ElementFinderService;

		public Element(IWebDriver driver, IWebElement webElement, IElementFinderService elementFinderService)
		{
			Driver = driver;
			WebElement = webElement;
			ElementFinderService = elementFinderService;
		}

		public void Click()
		{
			WebElement.Click();
		}

		public TElement Find<TElement>(By by) where TElement : class, IElement
		{
			return ElementFinderService.Find<TElement>(WebElement, by);
		}

		public IEnumerable<TElement> FindAll<TElement>(By by) where TElement : class, IElement
		{
			return ElementFinderService.FindAll<TElement>(WebElement, by);
		}

		public string GetAttribute(string attributeName)
		{
			return WebElement.GetAttribute(attributeName);
		}

		public bool IsElementPresent(By by)
		{
			return ElementFinderService.IsElementPresent(WebElement, by);
		}

		public void MouseClick()
		{
			var builder = new Actions(Driver);

			builder.MoveToElement(WebElement)
				.Click()
				.Build()
				.Perform();
		}

		public string CssClass => WebElement.GetAttribute("className");
		public virtual string Content => WebElement.Text;
		public bool IsVisible => WebElement.Displayed;
		public int Width => WebElement.Size.Width;
		public int Height => WebElement.Size.Height;
	}
}