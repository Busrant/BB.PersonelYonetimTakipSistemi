using BB.PersonelYonetimTakipSistemi.Data.Model;
using BB.PersonelYonetimTakipSistemi.Model.Employees;
using BB.PersonelYonetimTakipSistemi.UI.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BB.PersonelYonetimTakipSistemi.UI.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public async Task<ActionResult> UpdatePassword(string companyEmail, string password)
        {
            try
            {
                var url = "/api/Employees/update-password?companyEmail=" + companyEmail + "&password=" + password;
                var res = await HttpAction.Get<EmployeeDto>(url);
                if (res.Data != null && res.Success)
                {
                    return Redirect("/Login/Login");
                }
                else
                {
                    return Redirect("/Register/Index");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
