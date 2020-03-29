﻿using AutomatedTestingFramework.Core.Elements;
using OpenQA.Selenium;
using By = AutomatedTestingFramework.Core.By;

namespace AutomatedTestingFramework.Selenium.Elements
{
	public class Checkbox : ContentElement, ICheckbox
	{
		public Checkbox(IWebDriver driver, IWebElement webElement, By by)
			: base(driver, webElement, by)
		{ }

		public bool IsChecked => Element.Selected;

		public void Check()
		{
			if (!Element.Selected)
			{
				Element.Click();
			}
		}

		public void Uncheck()
		{
			if (Element.Selected)
			{
				Element.Click();
			}
		}
	}
}