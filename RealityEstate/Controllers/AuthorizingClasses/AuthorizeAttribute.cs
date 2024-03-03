using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using RealityEstate.Models.Database.Services;
using RealityEstate.Models.Rights;

namespace RealityEstate.Controllers.AuthorizingClasses
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

            if (controllerFrom.HttpContext.Session.GetString("login") != null)
            {
                RightsService service = new RightsService();
                AdminSeller admin = service.Find(Convert.ToInt32(controllerFrom.HttpContext.Session.GetString("login")));

                if (admin.Type == false)
                {
                    string c = controllerFrom.Request.RouteValues["controller"].ToString();
                    string a = controllerFrom.Request.RouteValues["action"].ToString();

                    context.Result = new RedirectToActionResult("Index", "Login", new { c, a });
                }
            }
        }
    }
}
