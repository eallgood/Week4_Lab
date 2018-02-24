using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Week4_Lab.Models.View;

namespace Week4_Lab.Data.Entities
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime NextCheckup { get; set; }

        public string VetName { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public PetViewModel MapToPetViewModel()
        {
            return new PetViewModel
            {
                Id = this.Id,
                Name = this.Name,
                Age = this.Age,
                NextCheckup = this.NextCheckup,
                VetName = this.VetName,
                UserId = this.UserId
            };
        }

        public void Update(Pet pet)
        {
            Id = pet.Id;
            Name = pet.Name;
            Age = pet.Age;
            NextCheckup = pet.NextCheckup;
            VetName = pet.VetName;
            UserId = pet.UserId;
        }
    }
}