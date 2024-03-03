using Microsoft.AspNetCore.Mvc;
using RealityEstate.Models.Entities;
using RealityEstate.Models.Rights;

namespace RealityEstate.Components
{
    public class DemandComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Demand demand)
        {
            return View(demand);
        }
    }
}
