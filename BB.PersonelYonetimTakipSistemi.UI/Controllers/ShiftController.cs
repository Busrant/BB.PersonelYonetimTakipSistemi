using BB.PersonelYonetimTakipSistemi.Model.Requests;
using BB.PersonelYonetimTakipSistemi.UI.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.UI.Controllers
{
    public class ShiftController : BaseController
    {
        public IActionResult ShiftIndex()
        {
            return View();
        }
      
        public async Task<ActionResult> CreateShiftRequest(RequestsDto requests)
        {
            try
            {
                var res = await HttpAction.Post<RequestsDto>(requests, "/api/Request/create-dayoff-request", Token);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("401"))
                {
                    return RedirectToAction("Login", "Login");
                }

                throw ex;
            }
        }

    }
}
