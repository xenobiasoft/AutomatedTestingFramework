﻿using AutomatedTestingFramework.Core.Controls;
using OpenQA.Selenium;
using By = AutomatedTestingFramework.Core.By;

namespace AutomatedTestingFramework.Selenium.Controls
{
	public class WebImage : ContentElement, IWebImage
	{
		public WebImage(IWebDriver driver, IWebElement webElement, By by)
			: base(driver, webElement, by)
		{ }

		public string AltText => WebElement.GetAttribute("alt");
		public string Src => WebElement.GetAttribute("src");
	}
}