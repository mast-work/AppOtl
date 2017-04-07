using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace test.DAL
{
    public class ApplicationContext : DbContext

    {
        public ApplicationContext()
        : base("name =ApplicationCon")
        {
            //Database.SetInitializer<ApplicationContext>(new CreateDatabaseIfNotExists<ApplicationContext>());
        }

        public DbSet<App_PersonModels> Person { get; set; }

        public DbSet<App_EquipmentModels> Equipment { get; set; }

        public DbSet<App_ApplicationModels> Application { get; set; }

        public DbSet<App_UserRole> Role { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        //public DbSet<EquipmentModel> Equipment { get; set; }

        //public DbSet<ApplicationModel> Application { get; set; }
    }
}