namespace RealityEstate.Models.Database.Services
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Models.Database.Context;
    using Models.Rights;
    using RealityEstate.Models.Entities;
    using System.ComponentModel;

    public class ImageService
    {
        public Context Context { get; set; }
        private readonly IWebHostEnvironment _env;

        public ImageService(IWebHostEnvironment env) 
        { 
            this.Context = new Context();  
            this._env = env;
        }

        public void UploadProfilPhoto(IFormFile formfile, int idAdmin)
        {
            try
            {
                string wwwrootPath = this._env.WebRootPath;

                string filePath = Path.Combine(wwwrootPath, "podklady\\") + formfile.FileName;

                AdminSeller admin = this.Context.AdminSellers.First(x => x.ID == idAdmin);   
              

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);

                }
                using (FileStream stream = System.IO.File.Create(filePath))
                {
                    formfile.CopyToAsync(stream);
                }

                admin.ImagePath = @"\podklady\" + formfile.FileName;
                this.Context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }




        public void UploadImage(List<IFormFile> formfiles, int idOffer)
        {
                try
                {
                    for (int i = 0; i < formfiles.Count; i++)
                    {
                    string wwwrootPath = _env.WebRootPath;

                    string filePath = Path.Combine(wwwrootPath, "podklady\\") + formfiles[i].FileName;

                    Image img = this.Context.Images.FirstOrDefault(x => x.Path == filePath);

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                        this.Context.Images.Remove(img);

                    }
                    using (FileStream stream = System.IO.File.Create(filePath))
                    {
                        formfiles[i].CopyToAsync(stream);
                        if (img == null)
                        {
                            img = new Image() { IDOffer = idOffer, Path = @"\podklady\" + formfiles[i].FileName };
                            this.Context.Images.Add(img);
                        }
                        else
                        {
                            img.Path = @"\podklady\" + formfiles[i].FileName; ;
                        }

                    }

                }
                this.Context.SaveChanges();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            
        }
    }
}
