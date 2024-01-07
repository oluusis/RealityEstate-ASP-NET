namespace RealityEstate.Models.Database.Services
{

    using Models.Database.Context;
    using Models.Rights;
    using RealityEstate.Models.Entities;
    using System.ComponentModel;

    public class ImageService
    {
        public Context Context { get; set; }

        public ImageService() 
        { 
            this.Context = new Context();   
        }

        public void Delete(string imgPath)
        {
            Image img = this.Context.Images.First(x => x.Path == imgPath);

            this.Context.Images.Remove(img);
            this.Context.SaveChanges();
        }

        public void Add(string imgPath)
        {
            this.Context.Add(imgPath);
            this.Context.SaveChanges();
        }
    }
}
