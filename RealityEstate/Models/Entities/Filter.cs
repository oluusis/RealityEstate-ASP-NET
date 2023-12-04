namespace RealityEstate.Models.Entities
{
    public class Filter
    {
        public string? Type { get; set; }
        
        public int? MaxPrice { get; set; }
        public int? MinPrice { get; set; }   

        public string? Region { get; set; }

        public int? Size { get; set; }

        public int? IDCategory { get; set; }

        public int? ListingStart { get; set; }
    }
}
