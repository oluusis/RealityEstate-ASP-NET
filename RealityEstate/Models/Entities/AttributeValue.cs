﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealityEstate.Models.Entities
{
    public class AttributeValue
    {
        public int ID { get; set; }

        [ForeignKey("Offer")]
        public int IDOffer { get; set; }

        [ForeignKey("Attribute")]
        public int IDAttribute { get; set; }

        [MinLength(1)]
        [MaxLength(100)]
        public string Value { get; set; }   

        public Offer? Offer { get; set; }

        public Attribute? Attribute { get; set; }    
    }
}
