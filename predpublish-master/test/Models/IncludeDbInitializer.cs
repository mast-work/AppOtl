using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using test.DAL;
namespace test.Models
{
    public class IncludeDbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        //protected override void Seed(ApplicationContext db)
        //{
        //    //db.Person.Add(new PersonModels { PersonBarcode = 2, PersonName = "Денис" });
        //    //db.Person.Add(new PersonModels { PersonBarcode = 1, PersonName = "Иван" });
        //    base.Seed(db);
        //}
    }
}