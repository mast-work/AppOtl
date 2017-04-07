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
using Rotativa;

namespace test.Controllers
{
    
    [MyAuthorize(Roles = "Admin,boss")]
    public class PersonController : Controller
    {
        //private Person db = new Person();

        public ApplicationContext db = new ApplicationContext();

        private PersonView _personView = new PersonView();

        public ActionResult Index()
        {
            //var personView = new PersonView();
                _personView.PersonMds = db.Person.OrderBy(n => n.NamePerson);

            return View(_personView);
        }


        public ActionResult Print()
        {
            _personView.PersonMds = db.Person.OrderBy(n => n.NamePerson);
            return new Rotativa.ViewAsPdf()

            {
                    FormsAuthenticationCookieName = System.Web.Security.FormsAuthentication.FormsCookieName,
                    ViewName = "Print",
                    Model = _personView
            };

        }


        public ActionResult Create()
        {
            return View();
        }


        //[AllowAnonymous]
        //[HttpPost]
        public bool CheckExistingPerson(int BarcodePerson)
        {
            if (BarcodePerson>0)
            { 
                return !db.Person.Any(a => a.BarcodePerson == BarcodePerson);
            }
            else
            {
                return false;
            }
        }



        [HttpPost]
        public ActionResult Create([Bind(Include = "BarcodePerson,NamePerson")] App_PersonModels person)
        {
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