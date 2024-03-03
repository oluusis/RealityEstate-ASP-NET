using Microsoft.AspNetCore.Mvc;
using RealityEstate.Controllers.AuthorizingClasses;
using RealityEstate.Controllers.AuthorizingClass;
using RealityEstate.Models.Database.Services;
using RealityEstate.Models.Entities;
using RealityEstate.Models.Rights;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace RealityEstate.Controllers
{
    public class AdminController : SecuredController
    {
        private RightsService rightsService { get; set; }
        private OfferService offerService { get; set; }
        private ImageService imgService { get; set; }


        public AdminController(IWebHostEnvironment webHostEnvironment)
        {
            this.rightsService = new RightsService();
            this.offerService = new OfferService();
            this.imgService = new ImageService(webHostEnvironment);
        }

        public IActionResult Index()
        {
            return View();
        }

      

        public IActionResult Demands()
        {
            this.ViewBag.Demands = this.offerService.GetDemands();
            return View();
        }

        public IActionResult Offers()
        {
            AdminSeller admin = rightsService.Find(Convert.ToInt32(this.HttpContext.Session.GetString("login")));

            if(admin.Type == false)
            {
                this.ViewBag.Offers = this.offerService.Offerlist.Where(x => x.IDAdminSeller == admin.ID);
                return View(); 
            }

            this.ViewBag.Offers = this.offerService.Offerlist;
            return View();
        }


        public IActionResult Delete(int id, string a, string c, int idOffer)
        {
            switch (a)
            {
                case "Users":
                    this.rightsService.RemoveUser(id);
                    break;

                case "Demands":
                    this.offerService.RemoveDemand(id);
                    break;

                case "Offers":
                    this.offerService.RemoveOffer(id);
                    break;

                case "Attributes":
                    this.offerService.RemoveAttribute(id);
                    break;

                case "AttributeValues":
                    this.offerService.RemoveAttributeValue(id);
                    return RedirectToAction("AttributeValues",c, new { idOffer = idOffer}); 

                default:
                    return RedirectToAction(a, c);
            }
            this.offerService.Context.SaveChanges();

            return RedirectToAction(a, c);
        }


        [HttpGet]
        public IActionResult EditDemand(int id = 0)
        {
            this.ViewBag.Offers = this.offerService.Offerlist;
            this.ViewBag.Users = this.rightsService.Users;

            if (id == 0)
            {
                return this.View(new Demand());
            }

            return this.View(this.offerService.GetDemands().First(x => x.ID == id));
        }

        [HttpPost]
        public IActionResult EditDemand(Demand demand)
        {
            this.ViewBag.Offers = this.offerService.Offerlist;
            this.ViewBag.Users = this.rightsService.Users;
            

            if (this.ModelState.IsValid)
            {
                demand.IDOffer = demand.IDOffer;
                demand.IDUser = demand.IDUser == null ? null : demand.IDUser;

                this.offerService.SaveDemand(demand);
                return RedirectToAction("Demands");
            }
            return View(demand);
        }


        [HttpGet]
        public IActionResult EditOffer(int id = 0)
        {
            this.ViewBag.Categories = this.offerService.Context.Categories;
            this.ViewBag.Sellers = this.rightsService.AdminSellers;
            

            if (id == 0)
            {
                return this.View(new Offer());
            }

            return this.View(this.offerService.Offerlist.First(x => x.ID == id));
        }

        [HttpPost]
        public IActionResult EditOffer(Offer offer)
        {
            this.ViewBag.Categories = this.offerService.Context.Categories;
            this.ViewBag.Sellers = this.rightsService.AdminSellers;

            if (this.ModelState.IsValid)
            {
                this.offerService.SaveOffer(offer);

                if (offer.Image != null)
                {
                    this.imgService.UploadImage(offer.Image, offer.ID);
                }

                return RedirectToAction("Offers");
            }
            return View(offer);
        }

        public IActionResult OfferDetail(int id)
        {
            this.ViewBag.Offer = this.offerService.Find(id);

            return View();
        }

     
    }
}
