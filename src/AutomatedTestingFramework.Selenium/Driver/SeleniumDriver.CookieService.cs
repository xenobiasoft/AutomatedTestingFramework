using AutomatedTestingFramework.Core.Driver;
using OpenQA.Selenium;

namespace AutomatedTestingFramework.Selenium.Driver
{
	public partial class SeleniumDriver : ICookieService
	{
		public string GetCookie(string host, string cookieName)
		{
			var cookie = _driver.Manage().Cookies.GetCookieNamed(cookieName);

			return cookie.Value;
		}

		public void AddCookie(string cookieName, string cookieValue, string host)
		{
			var cookie = new Cookie(cookieName, cookieValue);

			_driver.Manage().Cookies.AddCookie(cookie);
		}

		public void DeleteCookie(string cookieName)
		{
			_driver.Manage().Cookies.DeleteCookieNamed(cookieName);
		}

		public void ClearAllCookies()
		{
			_driver.Manage().Cookies.DeleteAllCookies();
		}
	}
}