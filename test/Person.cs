using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using test.Models;

namespace test
{


    public class Person : DbContext
    {
        public Person()
            : base("name=Person")
        {
        }

        public DbSet<App_PersonModels> PersonModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
