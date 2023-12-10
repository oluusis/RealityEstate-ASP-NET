using Microsoft.AspNetCore.Mvc;
using RealityEstate.Controllers.AuthorizingClass;

namespace RealityEstate.Controllers
{
    public class AdminController : SecuredController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
