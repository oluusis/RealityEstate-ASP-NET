using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealityEstate.Controllers.AuthorizingClasses;
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

            if (tmp != null)
            {
                if (PasswordHasher.VerifyPassword(tmp.Password, model.Password))
                {
                    this.HttpContext.Session.SetString("login", tmp.ID.ToString());
                    return RedirectToAction(a ?? "Index", c ?? "Admin");
                }

                return View(model);
            }


            User usr = this.rightsService.Users.FirstOrDefault(x => x.LoginName == model.LoginName || x.Email == model.LoginName);

            if (usr != null)
            {
                if (PasswordHasher.VerifyPassword(usr.Password, model.Password))
                {
                    this.HttpContext.Session.SetString("loginUsr", usr.ID.ToString());
                    return RedirectToAction(a ?? "Index", c ?? "Home");
                }
            }

            return View(model);
        }

        public IActionResult Logout(string a = "")
        {
            if(a != "")
            {
                this.HttpContext.Session.Remove("loginUsr");
                return RedirectToAction(a, "Home");
            }

            this.HttpContext.Session.Remove("login");
            return RedirectToAction("Index");
        }
    }
}
