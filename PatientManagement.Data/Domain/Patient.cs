using System;
using PatientManagement.Data.Enums;

namespace PatientManagement.Data.Domain
{
    public class Patient
    {
        public int Id { get; set; }
        public string MRN { get; set; }
        public Gender Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CNIC { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}
