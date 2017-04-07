    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
using System.Web.Mvc;

namespace test.Models
{ 
    public class App_PersonModels

        {

            public int Id { get; set; }

            [Required]
            [Range(1, Int32.MaxValue, ErrorMessage = "Укажите код")]
            //[Remote("CheckExistingPerson", "PersonController", HttpMethod = "POST", ErrorMessage = "Такой сотрудник уже есть")]
            public int BarcodePerson { get; set; }
            
            [Required]
            [StringLength(50,ErrorMessage ="Укажите имя")]
            public string NamePerson { get; set; }

            //[Required]
            ////[RegularExpression("[0-9]",ErrorMessage ="Отсканируте пропуск")]
            //public int BarcodePersonAll { get; set; }

            

            
        }
}


