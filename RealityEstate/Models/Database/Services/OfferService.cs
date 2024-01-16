namespace RealityEstate.Models.Database.Services
{
    using Models.Database.Context;
    using Models.Rights;
    using RealityEstate.Models.Entities;
    using System.ComponentModel;

    public class OfferService
    {
        public Context Context { get; set; }

        public BindingList<Offer> Offerlist { get; set; } 
        public List<Image> Images { get; set; }

        public OfferService()
        {
            this.Context = new Context();
            this.Offerlist = new BindingList<Offer>(this.Context.Offers.ToList());
            this.Images = this.Context.Images.ToList();

            for (int i = 0; i < Offerlist.Count; i++)
            {
                Offer tmp = Offerlist[i];
                tmp.Attributes = GetAttributesValues(tmp);
                tmp.AdminSeller = FindSeller(tmp.IDAdminSeller);
                tmp.Category = GetCategory(tmp.IDCategory);
                tmp.Images = GetImages(tmp.ID);
                tmp.Demands = GetDemands(tmp.ID);
                //dodělat
            }
        }



        //může být parametr který by hledal
        public BindingList<Offer> GetAll()
        {
            return new BindingList<Offer>(this.Context.Offers.ToList());
        }


        public void SaveOffer(Offer offer)
        {
            if(offer.ID == 0)
            {
                this.Context.Offers.Add(offer);
                this.Context.SaveChanges();
            }
            UpdateOffer(offer);
            this.Context.SaveChanges();
        }

        public void UpdateOffer(Offer offer)
        {
            Offer tmp = this.Context.Offers.Find(offer.ID);  

            if(tmp != null)
            {
                tmp.IDCategory = offer.IDCategory;
                tmp.IDAdminSeller = offer.IDAdminSeller;

                tmp.Name = offer.Name;  
                tmp.Price = offer.Price;
                tmp.ShortInfo = offer.ShortInfo;
                tmp.Size = offer.Size;
                tmp.Region = offer.Region;
                tmp.Address = offer.Address;
                tmp.EnergeticClass = offer.EnergeticClass;
                tmp.BigInfo = offer.BigInfo;
                tmp.Type = offer.Type;
                tmp.Showed = offer.Showed;

                tmp.Category = GetCategory(tmp.IDCategory);
                tmp.AdminSeller = FindSeller(tmp.IDAdminSeller);
                tmp.Attributes = GetAttributesValues(tmp);
                tmp.Images = GetImages(tmp.ID);
                tmp.Demands = GetDemands(tmp.ID);
            }
        }

        public void SaveDemand(Demand demand)
        {
            if(demand.ID == 0)
            {
                this.Context.Demands.Add(demand);
                this.Context.SaveChanges();
                return;
            }
            UpdateDemand(demand);
            this.Context.SaveChanges();
        }

        public void UpdateDemand(Demand demand)
        {
            Demand? tmp = this.Context.Demands.Find(demand.ID);

            if(tmp != null)
            {
                tmp.IDUser = demand.IDUser; 
                tmp.IDOffer = demand.IDOffer;
                tmp.Name = demand.Name;
                tmp.Tel = demand.Tel;
                tmp.Email = demand.Email;
                tmp.Message = demand.Message;

                tmp.Offer = this.Context.Offers.First(x => x.ID == tmp.IDOffer);
                tmp.User = this.Context.Users.First(x => x.ID == tmp.IDUser);
            }   
        }


        public void SaveAttributeValue(AttributeValue attributeValue)
        {
            if (attributeValue.ID == 0)
            {
                this.Context.AttributesValues.Add(attributeValue);
                this.Context.SaveChanges();
                return;
            }
            UpdateAttributeValue(attributeValue);
            this.Context.SaveChanges();
        }

        public void UpdateAttributeValue(AttributeValue attributeValue)
        {
            AttributeValue? tmp = this.Context.AttributesValues.Find(attributeValue.ID);

            if (tmp != null)
            {
                tmp.IDAttribute = attributeValue.IDAttribute;
                tmp.IDOffer = attributeValue.IDOffer;
                tmp.Value = attributeValue.Value;

                tmp.Offer = this.Context.Offers.First(x => x.ID == tmp.IDOffer);
                tmp.Attribute = this.Context.Attributes.First(x => x.ID == tmp.IDAttribute);
            }
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

        public List<Demand> GetDemands(int id = 0)
        {
            if(id == 0)
            {
                return this.Context.Demands.ToList();
            }
            return this.Context.Demands.Where(x => x.IDOffer == id).ToList();
        }

        public void RemoveOffer(int id)
        {
            Offer? tmp = this.Context.Offers.Find(id);
            if (tmp != null)
            {
                this.Context.Offers.Remove(tmp);
                this.Offerlist.Remove(tmp);
                this.Context.SaveChanges();
            }
        }

        public void RemoveAttribute(int id)
        {
            Attribute? tmp = this.Context.Attributes.Find(id);
            if (tmp != null)
            {
                this.Context.Attributes.Remove(tmp);
                this.Context.SaveChanges();
            }
        }

        public void RemoveAttributeValue(int id)
        {
            AttributeValue? tmp = this.Context.AttributesValues.Find(id);
            if (tmp != null)
            {
                this.Context.AttributesValues.Remove(tmp);
                this.Context.SaveChanges();
            }
        }

        public void RemoveDemand(int id)
        {
            Demand? tmp = this.Context.Demands.Find(id);  
            if(tmp != null)
            {
                this.Context.Demands.Remove(tmp);
                this.Context.SaveChanges();
            }
        }


        public void SaveAttribute(Attribute attribute)
        {
            if (attribute.ID == 0)
            {
                this.Context.Attributes.Add(attribute);
                this.Context.SaveChanges();
            }
            UpdateAttribute(attribute);
            this.Context.SaveChanges();
        }

        public void UpdateAttribute(Attribute attribute)
        {
            Attribute tmp = this.Context.Attributes.Find(attribute.ID);

            if (tmp != null)
            {
               tmp.Name = attribute.Name;
            }
        }
    }
}
