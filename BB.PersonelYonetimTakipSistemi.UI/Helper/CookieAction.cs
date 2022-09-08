using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.UI.Helper
{
    public static class CookieAction
    {
        public static async Task<bool> DeleteCookie(string Key, HttpRequest httpRequest, HttpResponse httpResponse)
        {
            if (string.IsNullOrEmpty(Key))
            {
                return false;
            }



            if (httpRequest.Cookies[Key] != null)
            {
                httpResponse.Cookies.Delete(Key);
                return true;
            }



            return false;
        }
        public static string GetCookie(string Key, HttpRequest httpRequest)
        {
            if (string.IsNullOrEmpty(Key))
            {
                return "";
            }



            if (httpRequest.Cookies[Key] != null)
            {
                return httpRequest.Cookies[Key].ToString();
            }
            return "";



        }
    }
}
