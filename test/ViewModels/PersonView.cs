﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test.Models;

namespace test.ViewModels
{
    public class PersonView
    {
        public IEnumerable<App_PersonModels> PersonMds { get; set; }
    }
}