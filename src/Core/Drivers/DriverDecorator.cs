﻿using System;
using System.Collections.Generic;
using AutomatedTestingFramework.Core.Elements;
using AutomatedTestingFramework.Core.Enums;
using AutomatedTestingFramework.Core.ExceptionAnalysis;

namespace AutomatedTestingFramework.Core.Drivers
{
	public abstract class DriverDecorator : BaseDriver
	{
		protected readonly BaseDriver Driver;

		protected DriverDecorator(BaseDriver driver)
		{
			Driver = driver;
		}

		public override void Start(Browser browser)
		{
			Driver?.Start(browser);
		}

		public override void AddCookie(string cookieName, string cookieValue, string host)
		{
			Driver?.AddCookie(cookieName, cookieValue, host);
		}

		public override void ClearAllCookies()
		{
			Driver?.ClearAllCookies();
		}

		public override void ClickBackButton()
		{
			Driver?.ClickBackButton();
		}

		public override void ClickForwardButton()
		{
			Driver?.ClickForwardButton();
		}

		public override void ClickRefresh()
		{
			Driver?.ClickRefresh();
		}

		public override void DeleteCookie(string cookieName)
		{
			Driver?.DeleteCookie(cookieName);
		}

		public override TElement Find<TElement>(By by)
		{
			return Driver?.Find<TElement>(by);
		}

		public override IEnumerable<TElement> FindAll<TElement>(By by)
		{
			return Driver?.FindAll<TElement>(by);
		}

		public override string GetCookie(string host, string cookieName)
		{
			return Driver?.GetCookie(host, cookieName);
		}

		public override IFrame GetFrame(string frameName)
		{
			return Driver?.GetFrame(frameName);
		}

		public override void Handle(Action action = null, DialogButton dialogButton = DialogButton.Ok)
		{
			Driver?.Handle(action, dialogButton);
		}

		public override TType InvokeScript<TType>(string script)
		{
			return Driver.InvokeScript<TType>(script);
		}

		public override bool IsElementPresent(By by)
		{
			return Driver.IsElementPresent(by);
		}

		public override void MaximizeBrowserWindow()
		{
			Driver?.MaximizeBrowserWindow();
		}

		public override void GoToUrl(string url)
		{
			Driver?.GoToUrl(url);
		}

		public override void Quit()
		{
			Driver?.Quit();
		}

		public override void SwitchToDefault()
		{
			Driver?.SwitchToDefault();
		}

		public override void SwitchToFrame(IFrame frame)
		{
			Driver?.SwitchToFrame(frame);
		}

		public override void Upload(string filePath)
		{
			Driver?.Upload(filePath);
		}

		public override void WaitForAjax()
		{
			Driver?.WaitForAjax();
		}

		public override void WaitForPageToLoad()
		{
			Driver?.WaitForPageToLoad();
		}

		public override IExceptionAnalyzer ExceptionAnalyzer
		{
			get => Driver?.ExceptionAnalyzer;
			set => Driver.ExceptionAnalyzer = value;
		}

		public override event EventHandler<PageEventArgs> Navigated;

		public override string Source => Driver?.Source;

		public override string Title => Driver?.Title;

		public override string Url => Driver?.Url;
	}
}
