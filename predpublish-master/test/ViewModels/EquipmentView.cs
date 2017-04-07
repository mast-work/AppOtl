using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test.Models;

namespace test.ViewModels
{
    public class EquipmentView
    {
        public IEnumerable<App_EquipmentModels> EquipmentMds { get; set; }
    }
}