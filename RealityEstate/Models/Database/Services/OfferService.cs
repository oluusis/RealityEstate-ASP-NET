namespace RealityEstate.Models.Database.Services
{
    using Models.Database.Context;
    using Models.Rights;
    using RealityEstate.Models.Entities;
    using System.ComponentModel;

    public class OfferService
    {
        public Context Context { get; set; }

        public BindingList<Offer> Offerlist { get; set; } //{ get => offerslist; set => offerslist = value; }


        private static OfferService instance = null;
        public static OfferService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OfferService();
                }
                return instance;
            }
        }


        public OfferService()
        {
            this.Context = Context.Instance;
            this.Offerlist = new BindingList<Offer>(this.Context.Offers.ToList());

            for (int i = 0; i < Offerlist.Count; i++)
            {
                Offer tmp = Offerlist[i];   
                tmp.Attributes = GetAttributesValues(tmp);
                tmp.AdminSeller = FindSeller(tmp.IDAdminSeller);
                tmp.Category = GetCategory(tmp.IDCategory);
                tmp.Images = GetImages(tmp.ID);
                tmp.Demands = GetDemands(tmp.ID);
            }
        }

        //může být parametr který by hledal
        public BindingList<Offer> GetAll()
        {
            return new BindingList<Offer>(this.Context.Offers.ToList());
        }

        public void AddDemand(Demand demand)
        {
            this.Context.Demands.Add(demand);
            this.Context.SaveChanges();
        }

        //public List<Offer> GetAll(int idCategory)
        //{
        //    return  this.Offerlist.Where(x => x.IDCategory == idCategory).ToList();
        //}

        public Offer Find(int id)
        {
            return this.Context.Offers.ToList().First(x => x.ID == id);
        }

        public List<AttributeValue> GetAttributesValues(Offer offer)
        {
            return this.Context.AttributesValues.Where(x => x.IDOffer == offer.ID).ToList<AttributeValue>();
        }

        public BindingList<Attribute> GetAttributes()
        {
            return new BindingList<Attribute>(this.Context.Attributes.ToList());
        }

        public AdminSeller FindSeller(int id)
        {
            return this.Context.AdminSellers.First(x => x.ID == id);
        }

        public Category GetCategory(int id)
        {
            return this.Context.Categories.First(x => x.ID == id);
        }

        public List<Image> GetImages(int id)
        {
            return this.Context.Images.Where(x => x.IDOffer == id).ToList();
        }

        public List<Demand> GetDemands(int id)
        {
            return this.Context.Demands.Where(x => x.IDOffer == id).ToList();
        }
    }
}
