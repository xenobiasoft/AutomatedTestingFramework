﻿using AutomatedTestingFramework.Core.Driver;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.Driver
{
	public partial class WebDriver : BaseDriver, ICookieService
	{
		public override string GetCookie(string host, string cookieName)
		{
			var cookie = _driver.Manage().Cookies.GetCookieNamed(cookieName);

			return cookie.Value;
		}

		public override void AddCookie(string cookieName, string cookieValue, string host)
		{
			var cookie = new Cookie(cookieName, cookieValue);

			_driver.Manage().Cookies.AddCookie(cookie);
		}

		public override void DeleteCookie(string cookieName)
		{
			_driver.Manage().Cookies.DeleteCookieNamed(cookieName);
		}

		public override void ClearAllCookies()
		{
			_driver.Manage().Cookies.DeleteAllCookies();
		}
	}
}