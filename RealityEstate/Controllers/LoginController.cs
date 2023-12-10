
using Microsoft.AspNetCore.Mvc;
using RealityEstate.Models.Database.Services;
using RealityEstate.Models.Rights;

namespace RealityEstate.Controllers
{
    public class LoginController : Controller
    {
        private RightsService rightsService = new RightsService();

        [HttpGet]
        public IActionResult Index(string c, string a)
        {
            this.ViewBag.ControllerName = c;
            this.ViewBag.ActionName = a;   

            return View(new AdminSeller());
        }

        [HttpPost]
        public IActionResult Index(AdminSeller model, string c, string a)
        {
            AdminSeller tmp = this.rightsService.AdminSellers.FirstOrDefault(x => x.LoginName == model.LoginName || x.Email == model.LoginName);

            if (tmp == null)
            {
                return View(model);
            }

            if(tmp.Password == model.Password)
            {
                this.HttpContext.Session.SetString("login", tmp.ToString());
                return RedirectToAction( a ??  "Index", c ?? "Admin");
            }


            return View(model);
        }

        public IActionResult Logout()
        {
            this.HttpContext.Session.Remove("login");
            return RedirectToAction("Index");
        }
    }
}
