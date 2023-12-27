using Microsoft.AspNetCore.Mvc;
using RealityEstate.Models.Database.Services;
using RealityEstate.Models.Entities;
using RealityEstate.Models.Rights;

namespace RealityEstate.Controllers
{
    public class DetailController : Controller
    {
        private OfferService offerService = new OfferService();

        [HttpGet]
        public IActionResult Index(int id)
        {
            this.ViewBag.Attributes = offerService.Context.Attributes.ToList();
            this.ViewBag.Id = id;
            this.ViewBag.Demand = new Demand() { IDOffer = id };


            Offer offer = this.offerService.Offerlist.FirstOrDefault(x => x.ID == id);

            if(offer != null)
            {
                return View(offer);
            }

            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public IActionResult Index(int id, Demand demand)
        {
            if (this.ModelState.IsValid)
            {
                this.offerService.SaveDemand(demand);
                return RedirectToAction("Confirm");
            }

            this.ViewBag.Attributes = offerService.Context.Attributes.ToList();
            this.ViewBag.Id = id;
            this.ViewBag.Demand = demand;
            Offer offer = this.offerService.Offerlist.FirstOrDefault(x => x.ID == id);

            return View(offer);
        }

        public IActionResult Confirm()
        {
            return View();
        }
    }
}
