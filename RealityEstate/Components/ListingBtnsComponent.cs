using Microsoft.AspNetCore.Mvc;
using RealityEstate.Models.Entities;

namespace RealityEstate.Components
{
    public class ListingBtnsComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int number, int offerCount)
        {
            this.ViewBag.ShowNumber = number;
            this.ViewBag.ShowedOffersCount = offerCount;

            return View();
        }
    }
}
