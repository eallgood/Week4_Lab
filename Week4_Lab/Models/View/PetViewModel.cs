﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Week4_Lab.Models.View
{
    public class PetViewModel
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Pet's Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Pet's Age")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Vet Name")]
        public string VetName { get; set; }

        [Required]
        [Display(Name = "Next Checkup")]
        public DateTime NextCheckup { get; set; }
    }
}