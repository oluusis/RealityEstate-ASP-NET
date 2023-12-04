using Microsoft.AspNetCore.Mvc;
using RealityEstate.Models.Database.Services;
using RealityEstate.Models.Entities;
using RealityEstate.Models.Rights;

namespace RealityEstate.Controllers
{
    public class DetailController : Controller
    {
        private OfferService offerService = OfferService.Instance;


        public IActionResult Index(int id)
        {
            this.ViewBag.Attributes = offerService.Context.Attributes.ToList();           

            Offer offer = this.offerService.Offerlist.FirstOrDefault(x => x.ID == id);

            if(offer != null)
            {
                return View(offer);
            }
            return RedirectToAction("Index","Home");
        }
    }
}
