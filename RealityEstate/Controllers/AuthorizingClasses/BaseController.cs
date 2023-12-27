using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RealityEstate.Controllers.AuthorizingClasses
{
    public class BaseController : Controller
    {
        // předá usera
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            this.ViewBag.Login = this.HttpContext.Session.GetString("login") != null;
        }
    }
}
