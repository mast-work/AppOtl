using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.DAL;
using test.Filter;
using test.Models;
using test.ViewModels;
using Newtonsoft.Json;
using System.Data.Entity;

namespace test.Controllers
{
    [MyAuthorize(Roles = "Admin,OTL,boss,BRIGADIR")]
    public class ShipmentControlController: Controller
    {
        //List<ShipControlView> ShipControl = new List<ShipControlView>;

        private ShipmentControlContext db = new ShipmentControlContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string SaveShipment(ShipControlView vSh)
        {
            //int DC = MvcApplication.CurrentDC();

            App_ShipmentControlModels shipment  = db.ShipmentControl.Find(vSh.ID);

            try
            {
                if (ModelState.IsValid)
                {

                    shipment.Planned_ship_date = vSh.Planned_ship_date;

                    db.Entry(shipment).State = EntityState.Modified;

                    db.SaveChanges();
                    return "Ok";
                }

                else
                {
                    return "Error";
                }

            }
            catch (System.Data.Entity.Infrastructure.RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                return "Error";
            }

        }


        public string ShupmentDetail(int Id)
        {
            int DC = MvcApplication.CurrentDC();

            var request =
            (from s in db.ShipmentControl
             where s.Planned_ship_date < DateTime.Now
                && s.DC == DC && s.ID == Id

             select new ShipDetail()
             {

                 Tovaroved = s.Tovaroved,
                 Type_product = s.Type_product
             });

            List<ShipDetail> ViewModels1 = request.ToList();




            return JsonConvert.SerializeObject(ViewModels1);


        }

        public string GetData()
        {
            
        
                

                int DC = MvcApplication.CurrentDC();

                var request =
                (from s in db.ShipmentControl
                 where s.Planned_ship_date < DateTime.Now
                    && s.DC == DC

                 select new ShipControlView()
                 {
                     ID = s.ID,
                     DC = s.DC,
                     Internal_shipment_num = s.Internal_shipment_num,
                     Shipment_id = s.Shipment_id,
                     Route_num = s.Route_num,
                     Planned_ship_date = s.Planned_ship_date
                 });

            List<ShipControlView> ViewModels = request.ToList();

            


            return JsonConvert.SerializeObject(ViewModels);
        }

    }
}