using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Claims;
using RealityEstate.Models.Rights;
using RealityEstate.Models.Entities;
using RealityEstate.Models.Database.Services;

namespace RealityEstate.Models.Database.Context
{
    public class Context : DbContext
    {
        public DbSet<Entities.Attribute> Attributes { get; set; }
        public DbSet<AttributeValue> AttributesValues { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Demand> Demands { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<AdminSeller> AdminSellers { get; set; }
        public DbSet<User> Users { get; set; }

        private static Context instance;
        public static Context Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Context();
                }
                return instance;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;database=4a2_hrubanoliver_db2;user=hrubanoliver;password=123456;SslMode=none");
        }
    }
}
