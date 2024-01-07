using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RealityEstate.Models.Database.Services;

namespace RealityEstate.Controllers.AuthorizingClasses
{
    public class BaseController : Controller
    {
        private RightsService rightsService { get; set; }

        public BaseController()
        {
            this.rightsService = new RightsService();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);


            if (this.HttpContext.Session.GetString("loginUsr") != null)
            {
                this.ViewBag.Login = true;
                int usrID = Convert.ToInt32(this.HttpContext.Session.GetString("loginUsr"));
                this.ViewBag.User = this.rightsService.Users.First(x => x.ID == usrID);
               // return;
            }

            if (this.HttpContext.Session.GetString("login") != null)
            {
                this.ViewBag.Login = true;
                int adminID = Convert.ToInt32(this.HttpContext.Session.GetString("login"));
                this.ViewBag.Admin = this.rightsService.Find(adminID);
            }
        }
    }
}
