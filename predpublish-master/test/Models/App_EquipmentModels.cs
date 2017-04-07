using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace test.Models
{
    public class App_EquipmentModels
    {
        public int Id { get; set; }

        [Required]
        [Range(1,Int32.MaxValue,ErrorMessage ="Укажите код")]
        public int BarcodeEquipment { get; set; }

        [Required]
        [StringLength(100,ErrorMessage ="Укажите серийный номер")]
        public string SerialNumberEquipment { get; set; }

        [Required]
        [StringLength(100,ErrorMessage ="Укажите наименование")]
        public string NameEquipment { get; set; }

        public string Condition { get; set;}

        

 

    }
}