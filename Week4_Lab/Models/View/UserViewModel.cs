using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Week4_Lab.Data.Entities;

namespace Week4_Lab.Models.View
{
    public class UserViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Years in School")]
        public int YearsInSchool { get; set; }

        public User MapToUser()
        {
            return new User
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

        public void CopyToUser(User user)
        {
            user.FirstName = this.FirstName;
            user.MiddleName = this.MiddleName;
            user.LastName = this.LastName;
            user.EmailAddress = this.EmailAddress;
            user.DateOfBirth = this.DateOfBirth;
            user.YearsInSchool = this.YearsInSchool;
        }
    }

}