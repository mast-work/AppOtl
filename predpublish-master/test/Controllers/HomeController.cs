using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using test.Models;
using test.DAL;
using System.Threading;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        //protected void Application_PostAuthenticateRequest()
        //{

        //    if (HttpContext.Current.User != null)
        //    {

        //        ApplicationContext db = new ApplicationContext();

        //        String[] roleses = (from r in db.Role
        //                            where r.WindowsName.Contains(User.Identity.Name.Replace("HCLASS\\", ""))
        //                            select r.Position).ToArray();

        //        //GetRolesFromSomeDataTable(HttpContext.Current.User.Identity.Name);

        //        //GenericPrincipal principal = new GenericPrincipal(HttpContext.Current.User.Identity, roleses);

        //        HttpContext.Current.User =
        //                Thread.CurrentPrincipal =
        //                        new GenericPrincipal(User.Identity, roleses);

        //        bool IsTrue = User.IsInRole("StartSuperUser");

        //        //Thread.CurrentPrincipal = HttpContext.Current.User = principal;
        //    }




        



    }
}