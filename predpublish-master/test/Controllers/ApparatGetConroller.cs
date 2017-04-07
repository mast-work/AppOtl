using System;
using System.Collections.Generic;
using System.Data;
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
using System.Collections;
using System.DirectoryServices.ActiveDirectory;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using System.Xml;
using Rotativa;

//using System.Net.NetworkCredential;

namespace test.Controllers
{
    [MyAuthorize(Roles ="Admin,OTL,boss")]
    public class ApparatGetController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        

        public ActionResult Index(string SearchString)
        {

            int res=0;

            #region comment
            //var ViewModel = new ApplicationView();

            //ViewModel.ApplicationMds = db.Application
            //.Include(a => a.Person.Select(p=>p.BarcodePerson))
            //.Include(a => a.Equipment.Select(e=>e.BarcodeEquipment))
            //.Where(a => a.SetTime == new DateTime(2017, 1, 1));
            #endregion
           
                //List<ApplicationView> ViewModel = 

                var request =
                (from a in db.Application
                 join p in db.Person on a.BarcodePersonGet equals p.BarcodePerson
                     //join e in db.Equipment on
                     //new
                     //{
                     //    JoinProperty1 = a.BarcodeEquipment,
                     //    JoinProperty2 = a.TypeEquipment
                     //}
                     //     equals
                     //new
                     //{
                     //    JoinProperty1 = e.BarcodeEquipment,
                     //    JoinProperty2 = e.NameEquipment
                     //}
                     where a.SetTime == new DateTime(2017, 1, 1)
                 select new ApplicationView
                 {
                     BarcodePersonGet = a.BarcodePersonGet,
                     NamePersonGet = p.NamePerson,
                     BarcodeEquipment = a.BarcodeEquipment,
                     NameEquipment = a.TypeEquipment,//.NameEquipment,
                         GetTime = a.GetTime,
                     SetTime = a.SetTime,
                     Comment = a.Comment
                 });

            if ((!String.IsNullOrEmpty(SearchString)) && (int.TryParse(SearchString, out res)))

            {
                request = request.Where(b => b.BarcodeEquipment == res);
            }


            List<ApplicationView> ViewModel = request.ToList();



            #region roleCom
            //string property = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            //string property = System.Security.Principal.WindowsIdentity.GetCurrent().Groups;

            //string[] arr = Roles.GetRolesForUser();
            #endregion

            #region stProc
            //var storedProcess = db.Database.ExecuteSqlCommand("TEST_APP_PROCEDURE @ID = {0}",2);
            #endregion

            return View(ViewModel);

        }

        #region tryExcel    
        public ActionResult ExportData(List<ApplicationView> ViewModel)
        {
            //var sqlquery = (from a in db.Application
            //                join p in db.Person on a.BarcodePersonGet equals p.BarcodePerson
            //                join ps in db.Person on a.BarcodePersonSet equals ps.BarcodePerson

            //                where a.SetTime == new DateTime(2017, 1, 1)
            //                orderby a.GetTime
            //                select new ApplicationView
            //                {
            //                    BarcodePersonGet = a.BarcodePersonGet,
            //                    NamePersonGet = p.NamePerson,
            //                    BarcodeEquipment = a.BarcodeEquipment,
            //                    NameEquipment = a.TypeEquipment,
            //                    GetTime = a.GetTime,
            //                    BarcodePersonSet = a.BarcodePersonSet,
            //                    NamePersonSet = ps.NamePerson,
            //                    SetTime = a.SetTime,
            //                    Comment = a.Comment
            //                });

            //List<ApplicationView> ExcelList = sqlquery.ToList();

            GridView gv = new GridView();
            gv.DataSource = ViewModel;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Marklist.xls");
            Response.ContentType = "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            //Response.Charset = "cp-1251";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("Index");
        }
        #endregion




        public ActionResult ViewArchive(string SearchString)
        {
            int res = 0;

            var request =
            (from a in db.Application
             join p in db.Person on a.BarcodePersonGet equals p.BarcodePerson
             join ps in db.Person on a.BarcodePersonSet equals ps.BarcodePerson

             where a.SetTime != new DateTime(2017, 1, 1)
             orderby a.GetTime
             select new ApplicationView
             {
                 unicumvalue = a.Id,
                 BarcodePersonGet  = a.BarcodePersonGet,
                 NamePersonGet = p.NamePerson,
                 BarcodeEquipment = a.BarcodeEquipment,
                 NameEquipment = a.TypeEquipment,
                 GetTime = a.GetTime,
                 BarcodePersonSet = a.BarcodePersonSet,
                 NamePersonSet = ps.NamePerson,
                 SetTime = a.SetTime,
                 Comment = a.Comment
             });

            if ((!String.IsNullOrEmpty(SearchString)) && (int.TryParse(SearchString, out res)))

            {
                request = request.Where(b => b.BarcodeEquipment == res);
            }


            List<ApplicationView> ViewModel = request.ToList();


            return View(ViewModel);
        }


        public ActionResult Create()
        {
            return View();
        }

        #region check

        public bool ExistingEquipment(int BarcodeEquipment, string TypeEquipment)
        {
            if (BarcodeEquipment > 0)
            {
                return db.Equipment.Any(a => a.BarcodeEquipment == BarcodeEquipment && a.NameEquipment == TypeEquipment);
            }
            else
            {
                return false;
            }
        }

        public bool ExistingPerson(int BarcodePersonGet)
        {
            if (BarcodePersonGet > 0)
            {
                return db.Person.Any(a => a.BarcodePerson == BarcodePersonGet);
            }
            else
            {
                return false;
            }
        }


        public bool ExistingApp(int BarcodeEquipment, string TypeEquipment)
        {
            if (BarcodeEquipment > 0)
            {
                return db.Application.Any(a => a.BarcodeEquipment == BarcodeEquipment && a.SetTime == new DateTime(2017, 1, 1) && a.TypeEquipment == TypeEquipment);
            }
            else
            {
                return false;
            }
        }
        #endregion

        public int convertTo(int BarcodePerson)
        {
            try
            {
                int rezult;

                string number = Convert.ToString(BarcodePerson, 16);

                try
                {
                    rezult = Convert.ToInt32(number.Substring(number.Length - 4), 16);
                    //application.BarcodePersonGet = rezult;
                    //application.UserGet = User.Identity.Name.ToString().Replace("HCLASS\\", "");
                    return rezult;
                }

                catch
                {
                    //ModelState.AddModelError("BarcodePersonGet", "Ошибка сканирования");
                    return 1;
                }

            }
            catch
            {
                return 0;
            }
        }




        [HttpPost]
        public ActionResult Create([Bind(Include = "BarcodePersonGet,BarcodeEquipment,TypeEquipment")]App_ApplicationModels applicationGet)
        //public ActionResult Create(int barcodePerson,int  barcodeEquipment)
        {


            if (!ExistingEquipment(applicationGet.BarcodeEquipment,applicationGet.TypeEquipment))
            {
                ModelState.AddModelError("BarcodeEquipment", "Этого оборудование нет в списке");
                return View(applicationGet);
            }

            if (!ExistingPerson(applicationGet.BarcodePersonGet))
            {
                ModelState.AddModelError("BarcodePersonGet", "Этого сотрудника нет в списке");
                return View(applicationGet);
            }

            if (ExistingApp(applicationGet.BarcodeEquipment,applicationGet.TypeEquipment))
            {
                ModelState.AddModelError("BarcodeEquipment", "Это оборудование уже выдано");
                return View(applicationGet);
            }

            //applicationGet.BarcodePersonSet = 2;


            //Кодирование!
            //if (convertTo(applicationGet.BarcodePersonGet) > 1)
            //    applicationGet.BarcodePersonGet = convertTo(applicationGet.BarcodePersonGet);

            //else
            //{
            //    ModelState.AddModelError("BarcodePersonGet", "Ошибка сканирования");
            //    return View(applicationGet);
            //}



            try
            {
                if (ModelState.IsValid)
                {
                    
                    applicationGet.GetTime = DateTime.Now;
                    applicationGet.SetTime = new DateTime(2017, 1, 1);
                    applicationGet.UserGet = User.Identity.Name.ToString().Replace("HCLASS\\","");                 
                    //applicationGet.Person = new List<PersonModels>();
                    //applicationGet.Equipment = new List<EquipmentModels>();
                    //PersonModels person = db.Person.Where(p => p.BarcodePerson == applicationGet.BarcodePersonGet).First();
                    //applicationGet.Person.Add(person);
                    //EquipmentModels equipment = db.Equipment.Where(e => e.BarcodeEquipment == applicationGet.BarcodeEquipment).First();
                    //applicationGet.Equipment.Add(equipment);
                    //applicationGet.BarcodePersonSet = 0;
                    db.Application.Add(applicationGet);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("NotValid", "Невозможно сохранить. Попробуйте снова, если проблема повторится, напишите на Problems.");
            }

            return View(applicationGet);
        }



        public ActionResult SetApparat(int Id, string typeA)
        {

            //var request =
            //        (from s in db.Application
            //         join pers in db.Person on s.BarcodePerson equals pers.BarcodePerson
            //         join equip in db.Equipment on s.BarcodeEquipment equals equip.BarcodeEquipment
            //         where (s.BarcodeEquipment==Id & s.SetUser == null)
            //         select new ApplicationViewModel
            //         {
            //             BarcodePerson = s.BarcodePerson,
            //             NamePerson = pers.NamePerson,
            //             BarcodeEquipment = s.BarcodeEquipment,
            //             NameEquipment = equip.NameEquipment,
            //             SerialNumber = equip.SerialNumberEquipment,
            //             GetTime = s.GetTime,
            //             SetTime = s.SetTime,
            //             GetUser = s.GetUser,
            //             SetUser = s.SetUser,
            //             Commment = s.Comment
            //         });

            App_ApplicationModels apparat = db.Application
                .Where(a => a.BarcodeEquipment == Id && a.SetTime == new DateTime(2017, 1, 1) && a.TypeEquipment == typeA ).First();

            return View(apparat);

        }

        [HttpPost]
        public ActionResult SetApparat(int id, int BarcodePersonSet, string Comment,string TypeEquipment)

        {
            App_ApplicationModels applicationSet = db.Application
                .Where(a => a.BarcodeEquipment == id && a.SetTime == new DateTime(2017, 1, 1) && a.TypeEquipment== TypeEquipment).First();

            if (!ExistingPerson(BarcodePersonSet))
            {
                ModelState.AddModelError("BarcodePersonSet", "Этого сотрудника нет в списке");
                return View(applicationSet);
            }
            
            //Конвертация
            //if (convertTo(applicationSet.BarcodePersonSet) > 1)
            //    applicationSet.BarcodePersonGet = convertTo(applicationSet.BarcodePersonGet);
            //else
            //{
            //    ModelState.AddModelError("BarcodePersonSet", "Ошибка сканирования");
            //    return View(applicationSet);
            //}

            try
            {
                if (ModelState.IsValid)
                {
                    applicationSet.SetTime = DateTime.Now;

                    applicationSet.BarcodePersonSet = BarcodePersonSet;

                    applicationSet.UserSet = User.Identity.Name.ToString().Replace("HCLASS\\", "");

                    applicationSet.Comment = Comment;


                    db.Entry(applicationSet).State = EntityState.Modified;

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


        public ActionResult ViewPerson(int? Id)

        {
            App_PersonModels person = new App_PersonModels();

            if (Id != null & db.Person.Any(a=>a.BarcodePerson == Id))
            {


                person = db.Person.First(a => a.BarcodePerson == Id);

            }

            else
            {
                person.NamePerson = "";

            }

            return PartialView(person);
        }

        public ActionResult ViewEquipment(int? Id)
        {
            App_EquipmentModels equipment = new App_EquipmentModels();
            {
                if (Id != null & db.Equipment.Any(a=>a.BarcodeEquipment ==Id))
                {
                    equipment = db.Equipment.First(a => a.BarcodeEquipment == Id);
                }

                else
                {
                    equipment.NameEquipment = "";
                    equipment.SerialNumberEquipment = "";
                }

                return PartialView(equipment);
            }
        }

        
        public ActionResult Print(int Id)
        {
            var request = (from a in db.Application
                           join p in db.Person on a.BarcodePersonGet equals p.BarcodePerson
                           join ps in db.Person on a.BarcodePersonSet equals ps.BarcodePerson
                           where a.Id == Id
                           select new ApplicationView
                           {
                               unicumvalue = a.Id,
                               BarcodePersonGet = a.BarcodePersonGet,
                               NamePersonGet = p.NamePerson,
                               BarcodeEquipment = a.BarcodeEquipment,
                               NameEquipment = a.TypeEquipment,
                               GetTime = a.GetTime,
                               BarcodePersonSet = a.BarcodePersonSet,
                               NamePersonSet = ps.NamePerson,
                               SetTime = a.SetTime,
                               Comment = a.Comment
                           });
            ApplicationView applicationAct = request.First();

            return View(applicationAct);
        }

        [WordDocument]
        public ActionResult PrintDocument(int Id)
        {
            var request = (from a in db.Application
                          join p in db.Person on a.BarcodePersonGet equals p.BarcodePerson
                          join ps in db.Person on a.BarcodePersonSet equals ps.BarcodePerson
                          where a.Id ==Id                         
                          select new ApplicationView
                          {
                              unicumvalue = a.Id,
                              BarcodePersonGet = a.BarcodePersonGet,
                              NamePersonGet = p.NamePerson,
                              BarcodeEquipment = a.BarcodeEquipment,
                              NameEquipment = a.TypeEquipment,
                              GetTime = a.GetTime,
                              BarcodePersonSet = a.BarcodePersonSet,
                              NamePersonSet = ps.NamePerson,
                              SetTime = a.SetTime,
                              Comment = a.Comment
                          });
            ApplicationView applicationAct = request.First();
            ViewBag.WordDocumentFilename = "Act";
            return View("Print", applicationAct);
        }

    }
}