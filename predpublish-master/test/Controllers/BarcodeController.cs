using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.DAL;
using test.Models;

namespace test.Controllers
{
    public class BarcodeController : Controller
    {

        BarcodeContext db = new BarcodeContext();

        // GET: Barcode

        public ActionResult Index(string searchString)
        {
            int rez;

            

            if ((!String.IsNullOrEmpty(searchString)) && searchString.Length == 13 && (int.TryParse(searchString.Substring(2,5), out rez)) && searchString.Substring(0, 2)=="21")
            {

                int q = db.Barcode.Where(b => b.Barcode == rez).ToList().Count();

                if (q > 0)
                {
                    ViewBag.Massage = "Есть";
                }
                else
                {
                    ViewBag.Massage = "Нету";

                        try
                        {
                            App_BarcodeLog bLog = new App_BarcodeLog()
                            {
                                Barcode = searchString,
                                UserCheck = User.Identity.Name.Replace(@"HCLASS\", ""),
                                DateAdd = DateTime.Now

                            };

                            db.BarcodeLog.Add(bLog);

                            //db.Application.Add(applicationGet);
                            db.SaveChanges();
                            //return RedirectToAction("Index");
                        

                    }
                    catch (RetryLimitExceededException /* dex */)
                    {
                        //Log the error (uncomment dex variable name and add a line here to write a log.)
                        ModelState.AddModelError("NotValid", "Невозможно сохранить. Попробуйте снова, если проблема повторится, напишите на Problems.");
                    }

                }

                return View();
            }

            ViewBag.Massage = "Некорректные данные";

            return View();

        }
    }
}