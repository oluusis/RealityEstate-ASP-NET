using Microsoft.AspNetCore.Mvc;
using RealityEstate.Models.Database.Services;
using RealityEstate.Models.Entities;

namespace RealityEstate.Controllers
{
    public class CatalogController : Controller
    {
        private OfferService offerService;
        private CategoryService categoryService;    

        public CatalogController()
        {
            this.offerService = OfferService.Instance;
            this.categoryService = CategoryService.Instance;

        }
        public IActionResult Index(string sort = "", object? value = null)
        {
            List<Offer> offers = new List<Offer>();
            offers = GetOffers(sort, value);

            this.ViewBag.ShowedOffers = offers;
            return View();
        }

       public List<Offer> GetOffers(string sort, object? value)
       {
            switch (sort)
            {
                case "category":
                        return this.categoryService.CategoryList.First(x => x.ID == (int)value).Offers.ToList();


                default:
                    return this.offerService.Offerlist.ToList();
            }

       }
    }
}
