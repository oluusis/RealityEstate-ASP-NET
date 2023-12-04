using System.ComponentModel;

namespace RealityEstate.Models.Entities
{
    public class Category
    {
        public int ID { get; set; }

        public string Name { get; set; }    

        public BindingList<Offer> Offers { get; set; }  

    }
}
