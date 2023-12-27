namespace RealityEstate.Models.Database.Services
{
    using RealityEstate.Models.Database.Context;
    using RealityEstate.Models.Entities;
    using System.ComponentModel;

    public class CategoryService
    {
        public Context Context { get; set; }
        public BindingList<Category> CategoryList { get; set; }

        private static CategoryService instance = null;
        public static CategoryService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryService();
                }
                return instance;
            }
        }

        public CategoryService()
        {
            this.Context = new Context();
            this.CategoryList = new BindingList<Category>(Context.Categories.ToList());

            for (int i = 0; i < CategoryList.Count; i++)
            {
                CategoryList[i].Offers = new BindingList<Offer>( this.Context.Offers.Where(x => x.IDCategory == CategoryList[i].ID).ToList());      
            }
        }
    }
}
