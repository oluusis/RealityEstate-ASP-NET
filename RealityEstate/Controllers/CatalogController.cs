using Microsoft.AspNetCore.Mvc;
using RealityEstate.Models.Database.Services;
using RealityEstate.Models.Entities;

namespace RealityEstate.Controllers
{
    public class CatalogController : Controller
    {
        private OfferService offerService;   

        public CatalogController()
        {
            this.offerService = OfferService.Instance;
        }


        public IActionResult Index(Filter filter)
        {
            List<Offer> offers = new List<Offer>();
            offers = GetFilteredOffers(filter);
            this.ViewBag.ShowNumber = filter.ListingStart;

            this.ViewBag.ShowedOffers = offers;
            return View();
        }


       public List<Offer> GetFilteredOffers(Filter filter)
       {
            List<Offer> list = this.offerService.Offerlist.ToList();

            if (filter.Size != null)
            {
                list = list.Where(x => x.Size == filter.Size).ToList();
            }

            if (filter.Type != null)
            {
                list = list.Where(x => x.Type == filter.Type).ToList();
            }

            if (filter.Region != null)
            {
                list = list.Where(x => x.Address == filter.Region).ToList();
            }

            if (filter.IDCategory != null)
            {
                list = list.Where(x => x.IDCategory == filter.IDCategory).ToList();
            }
            
            if(filter.MaxPrice != null && filter.MinPrice != null)
            {
                list = list.Where(x => x.Price >= filter.MinPrice && x.Price <= filter.MaxPrice).ToList();
            }
            
            return list;
       }
    }
}
