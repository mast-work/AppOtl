using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class App_ShipmentControlModels
    {
        public int ID { get; set; }

        public short DC { get; set; }

        public int Internal_shipment_num { get; set;}

        public int Shipment_id { get; set; }

        public string Route_num { get; set; }

        public int Ship_to { get; set; }

        public int Tovaroved { get; set; }

        public string Type_product { get; set; }

        public DateTime Planned_ship_date { get; set; }

        public DateTime Planned_ship_date_new { get; set; }

        public float wait_volume { get;set;}

        public float wait_weght { get; set; }

        public int wait_rows { get; set; }

        public byte wait_plt { get; set; }

        public float load_volume { get; set; }

        public float load_weght { get; set; }

        public int load_rows { get; set; }

        public byte load_plt { get; set; }

        public byte qty_container { get; set; }

        public string status { get; set; }
    }
}