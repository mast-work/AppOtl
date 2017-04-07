using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test.Models;

namespace test.ViewModels
{
    public class ApplicationView
    {
        //public IEnumerable<ApplicationModels> ApplicationMds { get; set; }

        //public IEnumerable<EquipmentModels> EquipmentMds { get; set; }

        //public IEnumerable<PersonModels> PersonMds { get; set; }

        public int unicumvalue { get; set; }

        public int BarcodePersonGet { get; set; }

        public string BarcodeName { get; set; }

        public string NamePersonGet { get; set; }

        public int BarcodePersonSet { get; set; }

        public string NamePersonSet { get; set; }

        public int BarcodeEquipment { get; set; }

        public string NameEquipment { get; set; }

        public DateTime GetTime { get; set; }

        public DateTime SetTime { get; set; }

        public string Comment { get; set; }

        public int DC { get; set; }

    }
}