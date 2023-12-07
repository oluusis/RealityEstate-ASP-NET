using Microsoft.AspNetCore.Mvc;
using RealityEstate.Models.Entities;

namespace RealityEstate.Components
{
    public class OfferComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Offer offer)
        {
            return View(offer);
        }
    }
}
