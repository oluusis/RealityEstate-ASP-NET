using Microsoft.AspNetCore.Mvc;
using RealityEstate.Controllers.AuthorizingClasses;
using RealityEstate.Models;
using RealityEstate.Models.Database.Services;
using RealityEstate.Models.Entities;
using System.Diagnostics;

namespace RealityEstate.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private OfferService offerService;
        private CategoryService categoryService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            this.offerService = new OfferService();
            this.categoryService = new CategoryService();
        }

        public IActionResult Index(bool showAll = true, int number = 0) 
        {
            this.ViewBag.Categories = this.categoryService.CategoryList;
            this.ViewBag.ShowNumber =  number;

            if (showAll)
            {
                this.ViewBag.ShowedOffers = this.offerService.Offerlist.Where(x => x.Showed == true).ToList();
            }

            return View();
        }

        public IActionResult Category(int id)
        {
            return RedirectToAction("Index", "Catalog", new Filter { IDCategory = id });
        }

        public IActionResult Region()
        {
            return RedirectToAction("Index", "Catalog", new Filter { Region = Request.Form["RegionName"] });
        }

        public IActionResult Price()
        {
            this.ViewBag.ShowedOffers = this.offerService.Offerlist.OrderByDescending(x => x.Price);
            return RedirectToAction("Index", new { showAll = false });
        }

        public IActionResult Type(string type)
        {
            this.ViewBag.ShowedOffers = this.offerService.Offerlist.Where(x => x.Type == type);
            return RedirectToAction("Index", new { showAll = false });
        }

        public IActionResult Size(int size)
        {
            this.ViewBag.ShowedOffers = this.offerService.Offerlist.Where(x => x.Size == size);
            return RedirectToAction("Index", new { showAll = false });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}