using Microsoft.AspNetCore.Mvc;
using RealityEstate.Controllers.AuthorizingClass;
using RealityEstate.Controllers.AuthorizingClasses;
using RealityEstate.Models.Database.Services;
using RealityEstate.Models.Rights;

namespace RealityEstate.Controllers
{
    public class AdminRightsController : SecuredController
    {
        private RightsService rightsService { get; set; }
        private OfferService offerService { get; set; }
        private ImageService imgService { get; set; }


        public AdminRightsController(IWebHostEnvironment webHostEnvironment)
        {
            this.rightsService = new RightsService();
            this.offerService = new OfferService();
            this.imgService = new ImageService(webHostEnvironment);
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
        public IActionResult Profil(int id)
        {
            return View(this.rightsService.Find(id));
        }

        [HttpPost]
        public IActionResult Profil(AdminSeller admin)
        {
            if (this.ModelState.IsValid)
            {
                this.imgService.UploadProfilPhoto(admin.Image, admin.ID);
                this.rightsService.UpdateAdmin(admin);
                return RedirectToAction("Index", "Admin");
            }
            return View(admin);
        }

        [Authorize]
        public IActionResult Users()
        {
            this.ViewBag.Users = this.rightsService.Users;

            return View();
        }
    }
}
