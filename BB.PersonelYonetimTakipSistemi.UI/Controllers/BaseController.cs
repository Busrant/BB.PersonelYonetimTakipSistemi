using BB.PersonelYonetimTakipSistemi.UI.Helper;
using Microsoft.AspNetCore.Mvc;

namespace BB.PersonelYonetimTakipSistemi.UI.Controllers
{
    public class BaseController : Controller
    {
       public string Token { get { return CookieAction.GetCookie("token", Request); } }
    }
}
