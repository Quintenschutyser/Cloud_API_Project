﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_API2.Model
{
    public class Land
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, 3)]
        public string Currency { get; set; }
        [Required]
        [Range(1,3)]
        public string Alpha3Code { get; set; }
    }
}
