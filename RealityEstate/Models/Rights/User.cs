using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using RealityEstate.Models.Entities;

namespace RealityEstate.Models.Rights
{
    public class User
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Tel { get; set; }

        public string LoginName { get; set; }

        [PasswordPropertyText]
        public string Password { get; set; }

        public List<Demand>? Demands { get; set; }
    }
}
