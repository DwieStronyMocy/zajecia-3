﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zajęcia_3.Models
{
    public class Address
    {
        [Display(Name = "Twoja ulubiona ulica")]
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public int Number { get; set; }

    }
}