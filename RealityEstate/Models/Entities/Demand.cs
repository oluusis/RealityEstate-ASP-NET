using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RealityEstate.Models.Rights;

namespace RealityEstate.Models.Entities
{
    public class Demand
    {
        public int ID { get; set; }

        [ForeignKey("User")]
        public int IDUser { get; set; }

        [ForeignKey("Offer")]
        public int IDOffer { get; set; }

        public string Name { get; set; }

        [Phone]
        public string Tel { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Message { get; set; }

        public Offer Offer { get; set; }

        public User User { get; set; }

    }
}
