using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PatientManagement.Data.Enums;

namespace PatientManagement.Web.ViewModels
{
    public class EditPatientViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Medical refernce number")]
        public string MRN { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string CNIC { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }
    }
}