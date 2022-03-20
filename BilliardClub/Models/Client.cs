﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BilliardClub.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }

    }
}