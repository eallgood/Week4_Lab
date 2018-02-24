using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Week4_Lab.Models.View;

namespace Week4_Lab.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(32)]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int YearsInSchool { get; set; }

        public ICollection<Pet> Pets { get; set; }

        public UserViewModel MapToUserViewModel()
        {
            return new UserViewModel
            {
                Id = this.Id,
                FirstName = this.FirstName,
                MiddleName = this.MiddleName,
                LastName = this.LastName,
                EmailAddress = this.EmailAddress,
                DateOfBirth = this.DateOfBirth,
                YearsInSchool = this.YearsInSchool
            };
        }

        public void Update(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            MiddleName = user.MiddleName;
            LastName = user.LastName;
            EmailAddress = user.EmailAddress;
            DateOfBirth = user.DateOfBirth;
            YearsInSchool = user.YearsInSchool;
        }
    }
}