using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    public class App_ApplicationModels
    {
        public int Id { get; set; }
        
        
        [Required]
        [Range(1,Int32.MaxValue)]
        public int BarcodePersonGet { get; set; }

        //[Required]
        public string UserGet { get; set; }

        //[Range(1, Int32.MaxValue)]
        public int BarcodePersonSet { get; set; }

        
        public string UserSet { get; set; }

        //[ForeignKey("Equipment")]
        [Required]
        [Range(0, Int32.MaxValue)]
        public int BarcodeEquipment { get; set; }

        [Required]
        public string TypeEquipment { get; set; }

        public DateTime GetTime { get; set; }

        public DateTime SetTime { get; set; }

        public string Comment { get; set; }


    }
}