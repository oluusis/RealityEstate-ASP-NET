using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace RealityEstate.Controllers.Attributes
{
    public class AuthorizeAttribute : Attribute, IActionFilter
    {

        //atribut který požaduje ověření
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Controller controllerFrom = (Controller)context.Controller;

            if (controllerFrom.HttpContext.Session.GetString("login") == null)
            {
                string c = controllerFrom.Request.RouteValues["controller"].ToString();
                string a = controllerFrom.Request.RouteValues["action"].ToString();

                context.Result = new RedirectToActionResult("Index", "Login", new { c = c, a = a });
            }
        }
    }
}
