using Microsoft.AspNetCore.Mvc;
using RealityEstate.Controllers.AuthorizingClasses;
using RealityEstate.Controllers.AuthorizingClass;
using RealityEstate.Models.Database.Services;
using RealityEstate.Models.Entities;
using RealityEstate.Models.Rights;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace RealityEstate.Controllers
{
    public class AdminAttributesController : SecuredController
    {
        private RightsService rightsService { get; set; }
        private OfferService offerService { get; set; }
        private ImageService imgService { get; set; }


        public AdminAttributesController(IWebHostEnvironment webHostEnvironment)
        {
            this.rightsService = new RightsService();
            this.offerService = new OfferService();
            this.imgService = new ImageService(webHostEnvironment);
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Admin");
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
        public IActionResult EditAttributeValue(int id = 0, int idOffer = 0, int idAttribute = 0)
        {
            this.ViewBag.NameAttribute = this.offerService.GetAttributes().First(x => x.ID == idAttribute).Name;

            if (id == 0)
            {
                return this.View(new AttributeValue() { IDOffer = idOffer, IDAttribute = idAttribute });
            }
            return this.View(this.offerService.Context.AttributesValues.First(x => x.ID == id));
        }

        [HttpPost]
        public IActionResult EditAttributeValue(AttributeValue attributeValue)
        {
            this.ViewBag.NameAttribute = this.offerService.GetAttributes().FirstOrDefault(x => x.ID == attributeValue.IDAttribute).Name;

            if (this.ModelState.IsValid)
            {
                this.offerService.SaveAttributeValue(attributeValue);
                return RedirectToAction("AttributeValues", new { idOffer = attributeValue.IDOffer });
            }
            return View(attributeValue);
        }
    }
}
