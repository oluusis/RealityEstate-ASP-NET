using RealityEstate.Models.Entities;
using System.ComponentModel;

namespace RealityEstate.Models.Database.Services
{
    using RealityEstate.Models.Database.Context;
    using RealityEstate.Models.Rights;

    public class RightsService
    {
        public Context Context { get; set; }
        public BindingList<AdminSeller> AdminSellers { get; set; }
        public BindingList<User> Users { get; set; }

        private static CategoryService instance;
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


        public RightsService()
        {
            this.Context = Context.Instance;
            this.AdminSellers = new BindingList<AdminSeller>(Context.AdminSellers.ToList());
        }
    }
}
