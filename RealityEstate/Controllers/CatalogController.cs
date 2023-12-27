using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            this.ViewBag.Categories = offerService.Context.Categories.ToList();   

            this.ViewBag.ShowedOffers = offers;
            return View(filter);
        }



       public List<Offer> GetFilteredOffers(Filter filter)
       {
            List<Offer> list = this.offerService.Offerlist.ToList();

            if (filter.Size.GetValueOrDefault(0) != 0)
            {
                list = list.Where(x => x.Size == filter.Size).ToList();
            }

            if (filter.RoomCount.GetValueOrDefault(0) != 0)
            {
                list = list.Where(x => x.Type.Substring(0,x.Type.IndexOf('+')) == filter.RoomCount.ToString()).ToList();
            }

            if (filter.BathCount.GetValueOrDefault(0) != 0)
            {
                list = list.Where(x => x.Type.Substring(x.Type.IndexOf('+')+1,1) == filter.BathCount.ToString()).ToList();
            }


            if (!string.IsNullOrWhiteSpace(filter.Region))
            {
                list = list.Where(x => x.Region == filter.Region).ToList();
            }

            if (filter.IDCategory.GetValueOrDefault(0) != 0)
            {
                list = list.Where(x => x.IDCategory == filter.IDCategory).ToList();
            }
            
            if(filter.MaxPrice.GetValueOrDefault(0) != 0)
            {
                list = list.Where(x => x.Price <= filter.MaxPrice).ToList();
            }

            if(filter.MinPrice.GetValueOrDefault(0) != 0)
            {
                list = list.Where(x => x.Price >= filter.MinPrice).ToList();
            }
            
            return list;
       }
    }
}
