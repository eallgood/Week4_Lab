using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Week4_Lab.Data.Entities
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime NextCheckup { get; set; }
        public string VetName { get; set; }
        public int UserId { get; internal set; }
        public int Age { get; set; }
        public string Name { get; set; }
    }
}