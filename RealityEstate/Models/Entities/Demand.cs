using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RealityEstate.Models.Rights;

namespace RealityEstate.Models.Entities
{
    public class Demand
    {
        public int ID { get; set; }

        [ForeignKey("User")]
        public int? IDUser { get; set; }

        [ForeignKey("Offer")]
        public int IDOffer { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Phone]
        [StringLength(15, MinimumLength = 8)]
        public string Tel { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100,MinimumLength = 4)]
        public string Email { get; set; }

        public string? Message { get; set; }

        public Offer Offer { get; set; }

        public User? User { get; set; }

    }
}
