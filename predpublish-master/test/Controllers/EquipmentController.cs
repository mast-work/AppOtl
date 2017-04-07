using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using test.DAL;
using test.Filter;
using test.ViewModels;
using test.Models;
using System.Data.Entity.Infrastructure;

namespace test.Controllers
{
    [MyAuthorize(Roles = "Admin, OTL,boss")]
    public class EquipmentController : Controller
    {

        private ApplicationContext db = new ApplicationContext();

        public ActionResult Index()
        {
            var equipmentView = new EquipmentView();
            equipmentView.EquipmentMds = db.Equipment.OrderBy(n => n.NameEquipment);

            return View(equipmentView);
        }

        public ActionResult Create()
        {
            return View();
        }


        public bool CheckExistingEquipment(int BarcodeEquipment)
        {
            if (BarcodeEquipment > 0)
            {
                return !db.Equipment.Any(a => a.BarcodeEquipment == BarcodeEquipment);
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "BarcodeEquipment,NameEquipment,SerialNumberEquipment")]App_EquipmentModels equipment)
        {

            if (!CheckExistingEquipment(equipment.BarcodeEquipment))
            {
                ModelState.AddModelError("BarcodeEquipment", "Этот оборудование уже добавлено");
                return View(equipment);
            }

            try
            {
                if (ModelState.IsValid)
                {
                    db.Equipment.Add(equipment);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return View(equipment);
        }

    }
}