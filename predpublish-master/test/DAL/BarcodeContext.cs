using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace test.DAL
{
    public class BarcodeContext : DbContext

    {
        public BarcodeContext()
        : base("name =ApplicationCon")
        {
            //Database.SetInitializer<ApplicationContext>(new CreateDatabaseIfNotExists<ApplicationContext>());
        }

        public DbSet<App_BarcodeItem> Barcode { get; set; }

        public DbSet<App_BarcodeLog> BarcodeLog { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        //public DbSet<EquipmentModel> Equipment { get; set; }

        //public DbSet<ApplicationModel> Application { get; set; }
    }

}