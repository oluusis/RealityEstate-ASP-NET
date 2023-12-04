using System.ComponentModel.DataAnnotations.Schema;

namespace RealityEstate.Models.Entities
{
    public class Image
    {
        public int ID { get; set; }

        [ForeignKey("Offer")]
        public int IDOffer { get; set; }

        public string Path { get; set; }

        public Offer Offer { get; set; }
    }
}
