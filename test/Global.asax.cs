using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using test.Models;
using test.DAL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Principal;
using System.Threading;
using System.Data.Common;
using System.Data.SqlClient;
//using test.Models;

namespace test
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            //Database.SetInitializer(new IncludeDbInitializer());

            //AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //App_Start.Application_AuthenticateRequest R = new App_Start.Application_AuthenticateRequest();

            //R.MyAuthenticateRequest(event = PostAuthenticateRequest);

            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationContext>());
        }


        protected void Application_PostAuthenticateRequest()
        {

            if (HttpContext.Current.User != null)
            {

                ApplicationContext db = new ApplicationContext();

                String[] roleses = (from r in db.Role
                                    where r.WindowsName.Contains(User.Identity.Name.Replace("HCLASS\\", ""))
                                    select r.Position).ToArray();

                //GetRolesFromSomeDataTable(HttpContext.Current.User.Identity.Name);

                //GenericPrincipal principal = new GenericPrincipal(HttpContext.Current.User.Identity, roleses);

                HttpContext.Current.User =
                        Thread.CurrentPrincipal =
                                new GenericPrincipal(User.Identity, roleses);

                //bool IsTrue = User.IsInRole("StartSuperUser");

                //Thread.CurrentPrincipal = HttpContext.Current.User = principal;
            }

        }

        public static int CurrentDC()
        {
            
                    if (HttpContext.Current.User.IsInRole("44"))
                            {
                                return 44;
                            }
                    if (HttpContext.Current.User.IsInRole("600"))
                        {
                            return 600;
                        }
                    else
                        {
                            return 600;
                        }
          }
        



    }
}

