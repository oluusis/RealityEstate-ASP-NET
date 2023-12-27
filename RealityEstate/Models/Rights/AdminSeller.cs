using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RealityEstate.Models.Rights
{
    public class AdminSeller
    {
        public int ID { get; set; }

        public string ImagePath { get; set; }
        
        public bool Type { get; set; }
     
        public string Title { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Tel { get; set; }

        public string LoginName { get; set; }

        [PasswordPropertyText]
        public string Password { get; set; }


        public string GetFullName
        {
            get
            {
                return this.Name + " " + this.Surname;
            }
        }
    }
}
