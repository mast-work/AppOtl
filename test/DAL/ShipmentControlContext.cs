using System;
using System.Collections.Generic;
using test.Models;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace test.DAL
{
    public class ShipmentControlContext : DbContext
    {
        public ShipmentControlContext()
        : base("name =ApplicationCon")
        {
        }

        public DbSet<App_ShipmentControlModels> ShipmentControl { get; set; }

        public DbSet<App_UserRole> Role { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}