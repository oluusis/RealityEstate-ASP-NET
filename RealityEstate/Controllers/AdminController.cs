using Microsoft.AspNetCore.Mvc;
using RealityEstate.Controllers.AuthorizingClasses;
using RealityEstate.Controllers.AuthorizingClass;
using RealityEstate.Models.Database.Services;
using RealityEstate.Models.Entities;
using RealityEstate.Models.Rights;

namespace RealityEstate.Controllers
{
    public class AdminController : SecuredController
    {
        private RightsService rightsService { get; set; }
        private OfferService offerService { get; set; }

        public AdminController()
        {
            this.rightsService = new RightsService();
            this.offerService = new OfferService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Users()
        {
            this.ViewBag.Users = this.rightsService.Users;

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

        public IActionResult AttributeValues(int idOffer = 0)
        {
            
            if (idOffer == 0)
            {
                return RedirectToAction("Index");
            }
            this.ViewBag.Attributes = offerService.Context.Attributes.ToList();
            this.ViewBag.IDOffer = idOffer;
            this.ViewBag.OfferName = this.offerService.Offerlist.First(x => x.ID == idOffer).Name;

            return this.View(this.offerService.Context.AttributesValues.ToList().Where(x => x.IDOffer == idOffer).ToList());
        }

        [Authorize]
        public IActionResult Attributes()
        {
            this.ViewBag.Attributes = this.offerService.GetAttributes();
            return View();
        }

        public IActionResult Delete(int id, string a, int idOffer)
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
                    return RedirectToAction("AttributeValues", new { idOffer = idOffer}); 

                default:
                    return RedirectToAction(a);
            }
            this.offerService.Context.SaveChanges();

            return RedirectToAction(a);
        }

        [Authorize]
        [HttpGet]
        public IActionResult EditUser(int id = 0)
        {
            if (id == 0)
            {
                return this.View(new User());
            }

            return this.View(rightsService.Users.First(x => x.ID == id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditUser(User user)
        {
            if (this.ModelState.IsValid)
            {
                this.rightsService.SaveUser(user);
                return RedirectToAction("Users");
            }
            return View(user);
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
                return RedirectToAction("Offers");
            }
            return View(offer);
        }

        public IActionResult OfferDetail(int id)
        {
            this.ViewBag.Offer = this.offerService.Find(id);

            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult EditAttribute(int id = 0)
        { 
            if (id == 0)
            {
                return this.View(new Models.Entities.Attribute());
            }
            return this.View(this.offerService.GetAttributes().First(x => x.ID == id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditAttribute(Models.Entities.Attribute attribute)
        {
            if (this.ModelState.IsValid)
            {
                this.offerService.SaveAttribute(attribute);
                return RedirectToAction("Attributes");
            }
            return View(attribute);
        }

        [HttpGet]
        public IActionResult Profil(int id)
        {
            return View(this.rightsService.Find(id));
        }

        [HttpPost]
        public IActionResult Profil(AdminSeller admin)
        {
            if (this.ModelState.IsValid)
            {
                this.rightsService.UpdateAdmin(admin);
                return RedirectToAction("Index");
            }
            return View(admin);
        }



        [HttpGet]
        public IActionResult EditAttributeValue(int id = 0, int idOffer = 0, int idAttribute = 0)
        {
            this.ViewBag.NameAttribute = this.offerService.GetAttributes().First(x => x.ID == idAttribute).Name;

            if (id == 0)
            {
                return this.View(new AttributeValue() { IDOffer = idOffer , IDAttribute = idAttribute});
            }
            return this.View(this.offerService.Context.AttributesValues.First(x => x.ID == id));
        }

        [HttpPost]
        public IActionResult EditAttributeValue(AttributeValue attributeValue)
        {
            this.ViewBag.NameAttribute = this.offerService.GetAttributes().First(x => x.ID == attributeValue.IDAttribute).Name;

            if (this.ModelState.IsValid)
            {
                this.offerService.SaveAttributeValue(attributeValue);
                return RedirectToAction("AttributeValues", new {idOffer = attributeValue.IDOffer});
            }
            return View(attributeValue);
        }


    }
}
