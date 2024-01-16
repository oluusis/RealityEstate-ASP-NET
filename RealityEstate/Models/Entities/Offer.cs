using RealityEstate.Models.Database.Services;
using System.ComponentModel.DataAnnotations.Schema;
using RealityEstate.Models.Rights;
using RealityEstate.Models.Database.Context;
using System;

namespace RealityEstate.Models.Entities
{
    public class Offer
    {
        public int ID { get; set; }

        [ForeignKey("Category")]
        public int IDCategory { get; set; }

        [ForeignKey("AdminSeller")]
        public int IDAdminSeller { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string ShortInfo { get; set; }

        public int Size { get; set; }   

        public string Region { get; set; }

        public string Address { get; set; }

        public string GetFullAddress {
            get
            {
                return this.Region + ", " + this.Address;
            }}  

        public char EnergeticClass { get; set; }

        public string BigInfo { get; set; } 

        public string Type { get; set; }

        public bool Showed { get; set; }    

        public Category? Category { get; set; }

        public AdminSeller? AdminSeller { get; set; }

        public List<AttributeValue>? Attributes { get; set; }

        public List<Image>? Images { get; set; }

        public List<Demand>? Demands { get; set; }

        [NotMapped]
        public List<IFormFile>? Image { get; set; }
    }
}
