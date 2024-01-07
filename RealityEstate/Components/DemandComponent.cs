using Microsoft.AspNetCore.Mvc;
using RealityEstate.Models.Entities;
using RealityEstate.Models.Rights;

namespace RealityEstate.Components
{
    public class DemandComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Demand demand, User? user)
        {

            if(user != null)
            {
                this.ViewBag.User = user;   
            }

            return View(demand);
        }
    }
}
