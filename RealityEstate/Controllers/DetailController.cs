using Microsoft.AspNetCore.Mvc;
using RealityEstate.Controllers.AuthorizingClasses;
using RealityEstate.Models.Database.Services;
using RealityEstate.Models.Entities;
using RealityEstate.Models.Rights;

namespace RealityEstate.Controllers
{
    public class DetailController : BaseController
    {
        private OfferService offerService = new OfferService();

        [HttpGet]
        public IActionResult Index(int id)
        {
            this.ViewBag.Attributes = offerService.Context.Attributes.ToList();
            this.ViewBag.Id = id;
            this.ViewBag.Demand = new Demand() { IDOffer = id, IDUser = Convert.ToInt32(this.HttpContext.Session.GetString("loginUsr")) };

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
                this.offerService.SaveDemand(demand);
                demand = new Demand() { IDOffer = demand.IDOffer };
                this.ViewBag.ShowAlert = true;
                return RedirectToAction("Index");
            }

            this.ViewBag.Attributes = offerService.Context.Attributes.ToList();
            this.ViewBag.Demand = demand;
            Offer offer = this.offerService.Offerlist.FirstOrDefault(x => x.ID == demand.IDOffer);

            return View(offer);
        }
    }
}
