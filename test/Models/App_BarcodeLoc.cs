using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class App_BarcodeLoc
    {
        public int Id { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Barcode { get; set; }
    }
}