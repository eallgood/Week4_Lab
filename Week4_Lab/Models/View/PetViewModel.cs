using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Week4_Lab.Data.Entities;

namespace Week4_Lab.Models.View
{
    public class PetViewModel
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public bool NeedsCheckup { get; set; }

        [Required]
        [Display(Name = "Pet's Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Pet's Age")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Next Checkup")]
        public DateTime NextCheckup { get; set; }

        [Required]
        [Display(Name = "Vet Name")]
        public string VetName { get; set; }


        public Pet MapToPet()
        {
            return new Pet
            {
                Id = this.Id,
                Name = this.Name,
                Age = this.Age,
                NextCheckup = this.NextCheckup,
                VetName = this.VetName,
                UserId = this.UserId
            };
        }

        public void CopyToPet(Pet pet)
        {
            pet.Name = this.Name;
            pet.Age = this.Age;
            pet.NextCheckup = this.NextCheckup;
            pet.VetName = this.VetName;
            pet.UserId = this.UserId;
            pet.Id = this.Id;
        }
    }
}