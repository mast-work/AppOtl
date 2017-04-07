using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Globalization;
using System.Web.UI;
using System.Web.Mvc;
using test.DAL;
using test.Filter;
using test.ViewModels;
using test.Models;
using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
//using Rotativa;

namespace test.Controllers
{

    public class PersonController : Controller
    {
        //private Person db = new Person();

        public ApplicationContext db = new ApplicationContext();

        private PersonView _personView = new PersonView();

        [MyAuthorize(Roles = "Admin,OTL,boss,BRIGADIR")]

        public ActionResult Index()
        {
            int DC = MvcApplication.CurrentDC();
            //var personView = new PersonView();
            _personView.PersonMds = db.Person
                                    .Where(n=>n.DC ==DC)
                                    .OrderBy(n => n.NamePerson);

            return View(_personView);
        }


        //public ActionResult Print()
        //{
        //    _personView.PersonMds = db.Person.OrderBy(n => n.NamePerson);
        //    return new Rotativa.ViewAsPdf()

        //    {
        //            FormsAuthenticationCookieName = System.Web.Security.FormsAuthentication.FormsCookieName,
        //            ViewName = "Print",
        //            Model = _personView
        //    };

        //}

        [MyAuthorize(Roles = "Admin,OTL,boss")]

        public ActionResult Create()
        {
            return View();
        }

        [MyAuthorize(Roles = "Admin,OTL,boss")]

        public ActionResult Edit(int Id)
        {
            int DC = MvcApplication.CurrentDC();

            App_PersonModels person = db.Person.Find(Id);

            return View(person);
        }

        [MyAuthorize(Roles = "Admin,OTL,boss")]

        [HttpPost]
        public ActionResult Edit(int id, int UserProperty1, int  UserProperty2)
        {
            int DC = MvcApplication.CurrentDC();

            App_PersonModels personEdit = db.Person.Find(id);

            try
            {
                if (ModelState.IsValid)
                {
                    personEdit.UserProperty1 = UserProperty1;

                    personEdit.UserProperty2 = UserProperty2;

                    //applicationSet.BarcodePersonSet = BarcodePersonSet;
                                                          


                    db.Entry(personEdit).State = EntityState.Modified;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("ModelError", "Невозможно сохранить. Попробуйте снова, если проблема повторится, напишите на Problems.");
            }

            return RedirectToAction("Index");
        }


        
        public bool CheckExistingPerson(int BarcodePerson)
        {
            int DC = MvcApplication.CurrentDC();

            if (BarcodePerson>0)
            { 
                return !db.Person.Any(a => a.BarcodePerson == BarcodePerson && a.DC==DC);
            }
            else
            {
                return false;
            }
        }


        [MyAuthorize(Roles = "Admin,OTL,boss")]

        [HttpPost]

        public ActionResult Create([Bind(Include = "BarcodePerson,NamePerson")] App_PersonModels person)
        {
            int DC = MvcApplication.CurrentDC();

            try
            {
                int rezult;
                
                string number = Convert.ToString(person.BarcodePerson,16);

                try
                {
                    rezult = Convert.ToInt32(number.Substring(number.Length - 4), 16);
                    person.BarcodePerson = rezult;
                }

                catch
                {
                    ModelState.AddModelError("BarcodePerson", "Ошибка сканирования");
                    return View(person);
                }



            }
            catch 
            {
                ModelState.AddModelError("BarcodePerson", "Ошибка считывания");
                return View(person);
            }

            if (!CheckExistingPerson(person.BarcodePerson))
            {
                ModelState.AddModelError("BarcodePerson", "Этот сотрудник уже заведен");
                return View(person);
            }

            try
            {
                if (ModelState.IsValid)
                {
                    //PersonModels p = new PersonModels();
                    //p.BarcodePerson = person.BarcodePerson;
                    //p.NamePerson = person.NamePerson;
                    person.DC = DC;                  
                    db.Person.Add(person);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return View(person);

        }


    }
}