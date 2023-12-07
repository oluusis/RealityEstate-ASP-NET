using Microsoft.AspNetCore.Mvc;
using RealityEstate.Models.Database.Services;
using RealityEstate.Models.Entities;
using RealityEstate.Models.Rights;

namespace RealityEstate.Controllers
{
    public class DetailController : Controller
    {
        private OfferService offerService = OfferService.Instance;

        [HttpGet]
        public IActionResult Index(int id, Demand? demand)
        {
            this.ViewBag.Attributes = offerService.Context.Attributes.ToList();

            this.ViewBag.Demand = demand.IDOffer == 0 ? new Demand() { IDOffer = id } : demand; // vypnít id usera


            Offer offer = this.offerService.Offerlist.FirstOrDefault(x => x.ID == id);

            if(offer != null)
            {
                return View(offer);
            }

            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public IActionResult Index(Demand demand)
        {
            if (this.ModelState.IsValid)
            {
                offerService.AddDemand(demand);
                return RedirectToAction("Confirm");
            }

            return RedirectToAction("Index", new { id = demand.IDOffer, demand = demand });
        }

        public IActionResult Confirm()
        {
            return View();
        }
    }
}
