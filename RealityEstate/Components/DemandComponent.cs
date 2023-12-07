using Microsoft.AspNetCore.Mvc;
using RealityEstate.Models.Entities;
using System.Net.Http.Headers;

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
