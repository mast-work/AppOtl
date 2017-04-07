using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class App_BarcodeLog
    {
        public int Id { get; set; }

        public string Barcode { get; set; }

        public string UserCheck { get; set; }
        
        public DateTime DateAdd { get; set; } 

    }
}