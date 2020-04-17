namespace AutomatedTestingFramework.Core.Drivers
{
	public interface ICookieService
	{
		void AddCookie(string cookieName, string cookieValue, string host);
		void DeleteCookie(string cookieName);
		void DeleteAllCookies();
		string GetCookie(string host, string cookieName);
	}
}