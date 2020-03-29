using System;
using System.Collections.Generic;
using AutomatedTestingFramework.Core.Elements;
using AutomatedTestingFramework.Core.Enums;
using AutomatedTestingFramework.Core.ExceptionAnalysis;

namespace AutomatedTestingFramework.Core.Drivers
{
	public abstract class BaseDriver : IDriver
	{
		public abstract TElement Find<TElement>(By by) where TElement : class, IElement;
		public abstract IEnumerable<TElement> FindAll<TElement>(By by) where TElement : class, IElement;
		public abstract bool IsElementPresent(By by);
		public abstract event EventHandler<PageEventArgs> Navigated;
		public abstract string Url { get; }
		public abstract string Title { get; }
		public abstract IExceptionAnalyzer ExceptionAnalyzer { get; set; }
		public abstract void GoToUrl(string url);
		public abstract string GetCookie(string host, string cookieName);
		public abstract void AddCookie(string cookieName, string cookieValue, string host);
		public abstract void DeleteCookie(string cookieName);
		public abstract void ClearAllCookies();
		public abstract void Handle(Action action = null, DialogButton dialogButton = DialogButton.Ok);
		public abstract void Upload(string filePath);
		public abstract TType InvokeScript<TType>(string script);
		public abstract void ClickBackButton();
		public abstract void ClickForwardButton();
		public abstract void ClickRefresh();
		public abstract IFrame GetFrame(string frameName);
		public abstract void MaximizeBrowserWindow();
		public abstract void Quit();
		public abstract void SwitchToDefault();
		public abstract void SwitchToFrame(IFrame frame);
		public abstract void WaitForAjax();
		public abstract void WaitForPageToLoad();
		public abstract string Source { get; }
		public abstract void Start(Browser browser);
	}
}
