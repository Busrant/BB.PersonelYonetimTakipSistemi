using BB.PersonelYonetimTakipSistemi.Helper.Enum;
using BB.PersonelYonetimTakipSistemi.Model.Employees;
using BB.PersonelYonetimTakipSistemi.Model.Result;
using BB.PersonelYonetimTakipSistemi.UI.Helper;
using BB.PersonelYonetimTakipSistemi.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.UI.Controllers
{

    public class LoginController : BaseController
    {
        public ActionResult Login()
        {
            
                return View();
            
        }

        public async Task<IActionResult> Login2(AuthenticateRequest authenticateRequest)
        {
            try
            {

                var res = await HttpAction.Post<AuthenticateRequest>(authenticateRequest, "/api/Users/authenticade");

                var rr = JsonConvert.DeserializeObject<DataResultDto<AuthenticateResponse>>(res);

                if (rr.Success)

                {

                    CookieOptions option = new CookieOptions();

                    option.Expires = DateTime.Now.AddDays(1);

                    Response.Cookies.Append("token", rr.Data.JwtToken, option);

                    return RedirectToAction("Index", "Home");

                }
                return RedirectToAction("Login", "Login");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Login");
            }


        }

        public ActionResult Logout()
        {
            Response.Cookies.Delete("token", new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true
            });
            return RedirectToAction("Login", "Login");
        }




    }
}
