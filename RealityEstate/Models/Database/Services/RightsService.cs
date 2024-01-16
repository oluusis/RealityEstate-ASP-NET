using RealityEstate.Models.Entities;
using System.ComponentModel;

namespace RealityEstate.Models.Database.Services
{
    using RealityEstate.Controllers.AuthorizingClasses;
    using RealityEstate.Models.Database.Context;
    using RealityEstate.Models.Rights;

    public class RightsService
    {
        public Context Context { get; set; }
        public BindingList<AdminSeller> AdminSellers { get; set; }
        public BindingList<User> Users { get; set; }

        private static CategoryService instance;
        public static CategoryService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryService();
                }
                return instance;
            }
        }


        public RightsService()
        {
            this.Context = new Context();
            this.AdminSellers = new BindingList<AdminSeller>(Context.AdminSellers.ToList());
            this.Users = new BindingList<User>(Context.Users.ToList());
            foreach(User user in this.Users)
            {
                foreach(Demand demand in Context.Demands)
                {
                    if(demand.IDUser == user.ID)
                    {
                        user.Demands.Add(demand);
                    }
                }
            }
        }

        public AdminSeller Find(int id)
        {
            return this.Context.AdminSellers.Find(id);
        }


        public void SaveUser(User user)
        {
            if(user.ID == 0)
            {
                user.Password = PasswordHasher.HashPassword(user.Password);
                this.Context.Users.Add(user);
                this.Context.SaveChanges();
                return;
            }
            
            Update(user);
            this.Context.SaveChanges();
        }


        private void Update(User usr)
        {
            User tmp = this.Context.Users.Find(usr.ID);   
            
            if (tmp != null)
            {
                tmp.ID = usr.ID;
                tmp.Name = usr.Name;
                tmp.Email = usr.Email;
                tmp.Tel = usr.Tel;
                tmp.Password = usr.Password;
                tmp.Demands = usr.Demands;
                tmp.LoginName = usr.LoginName;
            }
        }

        public void RemoveUser(int id)
        {
            User? tmp = this.Context.Users.Find(id);
            if(tmp != null)
            {
                this.Context.Users.Remove(tmp);
                this.Users.Remove(tmp);
                this.Context.SaveChanges();
            }
        }

        public void UpdateAdmin(AdminSeller admin)
        {
            AdminSeller tmp = this.Context.AdminSellers.Find(admin.ID);

            if (tmp != null)
            {
                tmp.Name = admin.Name;
                tmp.ImagePath = admin.ImagePath;
                tmp.Type = admin.Type;
                tmp.Title = admin.Title;
                tmp.Name = admin.Name;
                tmp.Surname = admin.Surname;
                tmp.Email = admin.Email;
                tmp.Tel = admin.Tel;
                tmp.LoginName= admin.LoginName;
                tmp.Password = admin.Password;

            }
        }
    }
}
