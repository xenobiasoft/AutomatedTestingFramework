namespace AutomatedTestingFramework.Core.Drivers
{
	public interface ICookieService
	{
		string GetCookie(string host, string cookieName);
		void AddCookie(string cookieName, string cookieValue, string host);
		void DeleteCookie(string cookieName);
		void ClearAllCookies();
	}
}