using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using RealityEstate.Controllers.AuthorizingClasses;

namespace RealityEstate.Controllers.AuthorizingClass
{
    public class SecuredController : BaseController
    {

        //musí se přihlast na jaký koli akci
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (this.HttpContext.Session.GetString("login") == null)
            {
                string c = this.Request.RouteValues["controller"].ToString();
                string a = this.Request.RouteValues["action"].ToString();

                context.Result = new RedirectToActionResult("Index", "Login", new { c = c, a = a });
            }
        }
    }
}
