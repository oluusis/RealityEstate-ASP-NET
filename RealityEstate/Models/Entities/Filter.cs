using System.ComponentModel.DataAnnotations;

namespace RealityEstate.Models.Entities
{
    public class Filter
    {

        public string? Type { get; set; }

        [Range(0, int.MaxValue)]
        public int? MaxPrice { get; set; }

        [Range(0, int.MaxValue)]
        public int? MinPrice { get; set; }   

        public string? Region { get; set; }

        [Range(1, 500)]
        public int? Size { get; set; }

        public int? IDCategory { get; set; }

        public int? ListingStart { get; set; }
    }
}
