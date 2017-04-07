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
    
    public class EquipmentController : Controller
    {

        private ApplicationContext db = new ApplicationContext();


        [MyAuthorize(Roles = "Admin,OTL,boss,BRIGADIR")]
        public ActionResult Index()
        {
            int DC = MvcApplication.CurrentDC();
            var equipmentView = new EquipmentView();
            equipmentView.EquipmentMds = db.Equipment
                    .Where(n=>n.DC==DC)
                    .OrderBy(n => n.NameEquipment);

            return View(equipmentView);
        }

        [MyAuthorize(Roles = "Admin,OTL,boss")]
        public ActionResult Create()
        {
            return View();
        }


        public bool CheckExistingEquipment(int BarcodeEquipment)
        {
            int DC = MvcApplication.CurrentDC();

            if (BarcodeEquipment > 0)
            {
                return !db.Equipment.Any(a => a.BarcodeEquipment == BarcodeEquipment && a.DC==DC);
            }
            else
            {
                return false;
            }
        }

        [MyAuthorize(Roles = "Admin,OTL,boss")]
        [HttpPost]
        public ActionResult Create([Bind(Include = "BarcodeEquipment,NameEquipment,SerialNumberEquipment")]App_EquipmentModels equipment)
        {
            int DC = MvcApplication.CurrentDC();

            if (!CheckExistingEquipment(equipment.BarcodeEquipment))
            {
                ModelState.AddModelError("BarcodeEquipment", "Этот оборудование уже добавлено");
                return View(equipment);
            }

            try
            {
                if (ModelState.IsValid)
                {
                    equipment.DC = DC;

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